using log4net;
using LPA.Dashboard.Web.Code;
using LPA.Dashboard.Web.Properties;
using LPA.Dashboard.Web.ViewModels;
using System;
using WOW.IllustrationMgmntTool.Common.Code;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.DTO;

namespace LPA.Dashboard.Web.ActionCode
{
    /// <summary>
    /// The test group actions.
    /// </summary>
    public class TestGroupActions
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TestGroupActions));

        /// <summary>
        /// Process index
        /// </summary>
        /// <returns>TestGroupViewModel</returns>
        internal TestGroupViewModel ProcessIndex()
        {
            if (log.IsInfoEnabled) log.Info("ProcessIndex called.");

            TestGroupViewModel testGroupViewModel = new TestGroupViewModel();

            TestGroupUtils testGroupUtils = new TestGroupUtils();
            testGroupViewModel.TestGroups = testGroupUtils.GetTestGroups();

            ProductTypeCodeUtils productTypeCodeUtils = new ProductTypeCodeUtils();
            testGroupViewModel.ProductTypeCodes = productTypeCodeUtils.GetProductTypeCodes();

            testGroupViewModel.IllustrationTypes = EnumerationsSupport.GetIllustrationTypes();

            return testGroupViewModel;
        }

        /// <summary>
        /// Process search
        /// </summary>
        /// <returns>TestGroupSearchViewModel</returns>
        internal TestGroupSearchViewModel ProcessSearch()
        {
            if (log.IsInfoEnabled) log.Info("ProcessSearch called.");

            TestGroupSearchViewModel testGroupSearchViewModel = new TestGroupSearchViewModel();

            TestGroupUtils testGroupUtils = new TestGroupUtils();
            testGroupSearchViewModel.TestGroups = testGroupUtils.GetTestGroups();

            ProductTypeCodeUtils productTypeCodeUtils = new ProductTypeCodeUtils();
            testGroupSearchViewModel.ProductTypeCodes = productTypeCodeUtils.GetProductTypeCodes();

            testGroupSearchViewModel.IllustrationTypes = EnumerationsSupport.GetIllustrationTypes();

            return testGroupSearchViewModel;
        }

        /// <summary>
        /// Process add test group
        /// </summary>
        /// <returns>TestGroupViewModel</returns>
        internal TestGroupViewModel ProcessAddTestGroup()
        {
            if (log.IsInfoEnabled) log.Info("ProcessAddTestGroup called.");

            TestGroupViewModel testGroupViewModel = new TestGroupViewModel();

            ProductTypeCodeUtils productTypeCodeUtils = new ProductTypeCodeUtils();
            testGroupViewModel.ProductTypeCodes = productTypeCodeUtils.GetProductTypeCodes();

            testGroupViewModel.IllustrationTypes = EnumerationsSupport.GetIllustrationTypes();

            return testGroupViewModel;
        }

        /// <summary>
        /// Process new
        /// </summary>
        /// <param name="testGroupDao"></param>
        /// <returns>TestGroupViewModel</returns>
        internal TestGroupViewModel ProcessNew(TestGroupDao testGroupDao)
        {
            if (log.IsInfoEnabled) log.Info($"ProcessNew called with testGroupDao: {testGroupDao}.");

            TestGroupViewModel testGroupViewModel = new TestGroupViewModel
            {
                TestGroupDao = testGroupDao
            };

            TestGroupUtils testGroupUtils = new TestGroupUtils();
            testGroupUtils.CreateTestGroup(testGroupDao);

            return testGroupViewModel;
        }

        /// <summary>
        /// Process do search
        /// </summary>
        /// <param name="searchDto"></param>
        /// <param name="page"></param>
        /// <returns>TestGroupSearchViewModel</returns>
        internal TestGroupSearchViewModel ProcessDoSearch(TestGroupSearchDto searchDto, int? page)
        {
            if (log.IsInfoEnabled) log.Info($"ProcessDoSearch called with searchDto: {searchDto} and page: {page}.");

            TestGroupSearchViewModel testGroupSearchViewModel = new TestGroupSearchViewModel();

            double pageSize = Settings.Default.PageSize;

            double pageNumber = page ?? 1;
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            double pageTotal = 1;

            TestGroupUtils testGroupUtils = new TestGroupUtils();
            var recordTotal = testGroupUtils.GetTestGroupCount(searchDto);
            var testGroups = testGroupUtils.GetTestGroups(searchDto, (int)pageNumber, (int)pageSize);

            testGroupSearchViewModel.Page = (int)pageNumber;
            testGroupSearchViewModel.PageSize = (int)pageSize;
            testGroupSearchViewModel.TestGroups = testGroups;
            testGroupSearchViewModel.RecordTotal = recordTotal;

            if (recordTotal > pageSize)
            {
                pageTotal = Math.Ceiling(recordTotal / pageSize);
            }

            testGroupSearchViewModel.TotalPages = (int)pageTotal;

            return testGroupSearchViewModel;
        }
    }
}