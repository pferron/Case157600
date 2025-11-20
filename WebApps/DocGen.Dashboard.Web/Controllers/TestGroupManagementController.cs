using log4net;
using LPA.Dashboard.Web.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WOW.IllustrationMgmntTool.Common.Models.CimFile;

namespace LPA.Dashboard.Web.Controllers
{
    [RoutePrefix("api/TestGroupManagement")]
    public class TestGroupManagementController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TestGroupManagementController));

        /// <summary>
        /// This will update the name of the an already exisiting cim file
        /// </summary>
        /// <param name="id">The cim file id of the </param>
        /// <returns>OK on success</returns>
        [HttpGet]
        [Route("UpdateCimFileName")]
        public IHttpActionResult UpdateCimFileName(int id, string fileName)
        {
            try
            {
                var utilities = new TestFileCimUtils();
                var response = utilities.UpdateCimFileName(id, fileName);

                return ResponseMessage(response.ToMessage());
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                    log.Error("An exception occured while trying to update the cim file name",ex);

                return BadRequest("An unknown exception occured while processing the request. Please try again.");
            }
        }

        /// <summary>
        /// Delete a cim file based on it's id
        /// </summary>
        /// <param name="id">The id of the soon to be deleted file</param>
        /// <returns>Ok on success</returns>
        [HttpGet]
        [Route("DeleteCimFile")]
        public IHttpActionResult DeleteCimFile(int id)
        {
            try
            {
                var utilities = new TestFileCimUtils();
                var response = utilities.DeleteCimFile(id);

                return ResponseMessage(response.ToMessage());
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                    log.Error("An exception occured while trying to delete the cim file", ex);

                return BadRequest("An unknown exception occured while processing the request. Please try again.");
            }
        }

        /// <summary>
        /// Create a cim file
        /// </summary>
        /// <param name="model">The model that is used to create the file</param>
        /// <returns>Ok on success</returns>
        [HttpPost]
        [Route("CreateCimFile")]
        public IHttpActionResult CreateCimFile(CreateCimFileModel model)
        {
            try
            {
                model.Creator = User.Identity.Name;
                model.FileName = "FileName";

                var utilities = new TestFileCimUtils();
                var response = utilities.CreateCimFile(model);
                return ResponseMessage(response.ToMessage());
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                    log.Error("An exception occured while trying to create the cim file", ex);

                return BadRequest("An unknown exception occured while processing the request. Please try again.");
            }
        }

        /// <summary>
        /// Update the conents of the cim file
        /// </summary>
        /// <returns>Ok on success</returns>
        [HttpPost]
        [Route("EditCimFile")]
        public IHttpActionResult EditCimFile(ModifyCimFileModel model)
        {
            try
            {
                model.ModifiedBy = User.Identity.Name;

                var utilities = new TestFileCimUtils();
                var response = utilities.EditCimFile(model);
                return ResponseMessage(response.ToMessage());
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                    log.Error("An exception occured while trying to create the cim file", ex);

                return BadRequest("An unknown exception occured while processing the request. Please try again.");
            }
        }

        /// <summary>
        /// Clone the selected cim file 
        /// </summary>
        /// <param name="model">The model that is used to begin cloning the cim's</param>
        /// <returns>Ok on success</returns>
        [HttpPost]
        [Route("CloneSelected")]
        public IHttpActionResult CloneSelected(CloneModel model)
        {
            try
            {
                model.ModifiedBy = User.Identity.Name;

                var utilities = new TestFileCimUtils();
                var response = utilities.CloneSelected(model);
                return ResponseMessage(response.ToMessage());
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                    log.Error("An exception occured while trying to clone selected cims", ex);

                return BadRequest("An unknown exception occured while processing the request. Please try again.");
            }
        }
    }
}
