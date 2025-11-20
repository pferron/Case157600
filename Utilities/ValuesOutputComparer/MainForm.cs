using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WOW.Illustration.Utilities.ValuesFileParser;
using WOW.Illustration.Utilities.ValuesOutputComparer.Enums;
using WOW.Illustration.Utilities.ValuesOutputComparer.Properties;
using WOW.Illustration.ValuesModel;

namespace WOW.Illustration.Utilities.ValuesOutputComparer
{
    public partial class MainForm : Form
    {
        private SortedList<string, List<DifferencePair>> FileList = new SortedList<string, List<DifferencePair>>();
        private int FileDiffs = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var settings = Settings.Default;
            SetBounds(settings.MainFormLeft, settings.MainFormTop, settings.MainFormWidth, settings.MainFormHeight);
            txtSourceDirectory.Text = settings.LastDirectory;
            nudDecimalPlaces.Value = settings.DecimalPlaces;
            chkRelevantOnly.Checked = settings.ReleventOnly;
            chkExcludeLastColumnError.Checked = settings.ExcludeLastColumnErrors;
            chkReformatFiles.Checked = settings.ReformatFiles;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var settings = Settings.Default;

            settings.MainFormHeight = Height;
            settings.MainFormLeft = Left;
            settings.MainFormTop = Top;
            settings.MainFormWidth = Width;
            settings.DecimalPlaces = (int)nudDecimalPlaces.Value;
            settings.ReleventOnly = chkRelevantOnly.Checked;
            settings.ExcludeLastColumnErrors = chkExcludeLastColumnError.Checked;
            settings.ReformatFiles = chkReformatFiles.Checked;
            settings.Save();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            txtSourceDirectory.Text = SelectDirectory(txtSourceDirectory.Text);
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            try
            {
                btnCompare.Enabled = false;
                Enabled = false;
                Application.UseWaitCursor = true;
                Application.DoEvents();

                ProcessComparison(txtSourceDirectory.Text);

            }
            finally
            {
                btnCompare.Enabled = true;
                Enabled = true;
                Application.UseWaitCursor = false;
            }
        }

        private void lstFiles_SelectedValueChanged(object sender, EventArgs e)
        {
            var statusText = string.Empty;

            dgvResults.DataSource = null;
            if (lstFiles.SelectedItem != null)
            {
                var key = (string)lstFiles.SelectedItem;
                var diffLines = FileList[key];
                dgvResults.DataSource = System.Linq.Enumerable.ToList(diffLines);
                statusText = string.Format("{0} Differences Found: {1}", key, diffLines.Count);
            }
            pnlDetail.Text = statusText;
            staMainStatus.Refresh();
        }

        private SortedList<string, List<DifferencePair>> CompareFilePairs(List<Tuple<string, string>> filePairs)
        {
            IllustrationValue iewModel;
            IllustrationValue lpaModel;
            var diffList = new SortedList<string, List<DifferencePair>>();
            var index = 0;
            var filesProcessed = 0;
            var name = string.Empty;
            var reformatFiles = chkReformatFiles.Checked;

            var args = new FileComparer.ComparisonArguments();
            var tolerance = (nudDecimalPlaces.Value > 0 ? decimal.One : decimal.Zero);
            for (int i = 0; i < nudDecimalPlaces.Value; i++)
            {
                tolerance /= 10M;
            }

            args.DecimalTolerance = tolerance;
            args.RelevantValuesOnly = chkRelevantOnly.Checked;
            args.ExcludeLastColumnErrors = chkExcludeLastColumnError.Checked;

            FileDiffs = 0;
            foreach (var pair in filePairs)
            {
                if (pair.Item2.Length > 0)
                {
                    name = Path.GetFileNameWithoutExtension(pair.Item2);
                }
                else
                {
                    name = Path.GetFileNameWithoutExtension(pair.Item1);
                }

                iewModel = LoadModel(reformatFiles, args.RelevantValuesOnly, pair.Item1);
                lpaModel = LoadModel(reformatFiles, args.RelevantValuesOnly, pair.Item2);

                args.ProductType = GetProductType(pair);

                var diffs = FileComparer.Compare(iewModel, lpaModel, args);

                if (diffs.Count > 0)
                {
                    FileDiffs++;
                    name = "*" + name;
                }

                if (diffList.ContainsKey(name))
                {
                    name = string.Format("{0}_{1:d2}", name, ++index);
                }
                else
                {
                    index = 0;
                }
                diffList.Add(name, diffs);
                filesProcessed++;
                pnlDetail.Text = string.Format("Files Compared: {0}", filesProcessed);
                staMainStatus.Refresh();
            }

            return diffList;
        }

