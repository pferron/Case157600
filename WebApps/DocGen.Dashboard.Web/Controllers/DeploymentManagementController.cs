using log4net;
using LPA.Dashboard.Models.View;
using LPA.Dashboard.Web.Code;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WOW.IllustrationMgmntTool.Common.Models.Deployment;

namespace LPA.Dashboard.Web.Controllers
{
    [RoutePrefix("api/DeploymentManagement")]
    public class DeploymentManagementController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DeploymentManagementController));

        /// <summary>
        /// This get method is called from the ScheduleDeploymentService once a deployment needs to happen.
        /// </summary>
        /// <param name="id">The The deployment id that is propogated to the correct regions</param>
        /// <returns>OK regarlesss of pass or fail.</returns>
        [HttpGet]
        [Authorize(Roles = @"HOAD\GRP_DoNotCallAdmins")]
        [Route("DeployFromScheduledService")]
        public IHttpActionResult DeployFromScheduledService(int id)
        {
            try
            {
                var utilities = new DeploymentUtilities();
                var response = utilities.DeployFromService(id);

                return ResponseMessage(response.ToMessage());
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Uable to deploy from the service.", ex);
                return BadRequest("An unknown error occured");
            }
        }

        /// <summary>
        /// Deploy the given resource to the next region.
        /// </summary>
        /// <param name="id">the id of the resource to be deployed</param>
        /// <returns>Ok on success</returns>
        //[HttpPost]
        //[Authorize(Roles = @"HOAD\GRP_DoNotCallAdmins")]
        //[Route("DeployToNextRegion")]
        //public IHttpActionResult DeployToNextRegion(NextDeploymentModel model)
        //{
        //    try
        //    {
        //        //update the name to the person preforming the action
        //        model.Name = Helpers.ActiveDirectoryHelper.UsernameToFullName(User.Identity.Name);

        //        var utilities = new DeploymentUtilities();
        //        var response = utilities.DeployToNextRegion(model);

        //        return ResponseMessage(response.ToMessage());
        //    }
        //    catch (Exception ex)
        //    {
        //        if (log.IsErrorEnabled) log.Error("Unable to deploy to next region", ex);
        //        return BadRequest("An error occured, unable to deploy to the next region.");
        //    }
        //}

        /// <summary>
        /// Mark a deployment as failure
        /// </summary>
        /// <param name="id">the id of the update</param>
        /// <returns>Ok on success</returns>
        [HttpGet]
        [Authorize(Roles = @"HOAD\GRP_DoNotCallAdmins")]
        [Route("MarkDeploymentAsFailure")]
        public IHttpActionResult MarkDeploymentAsFailure(int id)
        {
            try
            {
                var utilities = new DeploymentUtilities();
                var response = utilities.MarkDeploymentAsFailure(id);

                return ResponseMessage(response.ToMessage());
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to mark deployment as failure", ex);
                return BadRequest("An error occured while trying to mark deployment as failure");
            }
        }

        /// <summary>
        /// Schedule a Deployment for the future.
        /// </summary>
        /// <param name="deploymentModel">The deployment date and id</param>
        /// <returns>Okay on success.</returns>
        [HttpPost]
        [Authorize(Roles = @"HOAD\GRP_DoNotCallAdmins")]
        [Route("ScheduleDeployment")]
        public IHttpActionResult ScheduleDeployment(ScheduledDeploymentModel deploymentModel)
        {
            try
            {
                var utilities = new DeploymentUtilities();

                deploymentModel.Name = Helpers.ActiveDirectoryHelper.UsernameToFullName(User.Identity.Name);
                deploymentModel.HostIp = Request.RequestUri.GetLeftPart(UriPartial.Authority);

                var response = utilities.ScheduleDeployment(deploymentModel);

                return ResponseMessage(response.ToMessage());
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to ScheduleDeployment", ex);
                return BadRequest("Unable to Schedule Deployment at this time");
            }
        }
    }
}
