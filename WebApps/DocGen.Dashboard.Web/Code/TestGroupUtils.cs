using log4net;
using System.Collections.Generic;
using System.Web.Mvc;
using WOW.IllustrationMgmntTool.Common.DAL;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.DTO;

namespace LPA.Dashboard.Web.Code
{
    /// <summary>
    /// The test group utilities.
    /// </summary>
    public class TestGroupUtils
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TestGroupUtils));

        /// <summary>
        /// Gets the test groups.
        /// </summary>
        /// <returns>A list of test group DAOs.</returns>
        public List<TestGroupDao> GetTestGroups()
        {
            if (log.IsInfoEnabled) log.Info("GetTestGroups called.");

            TestGroupLogic testGroupLogic = new TestGroupLogic();

            return testGroupLogic.GetTestGroups();
        }

        /// <summary>
        /// Gets the test groups.
        /// </summary>
        /// <param name="searchDto">The search DTO.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A list of test group DAOs.</returns>
        public List<TestGroupDao> GetTestGroups(TestGroupSearchDto searchDto, int pageNumber, int pageSize)
        {
            if (log.IsInfoEnabled) log.Info($"GetTestGroups called with searchDto: {searchDto} pageNumber: {pageNumber} and pageSize: {pageSize}.");

            TestGroupLogic testGroupLogic = new TestGroupLogic();

            return testGroupLogic.GetTestGroups(searchDto, pageNumber, pageSize);
        }

        /// <summary>
        /// Gets the test group count.
        /// </summary>
        /// <param name="searchDto">The search DTO.</param>
        /// <returns>An int.</returns>
        public int GetTestGroupCount(TestGroupSearchDto searchDto)
        {
            if (log.IsInfoEnabled) log.Info($"GetTestGroupCount called with searchDto: {searchDto}.");

            TestGroupLogic testGroupLogic = new TestGroupLogic();

            return testGroupLogic.GetTestGroupsCount(searchDto);
        }

        /// <summary>
        /// Gets the test groups.
        /// </summary>
        /// <param name="productTypeCode">The product type code.</param>
        /// <returns>A list of test group DAOs.</returns>
        public List<TestGroupDao> GetTestGroups(string productTypeCode)
        {
            if (log.IsInfoEnabled) log.Info($"GetTestGroups called with productTypeCode: {productTypeCode}.");

            TestGroupLogic testGroupLogic = new TestGroupLogic();

            return testGroupLogic.GetTestGroups(productTypeCode);
        }

        /// <summary>
        /// Gets the test group list.
        /// </summary>
        /// <param name="productTypeCode">The product type code.</param>
        /// <returns>A list of select list items.</returns>
        public List<SelectListItem> GetTestGroupList(string productTypeCode)
        {
            if (log.IsInfoEnabled) log.Info("GetTestGroupList called.");

            List<SelectListItem> testGroupSelectList = new List<SelectListItem>();

            foreach (var testGroup in GetTestGroups(productTypeCode))
            {
                SelectListItem item = new SelectListItem() { Text = testGroup.Name, Value = testGroup.TestGroupId.ToString() };
                testGroupSelectList.Add(item);
            }

            return testGroupSelectList;
        }

        /// <summary>
        /// Gets the test files.
        /// </summary>
        /// <param name="testGroupId">The test group id.</param>
        /// <returns>A list of test file CIM DTOs.</returns>
        public List<TestFileCIMDto> GetTestFiles(int testGroupId)
        {
            if (log.IsInfoEnabled) log.Info($"GetTestFiles called with a test group id of ${testGroupId}.");

            var logic = new TestGroupLogic();

            return logic.GetTestFiles(testGroupId);
        }

        /// <summary>
        /// Gets the test file.
        /// </summary>
        /// <param name="testFileId">The test file id.</param>
        /// <returns>A TestFileCIMDao.</returns>
        public TestFileCIMDao GetTestFile(int testFileId)
        {
            if (log.IsInfoEnabled) log.Info("GetTestFile called.");

            var logic = new TestGroupLogic();

            return logic.GetCimTestFile(testFileId);
        }

        /// <summary>
        /// Gets the test group.
        /// </summary>
        /// <param name="testGroupId">The test group id.</param>
        /// <returns>A TestGroupDao.</returns>
        public TestGroupDao GetTestGroup(int testGroupId)
        {
            if (log.IsInfoEnabled) log.Info("GetTestGroup called.");

            var logic = new TestGroupLogic();

            return logic.GetTestGroup(testGroupId);
        }

        /// <summary>
        /// Updates the test group.
        /// </summary>
        /// <param name="testGroupDao">The test group DAO.</param>
        public void UpdateTestGroup(TestGroupDao testGroupDao)
        {
            if (log.IsInfoEnabled) log.Info($"UpdateTestGroup called with testGroupDao: {testGroupDao}.");

            TestGroupLogic testGroupLogic = new TestGroupLogic();
            testGroupLogic.UpdateTestGroup(testGroupDao);
        }

        /// <summary>
        /// Creates the test group.
        /// </summary>
        /// <param name="testGroupDao">The test group DAO.</param>
        public void CreateTestGroup(TestGroupDao testGroupDao)
        {
            if (log.IsInfoEnabled) log.Info($"CreateTestGroup called with testGroupDao: {testGroupDao}.");

            TestGroupLogic testGroupLogic = new TestGroupLogic();
            testGroupLogic.CreateTestGroup(testGroupDao);
        }

        /// <summary>
        /// Deletes the test group.
        /// </summary>
        /// <param name="testGroupId">The test group id.</param>
        public void DeleteTestGroup(int testGroupId)
        {
            if (log.IsInfoEnabled) log.Info($"DeleteTestGroup called with testGroupId: {testGroupId}.");

            TestGroupLogic testGroupLogic = new TestGroupLogic();
            testGroupLogic.DeleteTestGroup(testGroupId);
        }
    }
}