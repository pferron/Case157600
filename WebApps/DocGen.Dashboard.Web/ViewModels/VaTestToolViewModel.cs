using LPA.Dashboard.Web.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LPA.Dashboard.Web.ViewModels
{
    public class VaTestToolViewModel : BaseViewModel
    {
        public string SqlPath {get; set;}
        public string ExcelFileDirectory { get; set; }
        public string ExcelFilePath { get; set; }

        public VaTestToolViewModel()
        {
            ErrorMessage = string.Empty;
            ExcelFileDirectory = Settings.Default.IllustrationExcelFileDirectory;
            ExcelFilePath = Path.Combine(ExcelFileDirectory, DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0'));
            SqlPath = Path.Combine(Settings.Default.IllustrationSqlFileDirectory, DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0'));
            SqlPath = SqlPath.Replace("\\", "\\\\");
            ExcelFilePath = ExcelFilePath.Replace("\\", "\\\\");
        }
    }
}