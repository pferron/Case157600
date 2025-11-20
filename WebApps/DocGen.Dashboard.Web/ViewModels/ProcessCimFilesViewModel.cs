using System.Collections.Generic;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;

namespace LPA.Dashboard.Web.ViewModels
{
    public class ProcessCimFilesViewModel : BaseViewModel
    {
        public List<TestResultCIMDao> TestResults { get; set; }


        public ProcessCimFilesViewModel()
        {
            TestResults = new List<TestResultCIMDao>();
            ErrorMessage = string.Empty;
        }
    }
}