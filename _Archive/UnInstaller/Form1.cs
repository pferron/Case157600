using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Management;
using System.Collections;

namespace uninstall
{
    public partial class Form1 : Form
    {

        BackgroundWorker bw_AppLister = null;

        public Form1()
        {
            InitializeComponent();

            bw_AppLister = new BackgroundWorker();
           
            //create our background worker event handlers
            //bw_AppLister.DoWork+=new DoWorkEventHandler(bw_AppLister_DoWork);
            //bw_AppLister.RunWorkerCompleted+=new RunWorkerCompletedEventHandler(bw_AppLister_RunWorkerCompleted);

        }
        private List<string> providers = new List<string>() { "Win32_Product",
                                                              "Win32_InstalledWin32Program" };
        private void Form1_Load(object sender, EventArgs e)
        {
            EnableUI(false);
            //display all installed applications asynchronously
            lbProviders.DataSource = providers;
            if (providers.Count > 0)
            {
                //WMI_Query = $"Select * from {lbProviders.SelectedItem}";
                lbProviders.SelectedIndex = 0;
            }
            //btnUninstall.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //display all installed applications asynchronously
            ListProgramsAsync();
        }

        private string WMI_Query;
        private async void btnUninstall_Click(object sender, EventArgs e)
        {
            EnableUI(false);
            int index = lvInstalled.SelectedIndices[0];
            string name = lvInstalled.Items[index].Text;
            var result = MessageBox.Show(string.Format("You serious ?\n\nDo you really want to uninstall {0} ?\n\nThink twice !", name),
                                         "Request to Uninstall",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Application.UseWaitCursor = true;
                    lbProviders.Enabled = false;
                    bool UninstallIsOK = await Task.Run(() => UninstallProgram(name));
                    if (UninstallIsOK)
                    {
                        MessageBox.Show(name + " was uninstalled!");
                        lvInstalled.Items.Remove(lvInstalled.Items[index]);
                        btnRefresh.Enabled = true;
                        lbProviders.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Error uninstalling " + name);
                        btnRefresh.Enabled = true;
                        lbProviders.Enabled = true;
                    }
                    Application.UseWaitCursor = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unistalling Exception: {0}", ex.ToString());
                    btnRefresh.Enabled = true;
                    lbProviders.Enabled = true;
                }
            }
            else
            {
                lvInstalled.SelectedItems.Clear();
                btnRefresh.Enabled = true;
            }
        }

        #region "Methods"

        private void EnableUI(bool enable)
        {
            this.btnRefresh.Enabled = enable;
            this.btnUninstall.Enabled = enable;
        }

        /// <summary>
        /// asynchronous method
        /// </summary>
        private async void ListProgramsAsync()
        {
            //is backgroundworker running?
            //if (bw_AppLister.IsBusy)
            //    return;

            lvInstalled.Items.Clear();
            lvInstalled.Items.Add("Collecting applications, Please wait...");
            //Thread.Sleep(500);
            //lock controls
            EnableUI(false);

            //Application.DoEvents();
            //start the asynchronous method
            //this.bw_AppLister.RunWorkerAsync();

            lbProviders.Enabled = false;
            Application.UseWaitCursor = true;
            var programs = await Task.Run(() => ListPrograms());
            Application.UseWaitCursor = false;

            lvInstalled.Items.Clear();
            foreach (object item in programs)
            {
                lvInstalled.Items.Add(item.ToString());
            }
            if (lvInstalled.Items.Count == 0)
            {
                Thread.Sleep(500);
                lvInstalled.Items.Add("");
                lvInstalled.Items.Add("    **** No item found for the selected Provider");
            }
            btnRefresh.Enabled = true;
            lbProviders.Enabled = true;
        }
        private Dictionary<string, List<ManagementObject>> programs;
        private List<string> ListPrograms()
        {
            programs = new Dictionary<string, List<ManagementObject>>();
            try
            {
                //query to get all installed products
                //ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
                ManagementObjectSearcher mos = new ManagementObjectSearcher(WMI_Query);
                foreach (ManagementObject mo in mos.Get())
                {
                    //more properties:
                    //http://msdn.microsoft.com/en-us/library/windows/desktop/aa394378(v=vs.85).aspx
                    string name, version;
                    try
                    {
                        name = mo["Name"].ToString();
                    }
                    catch
                    {
                        continue;
                    }
                    try
                    {
                        version = mo["Version"].ToString();
                    }
                    catch
                    {
                        version = string.Empty;
                    }
                    string program = name + (version != string.Empty ? $" - ver. {version}" : string.Empty);
                    if (!programs.ContainsKey(program))
                        programs.Add(program, new List<ManagementObject>() { mo });
                    else
                        programs[program].Add(mo);
                }
                return programs.Keys.ToList<string>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception issued while collecting installed products: " + ex.ToString());
                return programs.Keys.ToList<string>();
            }
        }
        private Regex re = new Regex(@"^(?'name'.+?)( - ver\. (?'version'.+))?$",RegexOptions.Compiled);
        private bool UninstallProgram(string ProgramName)
        {
            string name, version = string.Empty;
            var m = re.Match(ProgramName);
            if (m.Success)
            {
                name = m.Groups["name"].Value;
                version = m.Groups["version"].Value;
            }
            else
                throw new Exception("Name / Version Parsing Error");
            try
            {
                //load the query string
                //string query = WMI_Query + $" WHERE Name = '{name}'";
                //if (version.Length > 0)
                //    query += $" and version = '{version}'";
                //ManagementObjectSearcher mos = new ManagementObjectSearcher(query);
                ////get the specified proram(s)
                var coll = programs[ProgramName];
                //string appendix = coll.Count > 1 ? $"\n\nThere are {coll.Count} elements to uninstall" : "";
                //DialogResult res = MessageBox.Show($"Last chance to rethink !\n\nDo you really want to uninstall ?{appendix}",
                //                                   "Before UnInstalling",
                //                                   MessageBoxButtons.OKCancel,
                //                                   MessageBoxIcon.Warning);
                //if (res == DialogResult.OK)
                //{
                //}
                foreach (ManagementObject mo in coll)       
                {
                    //make sure that we are uninstalling the correct application
                    if (mo["Name"].ToString() == name)
                        if (version != string.Empty && mo["version"].ToString() == version)
                        {
                            //call to Win32_Product Uninstall method, no parameters needed
                            uint hr = (uint)mo.InvokeMethod("Uninstall", null);
                            if (hr != 0) return false;
                        }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region "BackgroundWorker"

        private void bw_AppLister_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> programs = ListPrograms();
            //pass the results to RunWorkerCompleted
            e.Result = programs;
        }

        private void bw_AppLister_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lvInstalled.Items.Clear();
            //cast the object result to IEnumerable, this will cast the result object to an enumerable object
            IEnumerable enumerable = e.Result as IEnumerable;
            foreach (object item in enumerable)
            {
                lvInstalled.Items.Add(item.ToString());
            }
            if (lvInstalled.Items.Count == 0)
            {
                lvInstalled.Items.Add("");
                lvInstalled.Items.Add("    **** No item found for the selected Provider");
            }
            btnRefresh.Enabled = true;
        }

        #endregion

        private void lvInstalled_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvInstalled.SelectedItems.Count > 0)
            {
                WMI_Query = $"Select * from {lbProviders.SelectedItem}";
                btnUninstall.Enabled = true;
            }
        }

        private void lbProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            WMI_Query = $"Select * from {lbProviders.SelectedItem}";
            EnableUI(false);
            lbProviders.Enabled = false;
            ListProgramsAsync();
        }
    }
}
