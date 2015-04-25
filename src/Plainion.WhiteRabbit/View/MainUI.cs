using System;
using System.Drawing;
using System.Windows.Forms;
using Plainion.WhiteRabbit.Presentation;
using Plainion.WhiteRabbit.Properties;
using Plainion.WhiteRabbit.View;

namespace Plainion.WhiteRabbit
{
    public partial class MainUI : Form, IView
    {
        private const string BEGIN_COLUMN_NAME = "myBeginCol";
        private const string END_COLUMN_NAME = "myEndCol";
        private const string JITTER_COLUMN_NAME = "myJitterCol";
        private const string DURATION_COLUMN_NAME = "myDurationCol";
        private const string CATEGORY_COLUMN_NAME = "myCategoryCol";
        private const string TASK_COLUMN_NAME = "myTaskCol";

        private readonly BindingSource myBindingSource;
        private readonly Controller myController;
        private readonly Channel myChannel;

        public MainUI( Controller controller )
        {
            InitializeComponent();

            Text = "Plainion WhiteRabbit";

            myController = controller;

            myChannel = new Channel();

            myBindingSource = new BindingSource();
            myTableView.DataSource = myBindingSource;

            // select the DataTable related to the current data
            myController.ChangeDay( myDateTime.Value );

            myTableView.AutoGenerateColumns = false;
            myTableView.Columns[BEGIN_COLUMN_NAME].DataPropertyName = ColumnNames.BEGIN;
            myTableView.Columns[END_COLUMN_NAME].DataPropertyName = ColumnNames.END;
            myTableView.Columns[JITTER_COLUMN_NAME].DataPropertyName = ColumnNames.JITTER;
            myTableView.Columns[DURATION_COLUMN_NAME].DataPropertyName = ColumnNames.DURATION;
            myTableView.Columns[CATEGORY_COLUMN_NAME].DataPropertyName = ColumnNames.CATEGORY;
            myTableView.Columns[TASK_COLUMN_NAME].DataPropertyName = ColumnNames.TASK;

            myBindingSource.DataSource = myController.CurrentDayData;

            myCategoryCol.DisplayMember = "Name";
            myCategoryCol.DataSource = myController.Categories;

            mySplitbutton.ShowSplit = true;
        }

        #region Channel API

        public Channel Channel
        {
            get { return myChannel; }
        }

        #endregion

        private void selectDatabaseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            dlg.SelectedPath = Settings.Default.DBStore;
            dlg.ShowNewFolderButton = true;
            dlg.Description = "Select database store";

            if( dlg.ShowDialog( this ) != DialogResult.OK )
            {
                return;
            }

