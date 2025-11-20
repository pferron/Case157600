using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.DTO;

namespace LPA.Dashboard.Web.ViewModels
{
    public class TestGroupViewModel : BaseViewModel
    {
        public List<TestGroupDao> TestGroups { get; set; }
        public TestGroupDao TestGroupDao { get; set; }
        public List<string> ProductTypeCodes { get; set; }
        public List<string> IllustrationTypes { get; set; }
        public string ProductTypeCode { get; set; }
        public TestGroupSearchDto TestGroupSearchDto { get; set; }
        public int Page { get; set; }

        public TestGroupViewModel()
        {
            ErrorMessage = string.Empty;
            TestGroups = new List<TestGroupDao>();
            TestGroupDao = new TestGroupDao();
            ProductTypeCode = string.Empty;
            ProductTypeCodes = new List<string>();
            IllustrationTypes = new List<string>();
            TestGroupSearchDto = new TestGroupSearchDto();
        }
    }
}