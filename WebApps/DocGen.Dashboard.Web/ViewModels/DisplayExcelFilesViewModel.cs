using LPA.Dashboard.Web.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WOW.IllustrationMgmntTool.Common.Models.VaTestTool;

namespace LPA.Dashboard.Web.ViewModels
{
    public class DisplayExcelFilesViewModel : BaseViewModel
    {
        public List<ExcelFile> ExcelFileInfoList { get; set; }
        public string ExcelFileDirectory { get; set; }
        public string ExcelFilePath { get; set; }
        public DisplayExcelFilesViewModel()
        {
            ErrorMessage = string.Empty;
            ExcelFileInfoList = new List<ExcelFile>();
            ExcelFileDirectory = Settings.Default.IllustrationExcelFileDirectory;
        }
    }
}