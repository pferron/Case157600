using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.WoodmenIllustrationService.Properties;

namespace WOW.WoodmenIllustrationService.Code
{
    public class TableBackedFunctions
    {
        private static int[] Term2016tbf = LoadTerm2016table();
        private static int[] LoadTerm2016table()
        {
            var lst = new List<int>();
            var arr = Settings.Default.Term2016HeaderCodes.Split(new char[] { ','});
            foreach(var hc in arr)
            {
                lst.Add(int.Parse(hc));
            }
            return lst.ToArray();
        }

        internal static bool IsTerm2016(int hc)
        {
            return Term2016tbf.Contains(hc);
        }

    }
}