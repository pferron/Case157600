using log4net;
using LPA.Dashboard.Web.Code;
using LPA.Dashboard.Web.Helpers;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.Models;

namespace LPA.Dashboard.Web.Controllers
{
    
    public class DeploymentController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DeploymentController));

        // GET: Deployment
        public ActionResult Index()
        {
            var model = new DeploymentViewModel();

            try
            {
                model.GetResourceDeployments();
            }
            catch (Exception ex)
            {
                model.ErrorMessage = "An error occured while trying to retreive deployments. Please contact Help Desk if this continues to happen.";
                if (log.IsErrorEnabled) { log.Error("Unable to get remote system updates at this time.", ex); }
            }

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CreateDeploymentViewModel();

            try
            {
                model.GetDeploymentRegions();
                model.DeploymentRegions.Add(new DeploymentRegionDao { DeploymentRegionId = 0, Name = "" });
                model.ChecklistTemplates.Add(new WOW.IllustrationMgmntTool.Common.DAO.LPAManagement.ChecklistTemplateDao { Id = 0, TemplateName = "Select Region First..." });
            }
            catch (Exception ex)
            {
                model.ErrorMessage = "An error occured while trying to retreive deployment regions. Please contact Help Desk if this continues to happen.";
                if (log.IsErrorEnabled) { log.Error("Unable to get regions at this time.", ex); }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult GetChecklists(int regionId)
        {
            var utils = new DeploymentUtilities();


            var checklists = utils.GetChecklistTemplates(regionId);


            return Json(checklists, JsonRequestBehavior.AllowGet);
        }
        
        /// <summary>
        /// Delete the checklis for a specific deployment
        /// </summary>
        /// <param deploymnent="model">The deployment model we are deleting the checklist from.</param>        
        /// <param deploymnent="wikiPassword">The user password to login to Confluence.</param>
        /// <returns>Truwe or false for success.</returns>
        [HttpPost]
        public async Task<ActionResult> DeleteChecklist(ResourceUpdateModel deployment, string wikiPassword)
        {
            var utils = new DeploymentUtilities();

            var response = await utils.DeleteChecklist(deployment, User.Identity.Name.Replace("HOAD\\", ""), wikiPassword);

            return Json(new { success = response.StatusCode == System.Net.HttpStatusCode.OK, message = response.Message });
        }

        /// <summary>
        /// Create checklist for a specific deployment
        /// </summary>
        /// <param deployment="model">The deployment model we are deleting the checklist from.</param>
        /// <param checklistId="checklistId">The checklist template id being used.</param>
        /// <param wikiPassword="wikiPassword">The user password to login to Confluence.</param>
        /// <returns>Truwe or false for success.</returns>
        [HttpPost]
        public async Task<ActionResult> CreateChecklist(ResourceUpdateModel deployment, int checklistId, string wikiPassword)
        {
            var utils = new DeploymentUtilities();            
        
            var response = await utils.CreateDeploymentChecklist(deployment.DeploymentId, checklistId, User.Identity.Name.Replace("HOAD\\", ""), wikiPassword);

            return Json(new { success = response.StatusCode == System.Net.HttpStatusCode.OK, message = response.Message });
        }

        /// <summary>
        /// Delete existing deployment
        /// </summary>
        /// <param deploymnent="model">The deployment model we are deleting the checklist from.</param>        
        /// <param wikiPassword="wikiPassword">The user password to login to Confluence.</param>
        /// <returns>Truwe or false for success.</returns>
        [HttpPost]
        public async Task<ActionResult> DeleteDeployment(ResourceUpdateModel deployment, string wikiPassword)
        {            
            var utils = new DeploymentUtilities();

            var response = await utils.DeleteDeployment(deployment, User.Identity.Name.Replace("HOAD\\", ""), wikiPassword);

            return Json(new { success = response.StatusCode == System.Net.HttpStatusCode.OK, message = response.Message });
        }

        [HttpPost]
        public async Task<ActionResult> EditDeployment(ResourceUpdateModel deployment, int checklistId, string wikiPassword)
        {
            var utils = new DeploymentUtilities();

            var response = await utils.EditDeployment(deployment, checklistId, User.Identity.Name.Replace("HOAD\\", ""), wikiPassword);

            return Json(new { success = response.StatusCode == System.Net.HttpStatusCode.OK, message = response.Message });
        }

        [HttpPost]        
        public async Task<ActionResult> ExecuteDeployment(ResourceUpdateModel deployment)
        {
            var utils = new DeploymentUtilities();

            var response = await utils.ExecuteDeployment(deployment);

            return Json(new { success = response.StatusCode == System.Net.HttpStatusCode.OK, message = response.Message });
        }

        /// <summary>
        /// Create the resource update from the create view
        /// </summary>
        /// <param name="model">the create resource model.</param>
        /// <returns>The index view on successful creation, otherwise the form</returns>

        [HttpPost]
        public async Task<ActionResult> CreateResourceUpdate(CreateDeploymentViewModel model)
        {            
            try
            {
                model.ResourceUpdate.CreatedBy = Helpers.ActiveDirectoryHelper.UsernameToFullName(User.Identity.Name);
                model.GetDeploymentRegions();
                model.DeploymentRegions.Add(new DeploymentRegionDao { DeploymentRegionId = 0, Name = "" });
                await model.CreateRemoteSystemUpdate(model, User.Identity.Name.Replace("HOAD\\", ""));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to create resouce update", ex);

                model.ErrorMessage = "Unable to create resource update. An email has been sent with the log." +
                    "Please do not attempt to update again.";
                return View(nameof(Create), model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeployNextRegion(DeploymentViewModel model)
        {
            try
            {
                model.ResourceUpdate.CreatedBy = Helpers.ActiveDirectoryHelper.UsernameToFullName(User.Identity.Name);
                model.GetResourceDeployments();
                model.DeploymentRegions.Add(new DeploymentRegionDao { DeploymentRegionId = 0, Name = "" });
                await model.DeployNextRegion(model, User.Identity.Name.Replace("HOAD\\", ""));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to deploy to the next region", ex);

                model.ErrorMessage = "Unable to deploy to the next region. An email has been sent with the log." +
                    "Please do not attempt to deploy again.";
                return View(nameof(Index), model);
            }
        }
    }
}