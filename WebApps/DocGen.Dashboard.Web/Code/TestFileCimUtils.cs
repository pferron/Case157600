using log4net;
using Newtonsoft.Json;
using System.Collections.Generic;
using WOW.IllustrationMgmntTool.Common.DAL;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.Models.CimFile;
using WOW.IllustrationMgmntTool.Common.Models.Deployment;

namespace LPA.Dashboard.Web.Code
{
    /// <summary>
    /// The test file CIM utilities.
    /// </summary>
    public class TestFileCimUtils
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TestFileCimUtils));

        /// <summary>
        /// Gets the test files CIM.
        /// </summary>
        /// <returns>A list of test file CIM DAOs.</returns>
        public List<TestFileCIMDao> GetTestFilesCim()
        {
            if (log.IsInfoEnabled) log.Info("GetTestFilesCim called.");

            TestFileCimLogic testFileCimLogic = new TestFileCimLogic();

            return testFileCimLogic.GetTestFilesCIM();
        }

        /// <summary>
        /// Gets the test files CIM.
        /// </summary>
        /// <param name="testGroupId">The test group id.</param>
        /// <returns>A list of test file CIM DAOs.</returns>
        public List<TestFileCIMDao> GetTestFilesCim(int testGroupId)
        {
            if (log.IsInfoEnabled) log.Info($"GetTestFilesCim called with testGroupId: {testGroupId}.");

            TestFileCimLogic testFileCimLogic = new TestFileCimLogic();

            return testFileCimLogic.GetTestFilesCIM(testGroupId);
        }

        /// <summary>
        /// Update a CIM file's name
        /// </summary>
        /// <param name="id">the id of the CIM file</param>
        /// <param name="fileName">the new name of the CIM file.</param>
        /// <returns>An api response</returns>
        public ApiResponseModel UpdateCimFileName(int id, string fileName)
        {
            if (log.IsInfoEnabled) log.Info($"UpdateCimFileName called with id: {id} and fileName: {fileName}");

            var logic = new TestFileCimLogic();
            logic.UpdateCimFileName(id, fileName);

            return new ApiResponseModel
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Successfully updated CIM file name"
            };
        }

        /// <summary>
        /// Delete a CIM file
        /// </summary>
        /// <param name="id">The id of the CIM file</param>
        /// <returns>An api response</returns>
        public ApiResponseModel DeleteCimFile(int id)
        {
            if (log.IsInfoEnabled) log.Info($"DeleteCimFile called with id: {id}");

            var logic = new TestFileCimLogic();
            return logic.DeleteCimFile(id);
        }

        /// <summary>
        /// Creates the CIM file.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>An ApiResponseModel.</returns>
        public ApiResponseModel CreateCimFile(CreateCimFileModel model)
        {
            if (log.IsInfoEnabled) log.Info($"CreateCimFile called with the model: {JsonConvert.SerializeObject(model)}");

            var logic = new TestFileCimLogic();
            return logic.CreateCimFile(model);
        }

        /// <summary>
        /// Edits the CIM file.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>An ApiResponseModel.</returns>
        public ApiResponseModel EditCimFile(ModifyCimFileModel model)
        {
            if (log.IsInfoEnabled) log.Info($"EditCimFile called with the model: {JsonConvert.SerializeObject(model)}");

            var logic = new TestFileCimLogic();
            return logic.EditCimFile(model);
        }

        /// <summary>
        /// Clones the selected.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>An ApiResponseModel.</returns>
        public ApiResponseModel CloneSelected(CloneModel model)
        {
            if (log.IsInfoEnabled) log.Info($"CloneSelected called with the model: {JsonConvert.SerializeObject(model)}");

            var logic = new TestFileCimLogic();
            return logic.CloneSelectedCims(model);
        }
    }
}