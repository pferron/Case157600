using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HubIllustrationServiceTest
{
    class ExtractOneFipFromMany
    {
        private Regex re = new Regex(@"\[Illustration\]",RegexOptions.IgnoreCase);
        private string[] Illustrations;
        public ExtractOneFipFromMany(string name)
        {
            if (!File.Exists(name))
                throw new Exception("File doesn't exist");
            var sr = new StreamReader(name);
            string text = sr.ReadToEnd();
            Illustrations = re.Split(text);
        }
        public string Position(int idx)
        {
            if (idx == 0 || idx > Illustrations.Length + 1)
                throw new Exception("Requested document index not valid");
            return "[Illustration]\r\n" + Illustrations[idx];
        }
    }
}
