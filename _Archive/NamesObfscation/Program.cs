using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;

namespace NamesObfscation
{
    class Program
    {
        static Regex re = new Regex(@"^([a-z_0-9]+)-([a-z_0-9]+)$", RegexOptions.IgnoreCase);
        static int RandomMax = 50000;

        static void Main(string[] args)
        {
            Console.WriteLine("\n\nRandomizer starting.......\n\n");
            if (args.Length != 1)
            {
                Console.WriteLine("Wrong number of arguments");
                Environment.ExitCode = 1;
                return;
            }
            if (!Directory.Exists(args[0]))
            {
                Console.WriteLine($"Inexistent folder {args[0]}");
                Environment.ExitCode = 1;
                return;
            }
            var files = Directory.GetFiles(args[0], "*.csv").Where(p => re.Match(Path.GetFileNameWithoutExtension(p)).Success);
            if (files.Count() == 0)
            {
                Console.WriteLine("No file to process in folder");
                Environment.ExitCode = 1;
                return;
            }
            foreach (var file in files)
            {
                if (!Randomize(file))
                {
                    Environment.ExitCode = 1;
                    return;
                }
            }

            Console.WriteLine("\nRandomization complete\n\n");
        }

        static bool Randomize(string file)
        {
            Console.WriteLine($"\nProcessing {file}");

            string text = new StreamReader(file).ReadToEnd();
            var arr = Regex.Split(text, @"\r\n");

            string filename = Path.GetFileNameWithoutExtension(file);
            string folder = Path.GetDirectoryName(file);

            Match m = re.Match(filename);
            if (!m.Success)
                throw new Exception("File name doesn't convey Table and Column name");

            string tablename = m.Groups[1].Value;
            string columnname = m.Groups[2].Value;

            int dim = arr.Length > RandomMax ? arr.Length : RandomMax;
            string outname = $"{folder}/{filename}.txt";

            var extractions = new int[dim];
            int assigned = 0;
            long tentatives = 0;

            var random = new Random();

            int randomNumber = random.Next(0, dim);
            tentatives++;

            int x, y;
            using (var sw = new StreamWriter(outname))
            {
                if (arr[0].ToLower() == columnname.ToLower())
                    x = 1;
                else
                    x = 0;
                y = x;
                for (; x < arr.Length - 1; x++)
                {
                    if (arr[x].Length > 0)
                    {
                        extractions[randomNumber] = x + 1;
                        sw.WriteLine($"{tablename}\t{columnname}\t{arr[x]}\t{randomNumber:00000}");
                        assigned++;
                        while (extractions[randomNumber] > 0)
                        {
                            randomNumber = random.Next(0, dim);
                            tentatives++;
                        }
                    }
                }
            }

            Console.WriteLine($"\n\tRandom number assigned:{assigned} on {arr.Length - y - 1}; Requested:{tentatives}");
            return true;
        }
    }
}
