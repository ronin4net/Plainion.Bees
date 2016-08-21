﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using LibGit2Sharp;

namespace Plainion.GatedCheckIn.Services
{
    class PendingChangesObserver
    {
        private GitService myGitService;
        private Action<IEnumerable<StatusEntry>> myOnPendingChangesChanged;
        private FileSystemWatcher myPendingChangesWatcher;
        private string myWorkspaceRoot;
        private Task myWorkspaceReaderTask;
        private bool myWorkspaceChanged;

        public PendingChangesObserver( GitService gitService, Action<IEnumerable<StatusEntry>> onPendingChangesChanged )
        {
            myGitService = gitService;
            myOnPendingChangesChanged = onPendingChangesChanged;
        }

        public void Start( string workspaceRoot )
        {
            Contract.Invariant( myPendingChangesWatcher == null, "Pending changes watcher still running" );

            myWorkspaceRoot = workspaceRoot;

            myPendingChangesWatcher = new FileSystemWatcher();

            myPendingChangesWatcher.Path = workspaceRoot;
            myPendingChangesWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.DirectoryName;
            myPendingChangesWatcher.Filter = "*";
            myPendingChangesWatcher.IncludeSubdirectories = true;

            myPendingChangesWatcher.Created += OnChanged;
            myPendingChangesWatcher.Changed += OnChanged;
            myPendingChangesWatcher.Deleted += OnChanged;
            myPendingChangesWatcher.Renamed += OnChanged;

            myPendingChangesWatcher.EnableRaisingEvents = true;

            // run initial analysis
            OnChanged( null, null );
        }

        private void OnChanged( object source, FileSystemEventArgs e )
        {
            Debug.WriteLine( "Workspace change detected" );

            if( myWorkspaceReaderTask != null )
            {
                myWorkspaceChanged = true;
                return;
            }

            myWorkspaceChanged = false;

            myWorkspaceReaderTask = myGitService.GetChangedAndNewFilesAsync( myWorkspaceRoot )
                .ContinueWith( t => 
                    {
                        // intentionally we ignore all exceptions here because if in parallel a checkin or push is running
                        // we can easily run into race-conditions
                        if( t.IsFaulted )
                        {
                            myWorkspaceChanged = true;
                        }
                        else
                        {
                            Application.Current.Dispatcher.BeginInvoke( new Action( () => myOnPendingChangesChanged( t.Result ) ) );
                        }
                    })
                .ContinueWith( t =>
                    {
                        myWorkspaceReaderTask = null;

                        if( myWorkspaceChanged )
                        {
                            OnChanged( null, null );
                        }
                    } );
        }

        public void Stop()
        {
            if( myPendingChangesWatcher != null )
            {
                myPendingChangesWatcher.Dispose();
            }
            myWorkspaceReaderTask = null;
        }
    }
}