using PlanDBLoader.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanDBLoader
{
    public partial class frmMain : Form
    {
        #region Private Members
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private Stopwatch _stopwatch = new Stopwatch();
        public static event EventHandler ErrorEvent;
        #endregion

        public frmMain()
        {
            InitializeComponent();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtPath.Text = @"C:\\Temp\\LPA_DB_Work\Plans\Client_PlansData_Create.sql";
            txtOutputPath.Text = @"C:\Temp\LPA_DB_Work";
            ErrorEvent += ProcessErrorEvent;
            PlansDBInterations.CancelledEvent += EvaluationFile_CancelledEvent;
            PlansDBInterations.PlansSplitComplete += EvaluationCompletedEvent;
            PlansDBInterations.StatusUpdate += StatusUpdatedEvent;
        }

        /// <summary>
        /// Run through the sql of the plans db and split it into a file
        /// </summary>
        private async Task RunAsync()
        {
            try
            {
                _stopwatch.Start();
                await new PlansDBInterations().SplitAsync(txtPath.Text, txtOutputPath.Text);
            }
            catch (OperationCanceledException)
            {
                //ignore this, it means we cancelled the operation sucessfully.
            }
            catch (Exception ex)
            {
                ErrorEvent.Invoke(null, EventArgs.Empty);
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fileDialog.FileName;
            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputPath.Text = folderDialog.SelectedPath;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (btnRun.Text == "Go")
            {
                lblStatus.ForeColor = Color.Black;
                btnRun.Text = "Cancel";
                lblStatus.Text = "Creating Db";
                Task.Run(RunAsync);
            }
            else if (btnRun.Text == "Cancel")
            {
                lblStatus.Text = $"Attempting to stop processing. {Environment.NewLine}This may take a second.";
                PlansDBInterations.Cancel();
            }
            else
            {
                MessageBox.Show("Invalid button name. Contact the developer if you ever see this");
            }
        }

        
        private void ProcessErrorEvent(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => {
                    _stopwatch.Stop();
                    btnRun.Text = "Go";
                    lblStatus.ForeColor = Color.DarkRed;
                    lblStatus.Text = $"DB Generation Failed ({_stopwatch.Elapsed.ToString("mm")}m {_stopwatch.Elapsed.ToString("ss")}s)";
                    _stopwatch.Reset();
                }));
                return;
            }
        }

        private void EvaluationFile_CancelledEvent(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => {
                    _stopwatch.Stop();
                    btnRun.Text = "Go";
                    lblStatus.ForeColor = Color.DarkOrange;
                    lblStatus.Text = $"DB Generation Cancelled ({_stopwatch.Elapsed.ToString("mm")}m {_stopwatch.Elapsed.ToString("ss")}s)";
                    _stopwatch.Reset();
                }));
                return;
            }
        }

        private void EvaluationCompletedEvent(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => {
                    _stopwatch.Stop();
                    btnRun.Text = "Go";
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = $"Completed DB Generation({_stopwatch.Elapsed.ToString("mm")}m {_stopwatch.Elapsed.ToString("ss")}s)";
                    _stopwatch.Reset();
                }));
                return;
            }
        }

        private void StatusUpdatedEvent(object sender, EventArgs e)
        {
            if(InvokeRequired)
            {
                Invoke((Action)(() => {
                    lblStatus.Text = $"{sender}";
                }));
                return;
            }
        }

    }
}
