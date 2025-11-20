using LPA.Dashboard.Web.Properties;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.DTO;

namespace LPA.Dashboard.Web.ViewModels
{
    public class TestResultCimSearchViewModel : BaseViewModel
    {
        public TestResultCimSearchDto SearchDto { get; set; }
        public List<string> ProductTypeCodes { get; set; }
        public List<SelectListItem> TestGroups { get; set; }
        public List<TestResultCIMDao> TestResultsCimDaos { get; set; }
        public int MaxSearchResults { get; set; }
        public List<SelectListItem> StateCodes { get; set; }
        public List<string> IllustrationReportTypes { get; set; }
        public int Page { get; set; }
        public int RecordTotal { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public TestResultCimSearchViewModel()
        {
            SearchDto = new TestResultCimSearchDto();
            SearchDto.DateCreatedBegin = DateTime.Now.Date;
            SearchDto.DateCreatedEnd = DateTime.Now.AddDays(1).Date;
            ErrorMessage = string.Empty;
            TestGroups = new List<SelectListItem>();
            TestResultsCimDaos = new List<TestResultCIMDao>();
            MaxSearchResults = Settings.Default.MaxSearchResults;
            ProductTypeCodes = new List<string>();
            IllustrationReportTypes = new List<string>();
            StateCodes = new List<SelectListItem>();
        }
    }
}