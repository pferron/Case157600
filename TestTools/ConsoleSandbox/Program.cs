using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WOW.Illustration.Model.Generation.Request;
using WOW.Illustration.Model.Generation.Response;

namespace ConsoleSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 3)
            {
                Console.WriteLine("Arg1: Input file, list of strings to search for");
                Console.WriteLine("Arg2: Folder path, folder to recursively search");
                Console.WriteLine("Arg3: File mask, ex. *.txt");
                Console.WriteLine("Search is not case sensitive");
                Console.WriteLine("First file where term is found is returned");

                return;
            }

            var inputFile = args[0];
            var targetFolder = args[1];
            var fileMask = args[2];

            var rootFolder = new DirectoryInfo(targetFolder);

            // Load search terms
            var termList = new List<SearchTerm>();
            var terms = File.ReadAllLines(inputFile);

            foreach(var term in terms)
            {
                termList.Add(new SearchTerm(term));
            }

            foreach(var term in termList)
            {
                Console.WriteLine($"Searching for {term.Term}...");

                SearchFiles(term, rootFolder, fileMask);
            }

            termList.Sort((term1, term2) => term1.Found.CompareTo(term2.Found));

            foreach (var term in termList)
            {
                if(term.Found)
                {
                    Console.WriteLine($"Term '{term.Term}' FOUND.");

                    foreach(var file in term.Files)
                    {
                        Console.WriteLine($"Found in {file}");
                    }
                }
                else
                {
                    Console.WriteLine($"Term '{term.Term}' NOT FOUND.");
                }
            }
        }

        private static void SearchFiles(SearchTerm termObj, DirectoryInfo dir, string pattern)
        {
            foreach (var file in dir.GetFiles(pattern))
            {
                var content = File.ReadAllText(file.FullName);

                if(content.IndexOf(termObj.Term, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    termObj.Found = true;
                    termObj.Files.Add(file.FullName);
                }
            }

            foreach (var folder in dir.GetDirectories())
            {
                SearchFiles(termObj, folder, pattern);
            }
        }
    }

    class SearchTerm
    {
        public SearchTerm(string term)
        {
            Term = term;
            Found = false;
            Files = new List<string>();
        }

        public string Term { get; set; }
        public bool Found { get; set; }

        public List<string> Files { get; }
    }
}
