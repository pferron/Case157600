using log4net;
using System.IO;
using WOW.Illustration.TestTools.IllustrationValuesModelTester.Properties;
using WOW.Illustration.Utilities.ValuesFileParser;
using WOW.Illustration.ValuesModel;

namespace WOW.Illustration.TestTools.IllustrationValuesModelTester
{
    internal class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        internal static void Main()
        {
            const int LabelLength = 30;
            var files = Directory.GetFiles(Settings.Default.InputDirectory, "Illus*.txt");

            if (!Directory.Exists(Settings.Default.OutputDirectory))
            {
                Directory.CreateDirectory(Settings.Default.OutputDirectory);
            }

            foreach (var file in files)
            {
                var model = FileParser.ParseFile(file, LabelLength);
                var formattedText = ValuesFileFormatter.Format(model, LabelLength);

                var fileName = Path.GetFileName(file);
                var path = Path.Combine(Settings.Default.OutputDirectory, fileName);
                File.WriteAllText(path, formattedText);
            }
        }
    }
}