        private static IllustrationValue LoadModel(bool reformatFiles, bool relevantOnly, string fileName)
        {
            const int LabelLength = 30;

            IllustrationValue iewModel;
            if (fileName.Length > 0)
            {
                iewModel = FileParser.ParseFile(fileName, LabelLength);
                if (reformatFiles)
                {
                    var newFile = fileName + ".orig";
                    if (File.Exists(newFile))
                    {
                        File.Delete(fileName);
                    }
                    else
                    {
                        File.Move(fileName, newFile);
                    }
                    var content = ValuesFileFormatter.Format(iewModel, LabelLength, relevantOnly);
                    File.WriteAllText(fileName, content);
                }
            }
            else
            {
                iewModel = new IllustrationValue();
            }
            return iewModel;
        }

        private ProductType GetProductType(Tuple<string, string> pair)
        {
            var file = pair.Item1;
            if (string.IsNullOrWhiteSpace(file))
            {
                file = pair.Item2;
            }

            var parts = Path.GetFileNameWithoutExtension(file).Split('_');
            ProductType type;

            var fipFileName = parts[0] + "_" + parts[1] + "*.fip";

            var files = Directory.GetFiles(Path.GetDirectoryName(file), fipFileName);
            var headerCode = HeaderCode.None;

            var lines = File.ReadAllLines(files[0]);
            foreach (var line in lines)
            {
                if (line.StartsWith("HeaderCode"))
                {
                    parts = line.Split(',');
                    var code = int.Parse(parts[1]);
                    headerCode = (HeaderCode)code;
                    break;
                }
            }

            switch (headerCode)
            {
                case HeaderCode.NoLapse:                //DB driven eligible
                case HeaderCode.NoLapseWorksite:
                    type = ProductType.NoLapse;
                    break;
                case HeaderCode.AccumulatedUniversalLife:
                case HeaderCode.AccumulatedUniversalLifeWorksite:
                    type = ProductType.AccumulatedUniversalLife;
                    break;
                case HeaderCode.WholeLifeRegularAppPaidUpAtAge100:
                case HeaderCode.WholeLifeRegularAppPaidUpAt65:
                case HeaderCode.WholeLifeRegularApp20Pay:
                case HeaderCode.WholeLifeRegularAppSinglePremium:
                case HeaderCode.WholeLifeEZAppPaidUpAt100:
                case HeaderCode.WholeLifeEZAppPaidUpAt65:
                case HeaderCode.WholeLifeEZApp20Pay:
                case HeaderCode.WholeLifeEZAppSinglePremium:
                case HeaderCode.WholeLifeLP100ConversionApplication:
                case HeaderCode.WholeLifeRegularAppUnisexPaidUpAt100:
                case HeaderCode.WholeLifeEZAppUnisexPaidUpAt100:
                case HeaderCode.WholeLifeUnisexLP100ConversionApplication:
                case HeaderCode.BlueWhitePaidUpAt100:
                case HeaderCode.BlueWhitePaidUpAt65:
                case HeaderCode.BlueWhite20Pay:
                case HeaderCode.BlueWhiteSinglePremium:
                case HeaderCode.BlueWhiteUnisexPaidUpAt100:
                case HeaderCode.WorksitePaidUpAt100:
                case HeaderCode.WorksitePaidUpAt65:
                    type = ProductType.WholeLife;
                    break;
                case HeaderCode.RedPaidUpAt100:
                case HeaderCode.RedUnisexPaidUpAt100:
                    type = ProductType.Red;
                    break;
                case HeaderCode.TermBaseLevel10Year:
                case HeaderCode.TermBaseLevel15Year:
                case HeaderCode.TermBaseLevel20Year:
                case HeaderCode.TermWorksiteBaseLevel20Year:
                case HeaderCode.TermBaseLevel30Year:
                case HeaderCode.TermWorksiteBaseLevel30Year:
                    type = ProductType.Term;
                    break;
                case HeaderCode.FamilyTerm:
                    type = ProductType.FamilyTerm;
                    break;
                case HeaderCode.TermBaseLevelYouthWithAcceleratedDeathBenefit:
                    type = ProductType.YouthTerm;
                    break;
                case HeaderCode.FixedAnnuityFlexiblePremiumDeferredAnnuityNonBonus:
                case HeaderCode.FixedAnnuityFlexiblePremiumDeferredAnnuityBonus:
                case HeaderCode.FixedAnnuitySinglePremiumDeferredAnnuityNonBonus:
                case HeaderCode.FixedAnnuitySinglePremiumDeferredAnnuityBonus:
                    type = ProductType.FixedAnnuity;
                    break;
                default:
                    type = 0;
                    break;
            }

            return type;
        }


