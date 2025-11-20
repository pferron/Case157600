using log4net;
using ResetUpdates.Code;
using ResetUpdates.Properties;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ResetUpdates
{
    public partial class frmMain : Form
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(frmMain));

        [DllImport("shell32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsUserAnAdmin();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsUserAnAdmin())
                {
                    MessageBox.Show("This application requires elevated access. Please execute as Administrator.", "Extra Priviledges Required", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
                
                // Read current ver file
                using (var sr = new StreamReader(Settings.Default.VersionFilePath))
                {
                    txtDetectedVersionNumber.Text = sr.ReadLine().Trim();
                    txtNewVersionNumber.Text = txtDetectedVersionNumber.Text;
                }

                if (!Directory.Exists(Settings.Default.LocalDbInstancesFolderPath))
                {
                    MessageBox.Show("System Profile LocalDB Instances folder is missing or inaccessible. The 'Delete LocalDB Instances' option may not work without running the tool as SYSTEM.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chkDeleteDbInstances.Checked = false;
                    chkDeleteDbInstances.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) logger.Error("Error loading form", ex);
                MessageBox.Show("Error initializing application.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNewVersionNumber.Text))
            {
                MessageBox.Show("Version number cannot be blank.", "Bad Version Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Stop services
            ServicesHelper.StopService("localhost", Settings.Default.LifeManagerServiceName);
            ServicesHelper.StopService("localhost", Settings.Default.LifePortraitsServiceName);

            // Set version file to user input
            using (var sw = new StreamWriter(Settings.Default.VersionFilePath, false))
            {
                sw.Write(txtNewVersionNumber.Text);
            }

            if (chkDeleteRsuFiles.Checked)
            {
                // delete files and folders
                Delete(Settings.Default.RsuApplicationsFolderPath);
                Delete(Settings.Default.RsuDownloadFolderPath);
                Delete(Settings.Default.RsuRegistryFolderPath);
            }

            if(chkDeleteDbInstances.Checked)
            {
                Delete(Settings.Default.LocalDbInstancesFolderPath);
            }

            // start services
            ServicesHelper.StartService("localhost", Settings.Default.LifeManagerServiceName);
            ServicesHelper.StartService("localhost", Settings.Default.LifePortraitsServiceName);

            // Re-read current ver file
            using (var sr = new StreamReader(Settings.Default.VersionFilePath))
            {
                txtDetectedVersionNumber.Text = sr.ReadLine().Trim();
            }

            MessageBox.Show("RSU Reset Complete!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Delete(string folderPath)
        {
            try
            {
                var dirObj = new DirectoryInfo(folderPath);

                if(dirObj.Exists)
                {
                    dirObj.GetDirectories().ToList().ForEach(d => d.Delete(true));
                    dirObj.GetFiles().ToList().ForEach(f => f.Delete());
                }
                else
                {
                    if (logger.IsWarnEnabled) logger.Warn($"Folder '{folderPath}' does not exist. Skipping delete.");
                }
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) logger.Error(string.Format(CultureInfo.InvariantCulture, "Error deleting files and folders under '{0}'.", folderPath), ex);
                throw;
            }
        }
    }
}
