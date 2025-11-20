using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64Decoder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                HelpMessage();
                return;
            }

            // First arg should be path to text file containing Base64 string

            var inputFilePath = args[0];
            var outputFilePath = args[1];

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file was not found.");
                return;
            }

            if (File.Exists(outputFilePath))
            {
                Console.WriteLine("Overwrite existing file? Y/N");

                var result = Console.ReadKey(true);

                if (result.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Operation canceled.");
                    return;
                }
            }

            using (var reader = new StreamReader(inputFilePath))
            {
                // Make sure you read from the file or it won't be able
                // to guess the encoding
                var content = reader.ReadToEnd();

                byte[] filebytes = Convert.FromBase64String(content);

                using (var fs = new FileStream(outputFilePath,
                                               FileMode.Create,
                                               FileAccess.Write,
                                               FileShare.None))
                {
                    fs.Write(filebytes, 0, filebytes.Length);
                }
            }

            Console.WriteLine("Operation complete!");
        }

        private static void HelpMessage()
        {
            Console.WriteLine("This utility converts a Base64 string from a text file into a binary file.");
            Console.WriteLine("Arg1: Path to file containing Base64 string");
            Console.WriteLine("Arg2: Path to write binary file to");
        }
    }
}