        private void LoadControls()
        {
            lstFiles.DataSource = null;
            dgvResults.DataSource = null;
            if (FileList.Count == 0)
            {
                var dummyItem = new DifferencePair(Resources.DefaultDifferenceItem, string.Empty, string.Empty);
                var dummyList = new List<DifferencePair>();
                dummyList.Add(dummyItem);

                FileList.Add(Resources.DefaultFileName, dummyList);

                pnlStatus.Text = string.Format("No files found");
                staMainStatus.Refresh();
            }
            else
            {
                pnlStatus.Text = string.Format("Total Files: {0} With Diffs: {1}", FileList.Count, FileDiffs);
                staMainStatus.Refresh();
            }

            lstFiles.DataSource = System.Linq.Enumerable.ToList(FileList.Keys);
        }


        private List<Tuple<string, string>> LoadFilePairs(string directory)
        {
            var fileList = new List<Tuple<string, string>>();

            if (!Directory.Exists(directory))
            {
                var message = string.Format(Resources.InvalidDirectoryMessage, directory);
                MessageBox.Show(this, message, Resources.InvalidDirectoryTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return fileList;
            }

            var files = Directory.GetFiles(directory, "Illus*.txt");

            Array.Sort<string>(files);
            var lastIewName = string.Empty;
            var lastIewFile = string.Empty;

            for (int i = 0; i < files.Length - 1; i++)
            {
                var iewFile = files[i];
                var lpaFile = files[i + 1];

                var iewName = Path.GetFileNameWithoutExtension(iewFile);
                var lpaName = Path.GetFileNameWithoutExtension(lpaFile);

                if (lpaName.StartsWith(iewName, StringComparison.OrdinalIgnoreCase))
                {
                    i++;
                }
                else if (iewName.Contains("RMM") && lpaName.Contains("RMM"))
                {
                    var temp = iewFile;
                    iewFile = lpaFile;
                    lpaFile = temp;

                    temp = iewName;
                    iewName = lpaName;
                    lpaName = temp;
                    i++;

                }
                else if (iewName.StartsWith(lastIewName))
                {
                    lpaFile = iewFile;
                    lpaName = iewName;
                    iewFile = lastIewFile;
                    iewName = lastIewName;
                }
                else
                {
                    lpaFile = string.Empty;
                }

                var tuple = new Tuple<string, string>(iewFile, lpaFile);
                lastIewName = iewName;
                lastIewFile = iewFile;
                fileList.Add(tuple);
            }

            return fileList;
        }

        private void ProcessComparison(string directory)
        {
            pnlStatus.Text = "Loading files";
            pnlDetail.Text = string.Empty;
            staMainStatus.Refresh();
            var filePairs = LoadFilePairs(directory);
            pnlStatus.Text = string.Format("Comparing {0} files", filePairs.Count);
            staMainStatus.Refresh();
            FileList = CompareFilePairs(filePairs);

            Settings.Default.LastDirectory = txtSourceDirectory.Text;
            pnlStatus.Text = "Loading controls";
            staMainStatus.Refresh();
            LoadControls();
            btnExport.Enabled = true;
        }

        private static string SelectDirectory(string initialDirectory)
        {
            var directory = string.Empty;

            using (var browseDialog = new FolderBrowserDialog())
            {
                if (!string.IsNullOrEmpty(initialDirectory))
                {
                    browseDialog.SelectedPath = initialDirectory;
                }

                browseDialog.Description = "Select Source Directory";

                if (browseDialog.ShowDialog() == DialogResult.OK)
                {
                    directory = browseDialog.SelectedPath;
                }
            }

            return directory;
        }

        private void lstFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstFiles.SelectedItem != null)
            {
                var name = ((string)lstFiles.SelectedItem).Trim('*');
                var parts = name.Split(new char[] { '_' }, 3);
                if (parts.Length > 1)
                {
                    name = parts[0] + "_" + parts[1] + "*.txt";
                    var files = Directory.GetFiles(Settings.Default.LastDirectory, name);

                    foreach (var file in files)
                    {
                        Process.Start(file);
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var orderedList = ReorderList();

            var sb = new StringBuilder();

            foreach (var pair in orderedList)
            {
                sb.AppendLine(pair.Item1);
                foreach (var item in pair.Item2)
                {
                    var message = string.Format("{0}, {1}, {2}", item.Name, item.IEW, item.LPA);
                    sb.AppendLine(message);
                }
                sb.AppendLine();
            }

            var fileName = string.Format("Export_{0:yyyyMMdd-HHmmss}.txt", DateTime.Now);
            var path = Path.Combine(txtSourceDirectory.Text, fileName);

            File.WriteAllText(path, sb.ToString());

            var text = string.Format("File Exported to:\n{0}", path);
            MessageBox.Show(text, "Export Results", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0);
        }

        private List<Tuple<string, List<DifferencePair>>> ReorderList()
        {
            var list = new List<Tuple<string, List<DifferencePair>>>();

            foreach (var pair in FileList)
            {
                var tuple = new Tuple<string, List<DifferencePair>>(pair.Key, pair.Value);
                list.Add(tuple);
            }
            var comparer = new ListComparer();
            list.Sort(comparer);
            return list;
        }
    }

    public class ListComparer : IComparer<Tuple<string, List<DifferencePair>>>
    {

        public int Compare(Tuple<string, List<DifferencePair>> x, Tuple<string, List<DifferencePair>> y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            var xName = x.Item1;
            var xParts = xName.Split("_".ToCharArray());
            var yName = y.Item1;
            var yParts = yName.Split("_".ToCharArray());

            var diff = xParts.Length.CompareTo(yParts.Length);
            if (diff == 0)
            {
                var index = xParts.Length - 1;
                if (index > 3) index = 3;

                diff = xParts[index].CompareTo(yParts[index]);
                if (diff == 0)
                {
                    index--;
                    diff = xParts[index].CompareTo(yParts[index]);
                    if (diff == 0)
                    {
                        index--;
                        diff = xParts[index].CompareTo(yParts[index]);
                        if (diff == 0)
                        {
                            diff = xName.CompareTo(yName);
                        }
                    }
                }
            }

            return diff;
        }
    }
}
