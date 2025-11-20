using ScatterBot.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ScatterBot
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Ping master server

            // Add server names to checkbox list
            txtMasterServer.Text = Settings.Default.MasterServer;
            txtMasterServer.Select(0, 0);

            var secondaryServers = Settings.Default.SecondaryServers.Split(',');

            foreach (var server in secondaryServers)
            {
                clstServerList.Items.Add(server, true);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!btnExecute.Enabled)
            {
                // This indicates that tasks are running against remote systems
                var msg = "Actions are being executed against remote systems. Are you sure you want to exit?";

                var result = MessageBox.Show(msg, "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
            }

            // Tasks aren't running, so go ahead a close
            Application.Exit();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            // Put this here to get a fresh executor instead of managing the internal task list
            var executor = new ScatterBotExecutor();
            executor.ExecutionStatusChanged += new EventHandler(HandleExecutionStatusChange);
            executor.ExecutionComplete += new EventHandler(HandleExecutionComplete);

            var actions = new List<ScatterBotAction>();

            foreach (var item in clstServerList.CheckedItems)
            {
                var hostname = item as string;

                if (!String.IsNullOrWhiteSpace(hostname))
                {
                    var action = new ScatterBotAction();

                    action.SourceHostname = txtMasterServer.Text;
                    action.TargetHostname = hostname;
                    action.UpdateAppServerVersion = chkAppServerVersion.Checked;
                    action.UpdateLifeServerVersion = chkLifeServerVersion.Checked;
                    action.UpdateWebServerVersion = chkWebServerVersion.Checked;
                    action.RestartServices = chkRestartServices.Checked;
                    action.DeployRsuPackage = chkSyncRSUFolders.Checked;
                    action.AppServiceName = Settings.Default.AppServiceName;
                    action.LifeServiceName = Settings.Default.LifeServiceName;

                    // Add assembled UNC file paths
                    action.SourceVersionFilePath = Path.Combine(@"\\" + action.SourceHostname, Settings.Default.AppServerVersionFilePath);
                    action.TargetAppVersionFilePath = Path.Combine(@"\\" + hostname, Settings.Default.AppServerVersionFilePath);
                    action.TargetLifeVersionFilePath = Path.Combine(@"\\" + hostname, Settings.Default.LifeServerVersionFilePath);
                    action.TargetWebVersionFilePath = Path.Combine(@"\\" + hostname, Settings.Default.WebServerVersionFilePath);

                    action.SourceRsuFolderPath = Path.Combine(@"\\" + action.SourceHostname, Settings.Default.RsuFolderPath);
                    action.TargetRsuFolderPath = Path.Combine(@"\\" + hostname, Settings.Default.RsuFolderPath);

                    actions.Add(action);
                }
            }

            if (actions.Count == 0)
            {
                txtOutput.Text += "No servers selected." + Environment.NewLine;
                return;
            }

            var msg = String.Format("Preparing to execute actions on {0} servers. Continue?", actions.Count);

            // Confirm actions
            var result = MessageBox.Show(msg, "Ready to Execute?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Prevent clicking twice
                btnExecute.Enabled = false;

                // Clear output and display start date and time
                txtOutput.Text = "Execution started at " + DateTime.Now.ToString("T") + Environment.NewLine;

                executor.ExecuteActions(actions);
            }
        }

        private void HandleExecutionStatusChange(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, ExecutionStatusChangedArgs>(HandleExecutionStatusChange), sender, e);
                return;
            }

            var args = (ExecutionStatusChangedArgs)e;

            switch (args.Status)
            {
                case ScatterBotExecutor.ExecutionStatus.None:
                    txtOutput.Text += "Action execution changed to 'None' or wasn't set. That's weird..." + Environment.NewLine;
                    break;
                case ScatterBotExecutor.ExecutionStatus.Executing:
                    txtOutput.Text += "Action executing: " + args.Message + Environment.NewLine;
                    break;
                case ScatterBotExecutor.ExecutionStatus.Success:
                    txtOutput.Text += "Action succeeded: " + args.Message + Environment.NewLine;
                    break;
                case ScatterBotExecutor.ExecutionStatus.Error:
                    txtOutput.Text += "Action failed: " + args.Message + Environment.NewLine;
                    break;
            }
        }

        private void HandleExecutionComplete(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, ExecutionCompleteArgs>(HandleExecutionComplete), sender, e);
                return;
            }

            btnExecute.Enabled = true;

            txtOutput.Text += "Execution ended at " + DateTime.Now.ToString("T") + Environment.NewLine;
        }
    }
}
