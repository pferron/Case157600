using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SoftwareLF.Helpers
{
    public class ConsoleLog
    {
        private StreamWriter _sw;
        public ConsoleLog(StreamWriter sw, bool out2console = true)
        {
            _sw = sw;
            OutputToConsole = out2console;
            wwidth = 80;
        }
        public ConsoleLog(string HomeDir, string pgmname, bool out2console = true)
        {
            string LOGFN = string.Format("{0}#.log",pgmname);
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string logfilename = Path.Combine(HomeDir, LOGFN).Replace("#", "_" + timestamp);
            _sw = new StreamWriter(logfilename);
            OutputToConsole = out2console;
            wwidth = 80;
        }
        public bool OutputToConsole { get; set; }
        private int wwidth = 80;
        internal int WindowWidth
        {
            get { return wwidth; }
            set
            {
                if (value > wwidth)
                    wwidth = value;
            }
        }
        public void Log(string template, params object[] prm)
        {
            try
            {
                _sw.WriteLine(template, prm);
            }
            catch (Exception ex)
            {
                if (prm.Length == 0)
                {
                    template = template.Replace("{", "{{").Replace("}", "}}");
                    _sw.WriteLine(template, prm);
                }
                else
                    throw ex;
            }
            if (OutputToConsole)
            {
                var str = string.Format(template, prm);
                Console.WriteLine(str);
            }
            if (template.ToLower().Contains("any key to close"))
            {
                _sw.Close();
                Console.ReadKey();
            }
        }
    }
}
