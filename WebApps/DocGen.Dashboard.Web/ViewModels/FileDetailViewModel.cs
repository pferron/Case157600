using LPA.Dashboard.Web.Code;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;

namespace LPA.Dashboard.Web.ViewModels
{
    public class FileDetailViewModel : BaseViewModel
    {
        public TestFileCIMDao TestFile { get; set; }
        public TestGroupDao TestGroup { get; set; }

        public FileDetailViewModel()
        {
            TestFile = new TestFileCIMDao();
            TestGroup = new TestGroupDao();
        }

        public void GetTestFile(int testFileId)
        {
            var utilities = new TestGroupUtils();
            TestFile = utilities.GetTestFile(testFileId);
        }

        public void GetTestGroup(int testGroupId)
        {
            var utilities = new TestGroupUtils();
            TestGroup = utilities.GetTestGroup(testGroupId);
        }
    }
}