            if( dlg.SelectedPath != Settings.Default.DBStore )
            {
                Settings.Default.DBStore = dlg.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void myTableView_CellEndEdit( object sender, DataGridViewCellEventArgs e )
        {
            myBindingSource.EndEdit();

            myController.Database.StoreTable( myController.CurrentDayData );
        }

        private void myDateTime_ValueChanged( object sender, EventArgs e )
        {
            myController.ChangeDay( myDateTime.Value );
            myBindingSource.DataSource = myController.CurrentDayData;
        }

        private void myTableView_CellValidating( object sender, DataGridViewCellValidatingEventArgs e )
        {
            if( e.ColumnIndex >= 0 && e.ColumnIndex < 3 )
            {
                DataGridViewCell cell = myTableView[e.ColumnIndex, e.RowIndex];

                string value = ( (string) cell.EditedFormattedValue ).Trim();
                if( value.EndsWith( ":" ) )
                {
                    value += "00";
                    cell.Value = value;
                    //myTableView.InvalidateRow( e.RowIndex );
                    myTableView.RefreshEdit();
                }

                DateTime result;
                if( !DateTime.TryParse( value, out result ) )
                {
                    cell.Style.ForeColor = Color.Red;
                    //DataGridViewAdvancedBorderStyle style = new DataGridViewAdvancedBorderStyle();
                    //style.All = DataGridViewAdvancedCellBorderStyle.OutsetDouble;
                    //cell.AdjustCellBorderStyle( style, style, false, false, false, false );
                }
                else
                {
                    cell.Style.ForeColor = Color.Black;
                }
            }
        }

        private void myRecordInitBtn_Click( object sender, EventArgs e )
        {
            myStartRecordBtn_Click( sender, e );
        }

        private void myStartRecordBtn_Click( object sender, EventArgs e )
        {
            myController.StartTimeMeasurement();
        }

        private void myPauseRecordBtn_Click( object sender, EventArgs e )
        {
            /*
            myController.PauseTimeMeasurement();

            myStartRecordBtn.Enabled = true;
            myPauseRecordBtn.Enabled = false;
            myStopRecordBtn.Enabled = true;
             */
        }


        private void myStopRecordBtn_Click( object sender, EventArgs e )
        {
            /*
            myRecordPanel.Visible = false;
            Height = myRememberedHeight;
            Width = myRememberedWidth;

            myStartRecordBtn.Enabled = true;
            myPauseRecordBtn.Enabled = false;
            myStopRecordBtn.Enabled = false;

            myController.StopTimeMeasurement( myCategoryList.SelectedIndex, myTaskTxt.Text );
             */
        }

        private void myTableView_KeyUp( object sender, KeyEventArgs e )
        {
            if( e.Control && e.KeyCode == Keys.C )
            {
                DataObject d = myTableView.GetClipboardContent();
                Clipboard.SetDataObject( d );
                e.Handled = true;
            }
            else if( e.Control && e.KeyCode == Keys.V )
            {
                myTableView.CurrentCell.Value = Clipboard.GetText();
            }
            else if( e.KeyCode == Keys.Delete )
            {
                myTableView.CurrentCell.Value = string.Empty;
            }
        }

        private string SelectedCatagory
        {
            get
            {
                if( -1 != myCategoryList.SelectedIndex )
                {
                    return myController.Categories.Rows[myCategoryList.SelectedIndex][0] as string;
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        private void deleteSelectedRowMenuItem_Click( object sender, EventArgs e )
        {
            myController.DeleteDayEntry( myTableView.CurrentRow.Index );
        }

        private void myTableContextMenu_VisibleChanged( object sender, EventArgs e )
        {
            var allJitter = myController.GetJitterSum();
            myTableContextMenu.Items[2].Text = "Jitter sum: " + allJitter.Hours + ":" + allJitter.Minutes;
        }

        private void categoriesToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Form form = new CategoriesForm( myController );

            form.ShowDialog( this );

            // reload categories
            myController.LoadCategories();
            myCategoryList.DataSource = myController.Categories;
            myCategoryCol.DataSource = myController.Categories;
        }

        /*
        private void MainUI_Resize( object sender, EventArgs e )
        {
            if( FormWindowState.Minimized == WindowState )
            {
                myNotifyIcon.Visible = true;

                string tooltip = "White Rabbit";
                if( !string.IsNullOrEmpty( SelectedCatagory ) ||
                    !string.IsNullOrEmpty( myTaskTxt.Text ) )
                {
                    tooltip += ": ";
                    if( !string.IsNullOrEmpty( SelectedCatagory ) )
                    {
                        tooltip += SelectedCatagory;
                        if( !string.IsNullOrEmpty( myTaskTxt.Text ) )
                        {
                            tooltip += " / ";
                        }
                    }
                    if( !string.IsNullOrEmpty( myTaskTxt.Text ) )
                    {
                        tooltip += myTaskTxt.Text;
                    }
                }

                // max 64 chars allowed
                myNotifyIcon.Text = tooltip.Substring( 0, (tooltip.Length < 63 ? tooltip.Length : 63) );

                //myNotifyIcon.ShowBalloonTip( 500 );
                Hide();
            }
            else if( FormWindowState.Normal == this.WindowState )
            {
                myNotifyIcon.Visible = false;
            }
        }
        */

        private void myNotifyIcon_DoubleClick( object sender, EventArgs e )
        {
            Visible = true;
            Activate();
            WindowState = FormWindowState.Normal;
            myNotifyIcon.Visible = false;
        }


        private void myTableView_MouseDown( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Right )
            {
                DataGridView.HitTestInfo aHTI = myTableView.HitTest( e.X, e.Y );
                bool isCellValid = IsValidCell( aHTI.ColumnIndex, aHTI.RowIndex );
                if( isCellValid )
                {
                    myTableView.ClearSelection();
                    myTableView.CurrentCell = myTableView[aHTI.ColumnIndex, aHTI.RowIndex];
                }
            }
        }

        private void myTableView_MouseUp( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Right )
            {
                DataGridView.HitTestInfo aHTI = myTableView.HitTest( e.X, e.Y );
                bool isCellValid = IsValidCell( aHTI.ColumnIndex, aHTI.RowIndex );

                if( isCellValid )
                {
                    myTableContextMenu.Show( (Control) sender, e.X, e.Y );
                }
            }
        }


        private bool IsValidCell( int col, int row )
        {
            return ( ( -1 != col && -1 != row ) &&
                     !( myTableView[col, row].Value is DBNull ) &&
                     null != myTableView[col, row].Value );
        }

        private void dayReportToolStripMenuItem_Click( object sender, EventArgs e )
        {
            new ReportForm( myController ).ShowDialog( this );
        }
    }
}