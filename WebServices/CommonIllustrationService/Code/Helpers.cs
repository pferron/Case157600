using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wow.CommonIllustrationService.Code
{
    public class Helpers
    {
       static public int AgeAtDate(DateTime birth, DateTime date)
        {
            /*  
                    Bdate <= Idate
                    Byear = Iyear: age = 0
                    Byear < Iyear: Bmonthday <= Imonthday ? Iyear-Byear : Iyear-Byear-1                         
             */
            int age = 0;
            if (date >= birth)
            {
                age = date.Year - birth.Year;
                if (date.Year > birth.Year &&
                    (date.Month < birth.Month ||
                     date.Month == birth.Month && date.Day < birth.Day))
                    age--;
            }
            return age;
        }
    }
}