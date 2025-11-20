using LPA.Dashboard.Web.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.IllustrationMgmntTool.Common.DAL;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.DTO;

namespace LPA.Dashboard.Web.ViewModels
{
    public class CimFileViewModel : BaseViewModel
    {
        public List<TestFileCIMDto> TestFiles { get; set; }
        public List<TestGroupDao> TestGroups { get; set; }
        public TestGroupDao CurrentTestGroup { get; set; }


        public CimFileViewModel()
        {
            TestFiles = new List<TestFileCIMDto>();
            TestGroups = new List<TestGroupDao>();
        }

        public void GetTestCims(int id)
        {
            var utilities = new TestGroupUtils();

            TestFiles = utilities.GetTestFiles(id).OrderByDescending(file => file.DateModified).ToList();
            TestGroups = utilities.GetTestGroups();

            CurrentTestGroup = TestGroups.Where(tg => tg.TestGroupId == id).FirstOrDefault();
        }

    }
}