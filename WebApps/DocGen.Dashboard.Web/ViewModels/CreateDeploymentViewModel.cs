using LPA.Dashboard.Web.Code;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.DBO;

namespace LPA.Dashboard.Web
{
    public class CreateDeploymentViewModel : BaseViewModel
    {
        public ResourceUpdateBdo ResourceUpdate { get; set; }
        public List<DeploymentRegionDao> DeploymentRegions { get; set; }
        public List<ChecklistTemplateDao> ChecklistTemplates { get; set; } = new List<ChecklistTemplateDao>();

        [Required(ErrorMessage = "Region is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a valid Region.")]
        public int Region { get; set; }
        [Required(ErrorMessage = "Checklist Template is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a valid Checklist Template.")]
        public int ChecklistTemplate { get; set; }
        
        public async Task CreateRemoteSystemUpdate(CreateDeploymentViewModel model, string wikiUser)
        {
            var logic = new DeploymentUtilities();

            await logic.CreateRemoteSystemUpdate(model.ResourceUpdate, Region, ChecklistTemplate, wikiUser);
        }

        public void GetDeploymentRegions()
        {
            var utilities = new DeploymentUtilities();
            
            DeploymentRegions = utilities.GetDeploymentRegions();
        }        
    }
}