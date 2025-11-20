using LPA.Dashboard.Web.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.DBO;
using WOW.IllustrationMgmntTool.Common.Models;

namespace LPA.Dashboard.Web
{
    public class DeploymentViewModel : BaseViewModel
    {
        public ResourceUpdateBdo ResourceUpdate { get; set; }        
        public List<DeploymentModel> ResourceDeployments { get; set; }
        public List<ChecklistTemplateDao> ChecklistTemplates { get; set; } = new List<ChecklistTemplateDao>();
        public List<DeploymentRegionDao> DeploymentRegions { get; set; }
        public int RSUId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a valid Region.")]
        public int Region { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a valid Checklist Tempalte.")]
        public int ChecklistTemplate { get; set; }

        /// <summary>
        /// Retreive the resource deployments
        /// </summary>
        public void GetResourceDeployments()
        {
            var utilities = new DeploymentUtilities();

            ResourceDeployments = utilities.GetDeployments();
            DeploymentRegions = utilities.GetDeploymentRegions();
        }

        public async Task DeployNextRegion(DeploymentViewModel model, string wikiUser)
        {
            var logic = new DeploymentUtilities();

            await logic.DeployToNextRegion(RSUId, model.ResourceUpdate, Region, ChecklistTemplate, wikiUser);
        }        
    }
}