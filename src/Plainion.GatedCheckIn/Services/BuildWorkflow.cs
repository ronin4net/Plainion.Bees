﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Plainion.GatedCheckIn.Model;
using Plainion.IO;
using Plainion.Scripts.TestRunner;

namespace Plainion.GatedCheckIn.Services
{
    internal class BuildWorkflow
    {
        private GitService myGitService;
        private BuildDefinition myDefinition;
        private BuildRequest myRequest;

        public BuildWorkflow(GitService gitService, BuildDefinition definition, BuildRequest request)
        {
            myGitService = gitService;
            myDefinition = definition;
            myRequest = request;
        }

        internal Task<bool> ExecuteAsync(IProgress<string> progress)
        {
            // clone thread save copy of the relevant paramters;
            myDefinition = Objects.Clone(myDefinition);
            myRequest = Objects.Clone(myRequest);

            return Task<bool>.Run(() => BuildSolution(progress)
                                        && RunTests(progress)
                                        && CheckIn(progress));
        }

        private bool BuildSolution(IProgress<string> progress)
        {
            var process = new UiShellCommand(@"C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe", progress);

            process.Execute(
                "/m",
                "/p:Configuration=" + myDefinition.Configuration,
                "/p:Platform=\"" + myDefinition.Platform + "\"",
                "/p:OutputPath=\"" + GetWorkingDirectory() + "\"",
                Path.Combine(myDefinition.RepositoryRoot, myDefinition.Solution));

            return process.ExitCode == 0;
        }

        private string GetWorkingDirectory()
        {
            return Path.Combine(myDefinition.RepositoryRoot, "bin", "gc");
        }

        private bool RunTests(IProgress<string> progress)
        {
            if (!myDefinition.RunTests)
            {
                return true;
            }

            Contract.Requires(File.Exists(myDefinition.TestRunnerExecutable), "Runner executable not found: {0}", myDefinition.TestRunnerExecutable);

            var runner = new TestRunner
            {
                Assemblies = myDefinition.TestAssemblyPattern,
                WorkingDirectory = GetWorkingDirectory()
            };

            var nunitProject = runner.GenerateProject();

            Contract.Invariant(nunitProject != null, "Failed to generate nunit project");

            var process = new UiShellCommand(myDefinition.TestRunnerExecutable, progress);

            process.Execute(nunitProject);

            return process.ExitCode == 0;
        }

        private bool CheckIn(IProgress<string> progress)
        {
            if (!myDefinition.CheckIn)
            {
                return true;
            }

            if (string.IsNullOrEmpty(myRequest.CheckInComment))
            {
                progress.Report("!! NO CHECKIN COMMENT PROVIDED !!");
                return false;
            }

            try
            {
                myGitService.Commit(myDefinition.RepositoryRoot, myRequest.Files, myRequest.CheckInComment, myDefinition.UserName, myDefinition.UserEMail);

                progress.Report("--- CHECKIN SUCCEEDED ---");

                return true;
            }
            catch (Exception ex)
            {
                progress.Report("CHECKIN FAILED: " + ex.Message);
                return false;
            }
        }
    }
}
