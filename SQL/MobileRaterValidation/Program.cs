using log4net;
using System;
using System.IO;

namespace WOW.Illustration.MobileRaterValidation
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main()
        {
            var path = @"..\..\Individual Product Scripts";

            path = Path.GetFullPath(path);
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Could not find path: {path}");
                Console.ReadKey();
                return;
            }

            var files = Directory.GetFiles(path, "*.sql");

            foreach (var file in files)
            {
                var rc = new RatingClassValidator(file);
                rc.Initialize();

                var age = new InsuredAgeValidator(file);
                age.Initialize();

                var face = new FaceAmountValidator(file);
                face.Initialize();

                var state = new StateGroupValidator(file);
                state.Initialize();

                var lines = File.ReadAllLines(file);
                foreach (var line in lines)
                {
                    rc.ProcessLine(line);
                    age.ProcessLine(line);
                    face.ProcessLine(line);
                    state.ProcessLine(line);
                }

                rc.CheckForUnusedValues();
                age.CheckForUnusedValues();
                face.CheckForUnusedValues();
                state.CheckForUnusedValues();
            }
        }
    }
}
