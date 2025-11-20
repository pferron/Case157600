using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FipAnalyzerDeluxe
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseApp();
        }

        private void CloseApp()
        {
            Application.Exit();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ScanFolder();
        }

        private void ScanFolder()
        {
            // Validate that text contains valid folder path
            if (!Directory.Exists(txtFolderPath.Text))
            {
                MessageBox.Show("Please select a valid folder path.", "Invalid Folder Path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            // Get the selected options
            var selectedIllustrationType = IllustrationOptions.IllustrationType.Any;
            Enum.TryParse<IllustrationOptions.IllustrationType>(cboIllustrationType.SelectedValue.ToString(), out selectedIllustrationType);

            var selectedRatingClass = IllustrationOptions.RatingClass.Any;
            Enum.TryParse<IllustrationOptions.RatingClass>(cboRatingClass.SelectedValue.ToString(), out selectedRatingClass);

            var selectedBillType = IllustrationOptions.BillType.Any;
            Enum.TryParse<IllustrationOptions.BillType>(cboBillType.SelectedValue.ToString(), out selectedBillType);

            var selectedBillMode = IllustrationOptions.BillMode.Any;
            Enum.TryParse<IllustrationOptions.BillMode>(cboBillMode.SelectedValue.ToString(), out selectedBillMode);

            var selectedProductType = IllustrationOptions.ProductType.Any;
            Enum.TryParse<IllustrationOptions.ProductType>(cboProductType.SelectedValue.ToString(), out selectedProductType);

            var selectedSignedState = IllustrationOptions.SignedState.Any;
            Enum.TryParse<IllustrationOptions.SignedState>(cboSignedState.SelectedValue.ToString(), out selectedSignedState);

            var selectedAgeGroup = IllustrationOptions.AgeGroup.Any;
            Enum.TryParse<IllustrationOptions.AgeGroup>(cboAgeGroup.SelectedValue.ToString(), out selectedAgeGroup);

            // Create configuration object
            var config = new SearchConfig();
            config.RatingClass = selectedRatingClass;
            config.IllustrationType = selectedIllustrationType;
            config.ProductType = selectedProductType;
            config.BillMode = selectedBillMode;
            config.BillType = selectedBillType;

            config.IncludeTableRated = chkTableRating.Checked;
            config.IncludeFlatExtra = chkFlatExtra.Checked;

            config.SignedState = selectedSignedState;
            config.AgeGroup = selectedAgeGroup;

            config.IncludeCostBenefit = chkCostBenefit.Checked;

            config.IncludeAcceleratedBenefit = chkListRiders.CheckedIndices.Contains(0);
            config.IncludeAccidentalDeath = chkListRiders.CheckedIndices.Contains(1);
            config.IncludeWaiverOfPremium = chkListRiders.CheckedIndices.Contains(2);
            config.IncludeApplicantWaiver = chkListRiders.CheckedIndices.Contains(3);

            config.IncludeDividendOptionCash = chkListDividendOptions.CheckedIndices.Contains(0);
            config.IncludeDividendOptionLeftWithWoodmen = chkListDividendOptions.CheckedIndices.Contains(1);
            config.IncludeDividendOptionReducePremiums = chkListDividendOptions.CheckedIndices.Contains(2);
            config.IncludeDividendOptionPaidUpAdditional = chkListDividendOptions.CheckedIndices.Contains(3);

            // Pass configuration object to backend method
            var results = StartSearch(config);

            LoadGrid(results);

            // Use returned results to populate a grid
            if (!results.Any())
            {
                MessageBox.Show("No files found matching the selected criteria.", "No Match", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadGrid(List<string> results)
        {
            //dataResults.Rows.Clear();

            dataResults.DataSource = results.Select(x => new { File = x }).ToList();

            tabControl.SelectedTab = tabResults;
        }

        private List<string> StartSearch(SearchConfig config)
        {
            var results = new List<string>();

            var dir = new DirectoryInfo(txtFolderPath.Text);
            var fipFiles = dir.GetFiles("*.fip");

            foreach (var fipFileInfo in fipFiles)
            {
                var fipFileObj = new FipFile(fipFileInfo);

                if (fipFileObj.Matches(config))
                {
                    results.Add(fipFileInfo.Name);
                }
            }

            lblResultCount.Text = String.Format("Files Found: {0}", results.Count);

            return results;
        }

        private bool ContainsRatingClass(FileInfo file)
        {
            return true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ClearLabels();
            LoadProductTypes();
            LoadIllustrationTypes();
            LoadRatingClasses();
            LoadBillTypes();
            LoadBillModes();
            LoadStates();
            LoadAgeGroups();

            txtFolderPath.Focus();
        }

        private void LoadAgeGroups()
        {
            cboAgeGroup.DataSource = Enum.GetValues(typeof(IllustrationOptions.AgeGroup));
            cboAgeGroup.SelectedIndex = 0;
        }

        private void LoadStates()
        {
            cboSignedState.DataSource = Enum.GetValues(typeof(IllustrationOptions.SignedState));
            cboSignedState.SelectedIndex = 0;
        }

        private void LoadProductTypes()
        {
            cboProductType.DataSource = Enum.GetValues(typeof(IllustrationOptions.ProductType));
            cboProductType.SelectedIndex = 0;
        }

        private void ClearLabels()
        {
            lblResultCount.Text = String.Empty;
            lblFipCount.Text = String.Empty;
        }

        private void LoadBillModes()
        {
            cboBillMode.DataSource = Enum.GetValues(typeof(IllustrationOptions.BillMode));
            cboBillMode.SelectedIndex = 0;
        }

        private void LoadBillTypes()
        {
            cboBillType.DataSource = Enum.GetValues(typeof(IllustrationOptions.BillType));
            cboBillType.SelectedIndex = 0;
        }

        private void LoadIllustrationTypes()
        {
            cboIllustrationType.DataSource = Enum.GetValues(typeof(IllustrationOptions.IllustrationType));
            cboIllustrationType.SelectedIndex = 0;
        }

        private void LoadRatingClasses()
        {
            cboRatingClass.DataSource = Enum.GetValues(typeof(IllustrationOptions.RatingClass));
            cboRatingClass.SelectedIndex = 0;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtFolderPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void txtFolderPath_TextChanged(object sender, EventArgs e)
        {
            int fipCount = 0;

            if (!String.IsNullOrWhiteSpace(txtFolderPath.Text) && Directory.Exists(txtFolderPath.Text))
            {
                fipCount = Directory.EnumerateFiles(txtFolderPath.Text, "*.fip").Count();
            }

            lblFipCount.Text = String.Format("FIP Files Found: {0}", fipCount);
        }

        private void dataResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var filename = dataResults.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            var filePath = Path.Combine(txtFolderPath.Text, filename);

            try
            {
                System.Diagnostics.Process.Start(filePath);
            }
            catch
            {
                MessageBox.Show(String.Format("Could not open file '{0}'.", filename), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
