using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;
using WOW.Illustration.TestTools.ACORDModelSerializationTester.Properties;

namespace WOW.Illustration.TestTools.ACORDModelSerializationTester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void beginTestButton_Click(object sender, EventArgs e)
        {
            var sourceDirectory = testSamplesLocationTextBox.Text;
            var outputDirectory = outputLocationTextBox.Text;

            if (!Directory.Exists(sourceDirectory))
            {
                var message = string.Format(CultureInfo.InvariantCulture, Resources.SourceAccessErrorMessage, sourceDirectory);
                MessageBox.Show(this, message, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                try
                {
                    Directory.CreateDirectory(outputDirectory);
                }
                catch (Exception ex)
                {
                    var message = string.Format(CultureInfo.InvariantCulture, Resources.DestinationAccessErrorMessage, outputDirectory, ex.Message, ex.Source);
                    MessageBox.Show(this, message, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
                    return;
                }
            }

            Settings.Default.LastTestSampleLocation = sourceDirectory;
            Settings.Default.LastOutputLocation = outputDirectory;

            var files = Directory.GetFiles(sourceDirectory, "*.xml");

            var results = testSampleFiles(files, outputDirectory);

            if (string.IsNullOrEmpty(results))
            {
                MessageBox.Show(Resources.SuccessMessage, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
            }
            else
            {
                var message = string.Format(CultureInfo.InvariantCulture, Resources.SerializationErrorMessage, results);
                if (message.Length > 300)
                {
                    message = message.Substring(0, 300);
                }

                MessageBox.Show(message, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
            }
        }

        private void outputLocationButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (Directory.Exists(outputLocationTextBox.Text))
                {
                    dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                    dialog.SelectedPath = outputLocationTextBox.Text;
                }
                else if (Directory.Exists(Settings.Default.LastOutputLocation))
                {
                    dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                    dialog.SelectedPath = Settings.Default.LastOutputLocation;
                }
                else
                {
                    dialog.RootFolder = Environment.SpecialFolder.Desktop;
                }

                var result = dialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    outputLocationTextBox.Text = dialog.SelectedPath;
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private static string testSampleFiles(string[] files, string destinationFolder)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("FIP", "http://www.fiservinsurance.com/LPES/Base/OneView");
            namespaces.Add(string.Empty, "http://ACORD.org/Standards/Life/2");
            namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            
            foreach (var file in files)
            {
                try
                {
                    var txLife = new TXLife();
                    var reader = new XmlSerializer(typeof(TXLife));

                    using (var fileStream = XmlReader.Create(file))
                    {
                        txLife = (TXLife)reader.Deserialize(fileStream);
                    }

                    var outputFile = Path.Combine(destinationFolder, Path.GetFileName(file));

                    if (File.Exists(outputFile))
                    {
                        File.Delete(outputFile);
                    }

                    var settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.IndentChars = "\t";
                    var sbOut = new StringBuilder();
                    using (var fileStream = XmlWriter.Create(sbOut, settings))
                    {
                        reader.Serialize(fileStream, txLife, namespaces);
                    }
                    sbOut.Replace(" />", "/>");
                    sbOut.AppendLine();
                    File.WriteAllText(outputFile, sbOut.ToString());
                }
                catch (Exception ex)
                {
                    var message = string.Format(CultureInfo.InvariantCulture, Resources.ConversionErrorMessage, file, ex.Message);
                    sb.AppendLine(message);
                }
            }

            return sb.ToString();
        }

        private void testSamplesLocationButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (Directory.Exists(Settings.Default.LastTestSampleLocation))
                {
                    dialog.SelectedPath = Settings.Default.LastTestSampleLocation;
                }
                else
                {
                    dialog.RootFolder = Environment.SpecialFolder.Desktop;
                }

                var result = dialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    testSamplesLocationTextBox.Text = dialog.SelectedPath;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            testSamplesLocationTextBox.Text = Settings.Default.LastTestSampleLocation;
            outputLocationTextBox.Text = Settings.Default.LastOutputLocation;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
