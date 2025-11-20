using LPA.Dashboard.Web.Properties;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LPA.Dashboard.Web.ViewModels
{
    public class TestResultCimIndexViewModel : BaseViewModel
    {
        public List<SelectListItem> TestGroups { get; set; }
        public List<string> ProductTypeCodes { get; set; }
        public List<SelectListItem> Regions { get; set; }
        public string IllustrationsTestUrl { get; set; }
        public string IllustrationsUatUrl { get; set; }
        public string IllustrationsModlUrl { get; set; }
        public string IllustrationsProdUrl { get; set; }
        public TestResultCimIndexViewModel()
        {
            ErrorMessage = string.Empty;
            TestGroups = new List<SelectListItem>();
            Regions = new List<SelectListItem>();
            ProductTypeCodes = new List<string>();
            IllustrationsTestUrl = Settings.Default.IllustrationsTestWebServiceUrl;
            IllustrationsUatUrl = Settings.Default.IllustrationsUatWebServiceUrl;
            IllustrationsModlUrl = Settings.Default.IllustrationsModlWebServiceUrl;
            IllustrationsProdUrl = Settings.Default.IllustrationsProdWebServiceUrl;
        }
    }
}