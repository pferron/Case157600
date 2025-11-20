using LPA.Dashboard.Web.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.Models.CimFile;

namespace LPA.Dashboard.Web.ViewModels
{
    public class CreateCimViewModel : BaseViewModel
    {
        public TestGroupDao TestGroup { get; set; }
        public string CimText { get; set; }


        public CreateCimViewModel()
        {
            TestGroup = new TestGroupDao();
        }

        public void GetTestGroup(int testGroupId)
        {
            var utilities = new TestGroupUtils();
            TestGroup = utilities.GetTestGroup(testGroupId);
        }

        public void AddCim(CreateCimFileModel model)
        {
            var utilities = new TestFileCimUtils();
            utilities.CreateCimFile(model);
        }
    }
}