using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SoftwareLF.Helpers
{
    static internal class ConsoleWindowSize
    {
        static internal string Set(IEnumerable<FileInfo> InputList, out int WindowWidth)
        {
            // determine size of cmd window
            var names = new List<string>();
            foreach (var fn in InputList)
                   names.Add( fn.Name);
            WindowWidth = 0;
            return Compute(names, out WindowWidth);
        }
        static internal string Set(IEnumerable<string> InputList, out int WindowWidth)
        {
            // determine size of cmd window
            WindowWidth = 0;
            return Compute(InputList, out WindowWidth);
        }

        static private string Compute(IEnumerable<string> names, out int WindowWidth)
        {
            // determine size of cmd window
            int szmax = 0;
            foreach (string fn in names)
                if (fn.Length > szmax)
                    szmax = fn.Length;
            int magn = szmax.ToString().Length;
            int width;
            //if (magn * 2 + 4 + szmax <= 180)        //120
            //{
            //    width = magn * 2 + 4 + szmax;
            //    Console.SetWindowSize(width, 30);
            //}
            //else
            //{
            //    Console.SetWindowSize(180, 30);     //120
            //    width = 120;
            //}
            if (magn * 2 + 4 + szmax <= 180)
            {
                width = magn * 2 + 4 + szmax;
                if (width < 80)
                    width = 80;
            }
            else
                width = 180;
            Console.SetWindowSize(width, 30);     //120
            //WindowWidth = width > 80 ? 180 : 80;    //120
            //Console.WindowWidth = WindowWidth;
            WindowWidth = width;
            string zeros = "";
            for (int x = 0; x < magn; x++) zeros += "0";
            return "({0:" + zeros + "}/{1:" + zeros + "}) {2}";
        }
    }
}
