using log4net;
using LPA.Dashboard.Web.Code;
using LPA.Dashboard.Web.Properties;
using LPA.Dashboard.Web.ViewModels;
using System;
using System.Threading.Tasks;
using WOW.IllustrationMgmntTool.Common.Code;
using WOW.IllustrationMgmntTool.Common.DTO;

namespace LPA.Dashboard.Web.ActionCode
{
    /// <summary>
    /// The CIS test tool actions.
    /// </summary>
    public class CisTestToolActions
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CisTestToolActions));

        /// <summary>
        /// Process test result CIM index
        /// </summary>
        /// <returns>TestResultCimIndexViewModel</returns>
        internal TestResultCimIndexViewModel ProcessTestResultCimIndex()
        {
            if (log.IsInfoEnabled) log.Info("ProcessTestResultCimIndex called.");

            TestResultCimIndexViewModel testResultCimIndexViewModel = new TestResultCimIndexViewModel();

            ProductTypeCodeUtils productTypeCodeUtils = new ProductTypeCodeUtils();
            testResultCimIndexViewModel.ProductTypeCodes = productTypeCodeUtils.GetProductTypeCodes();

            return testResultCimIndexViewModel;
        }

        /// <summary>
        /// Process CIM files
        /// </summary>
        /// <param name="testGroupId"></param>
        /// <param name="cisUrl"></param>
        /// <returns>ProcessCimFilesViewModel</returns>
        internal async Task<ProcessCimFilesViewModel> ProcessCimFiles(int testGroupId, string cisUrl)
        {
            if (log.IsInfoEnabled) log.Info($"Calling ProcessCimFiles with testGroupId: {testGroupId}, and cisUrl: {cisUrl}.");

            TestResultCimUtils testResultCimUtils = new TestResultCimUtils();

            return await testResultCimUtils.GetTestFileResults(testGroupId, cisUrl);
        }

        /// <summary>
        /// Process search
        /// </summary>
        /// <returns>TestResultCimSearchViewModel</returns>
        internal TestResultCimSearchViewModel ProcessSearch()
        {
            if (log.IsInfoEnabled) log.Info("ProcessSearch called.");

            TestResultCimSearchViewModel testResultCimSearchViewModel = new TestResultCimSearchViewModel();

            ProductTypeCodeUtils productTypeCodeUtils = new ProductTypeCodeUtils();
            testResultCimSearchViewModel.ProductTypeCodes = productTypeCodeUtils.GetProductTypeCodes();

            testResultCimSearchViewModel.IllustrationReportTypes = EnumerationsSupport.GetIllustrationReportTypes();

            StateUtils stateUtils = new StateUtils();
            testResultCimSearchViewModel.StateCodes = stateUtils.GetStates();

            return testResultCimSearchViewModel;
        }

        /// <summary>
        /// Process do search
        /// </summary>
        /// <param name="searchDto"></param>
        /// <param name="page"></param>
        /// <returns>TestResultCimSearchViewModel</returns>
        internal TestResultCimSearchViewModel ProcessDoSearch(TestResultCimSearchDto searchDto, int? page)
        {
            if (log.IsInfoEnabled) log.Info($"ProcessSearch called with searchDto: {searchDto}, page: {page}.");

            double pageSize = Settings.Default.PageSize;

            double pageNumber = page ?? 1;
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            double pageTotal = 1;

            TestResultCimSearchViewModel testResultCimSearchViewModel = new TestResultCimSearchViewModel
            {
                SearchDto = searchDto
            };
            ProductTypeCodeUtils productTypeCodeUtils = new ProductTypeCodeUtils();
            TestGroupUtils testGroupUtils = new TestGroupUtils();
            testResultCimSearchViewModel.ProductTypeCodes = productTypeCodeUtils.GetProductTypeCodes();
            testResultCimSearchViewModel.TestGroups = testGroupUtils.GetTestGroupList(searchDto.ProductTypeCode);
            testResultCimSearchViewModel.IllustrationReportTypes = EnumerationsSupport.GetIllustrationReportTypes();

            StateUtils stateUtils = new StateUtils();
            testResultCimSearchViewModel.StateCodes = stateUtils.GetStates();

            TestResultCimUtils testResultCimUtils = new TestResultCimUtils();
            testResultCimSearchViewModel.TestResultsCimDaos = testResultCimUtils.GetTestResultsCim(searchDto, (int)pageNumber, (int)pageSize);
            var recordTotal = testResultCimUtils.GetTestResultsCimCount(searchDto);

            testResultCimSearchViewModel.Page = (int)pageNumber;
            testResultCimSearchViewModel.PageSize = (int)pageSize;
            testResultCimSearchViewModel.RecordTotal = recordTotal;

            if (recordTotal > pageSize)
            {
                pageTotal = Math.Ceiling(recordTotal / pageSize);
            }

            testResultCimSearchViewModel.TotalPages = (int)pageTotal;

            return testResultCimSearchViewModel;
        }

        /// <summary>
        /// ProcessDisplayCimJson
        /// </summary>
        /// <param name="testResultId"></param>
        /// <returns>DisplayCimJsonViewModel</returns>
        internal DisplayCimJsonViewModel ProcessDisplayCimJson(long testResultId)
        {
            DisplayCimJsonViewModel displayCimJsonViewModel = new DisplayCimJsonViewModel();

            TestResultCimUtils testResultCimUtils = new TestResultCimUtils();
            displayCimJsonViewModel.CimJson = testResultCimUtils.GetTestResultCimJson(testResultId);

            return displayCimJsonViewModel;
        }
    }
}