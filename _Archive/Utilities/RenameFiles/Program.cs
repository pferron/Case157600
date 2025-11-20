using log4net;
using System;
using System.IO;

namespace RenameFiles
{
    internal static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        internal static void Main(string[] args)
        {
            var inputFolder = @"C:\Temp\DeleteMe\Split Fip Files\";
            var textFolder = @"C:\Temp\DeleteMe\IEW Output\";
            var renamedTextFolder = @"C:\Temp\DeleteMe\IEW Output renamed\";
            var files = Directory.GetFiles(inputFolder, "*.fip");

            foreach (var file in files)
            {
                var foundOutputLine = false;
                var lines = File.ReadAllLines(file);
                foreach (var line in lines)
                {
                    if (line.StartsWith("outputName", StringComparison.OrdinalIgnoreCase))
                    {
                        foundOutputLine = true;
                        var parts = line.Split(",".ToCharArray());
                        var name = parts[1].Trim() + ".txt";
                        var path = Path.Combine(textFolder, name);
                        var newName = Path.GetFileNameWithoutExtension(file) + ".txt";
                        var newPath = Path.Combine(renamedTextFolder, newName);

                        if (File.Exists(path))
                        {
                            File.Copy(path, newPath);
                            break;
                        }
                        else if (!File.Exists(newPath))
                        {
                            log.DebugFormat("Missing IEW File:\t{0}\t{1}", path, newPath);
                        }
                    }
                }

                if (!foundOutputLine)
                {
                    log.DebugFormat("Missing output line: {0}", file);
                }
            }
        }
    }
}
