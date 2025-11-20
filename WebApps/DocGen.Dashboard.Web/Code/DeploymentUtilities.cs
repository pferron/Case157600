using log4net;
using LPA.Dashboard.Web.Helpers;
using LPA.Dashboard.Web.Hubs;
using LPA.Dashboard.Web.Models;
using Microsoft.Win32.TaskScheduler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WOW.IllustrationMgmntTool.Common.Code;
using WOW.IllustrationMgmntTool.Common.DAL;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.DBO;
using WOW.IllustrationMgmntTool.Common.Models;
using WOW.IllustrationMgmntTool.Common.Models.Deployment;
using WOW.IllustrationMgmntTool.Common.Models.Deployment.Checklist;
using WOW.IllustrationMgmntTool.Common.Models.Deployment.Puppet;

namespace LPA.Dashboard.Web.Code
{
    /// <summary>
    /// Deployment Utilities
    /// </summary>
    internal class DeploymentUtilities
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DeploymentUtilities));

        private readonly DeploymentLogic logic = new DeploymentLogic();

        /// <summary>
        /// Get the list of remote system updates in descending order by the ResourceUpdateId's
        /// </summary>
        /// <returns>The list of deployments</returns>
        internal List<DeploymentModel> GetDeployments()
        {
            if (log.IsInfoEnabled) log.Info("GetDeployments called.");

            var deployments = logic.GetDeployments();

            deployments.ForEach(deployment => deployment.Deployments
            .ForEach(dep => dep.ChecklistUrl = !string.IsNullOrEmpty(dep.ChecklistDetail) && !dep.ChecklistDetail.StartsWith("Error")
                ? $"{Properties.Settings.Default.WikiBaseUrl}/pages/viewpage.action?pageId={dep.ChecklistDetail}"
                : string.Empty));

            return deployments;
        }

        /// <summary>
        /// Get all deployment regions so that we can populate the form
        /// </summary>
        /// <returns>all regions</returns>
        internal List<DeploymentRegionDao> GetDeploymentRegions()
        {
            if (log.IsInfoEnabled) log.Info("GetDeploymentRegions called.");

            return logic.GetDeploymentRegions();
        }

        /// <summary>
        /// Get checklist templates for the specified region id so that we can populate the form
        /// </summary>
        /// <returns>region checklist templates</returns>
        internal List<ChecklistTemplateDao> GetChecklistTemplates(int regionId)
        {
            if (log.IsInfoEnabled) log.Info("GetDeploymentRegions called.");

            return logic.GetChecklistTemplates(regionId);
        }

        /// <summary>
        /// Create a remote system update
        /// </summary>
        /// <param name="resource">The information used to create the update that is passed to the logic layer</param>
        internal async System.Threading.Tasks.Task CreateRemoteSystemUpdate(ResourceUpdateBdo resource, int regionId, int checklistId, string wikiUser)
        {
            if (log.IsInfoEnabled) log.Info($"CreateRemoteSystemUpdate called with resource: {resource}.");

            List<DeploymentRegionDao> affectedRegions = logic.GetRegionsByChecklist(checklistId);
            var version = "";
            var localPath = "";
            var newGuid = Guid.NewGuid();

            foreach (DeploymentRegionDao region in affectedRegions)
            {
                regionId = region.DeploymentRegionId;

                var destinations = logic.GetDeploymentDestinations(regionId);
                //var region = logic.GetDeploymentRegion(regionId);

                //deploy for each location in folder(s)
                //to ensure that all regions in a location have the same guid once must be created and passed into the processor

                //resource.ResourceGuid = Guid.NewGuid();
                resource.ResourceGuid = newGuid;

                var versionProcessor = new Processor(destinations.First().RemoteSystemUpdatesFolderPath,
                        resource.File, resource.Description, resource.ResourceGuid, region.ServerUrl, region.PromotePath, region.ConnectionString,
                        resource.DeploymentScheduled.ToString("yyyy-MM-dd"), resource.Version);

                try
                {
                    version = versionProcessor.Process();

                    if (!string.IsNullOrEmpty(localPath))
                    {
                        localPath += " AND " + versionProcessor.LocalPath;
                    }
                    else
                    {
                        localPath = versionProcessor.LocalPath;
                    }

                    resource.Version = version;

                    //the deployment is currently inside of the promote folder and now should be put on the local promote folder on the servers
                    foreach (var location in destinations)
                    {
                        versionProcessor.CopyFilesToLocalServer(location.LocalPromotePath);
                        //versionProcessor.CopyFilesToRemoteSystemUpdatePath(location.RemoteSystemUpdatesFolderPath);
                        //TODO: Version 2
                        //versionProcessor.UpdateVersionFile(location.WebServerPath);
                        //versionProcessor.UpdateVersionFile(location.AppServerPath);
                        //versionProcessor.UpdateVersionFile(location.LifeServerPath);
                    }
                }
                catch (Exception ex)
                {
                    if (log.IsErrorEnabled) log.Error("unable to process", ex);

                    foreach (var logItem in versionProcessor.Log)
                    {
                        if (log.IsDebugEnabled) log.Debug(logItem);
                    }

                    List<string> list = Properties.Settings.Default.DevEmailAddress.Cast<string>().ToList();

                    string templatePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/errordeployed.html");

                    //read the path
                    var errorBody = File.ReadAllText(templatePath);

                    SmtpHelper.Send(list.ToArray(), "Urgent Automated Deployment Notification", errorBody, true, versionProcessor.Log);

                    throw;
                }
            }

            var checklist = logic.GetChecklistTemplate(checklistId);
            checklist.Body = string.Format(checklist.Body, resource.DeploymentScheduled.ToString("yyyy-MM-dd"), resource.CreatedBy, DateTime.Today.ToString("MM/dd/yyyy"), resource.Version);
            checklist.Title = string.Format(checklist.Title, resource.DeploymentScheduled.ToString("MMMM dd, yyyy"));

            var response = await PublishChecklist(checklist, wikiUser, resource.WikiPassword);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                resource.ChecklistDetails = response.Message;
            }

            logic.CreateRemoteSystemUpdate(resource, affectedRegions);

            string body = PrepareEmailNotification(new EmailModel
            {
                Version = version,
                Description = resource.Description,
                ResultType = "success",
                Result = "successfully",
                Path = $"{Properties.Settings.Default.WikiBaseUrl}/pages/viewpage.action?pageId={resource.ChecklistDetails}",
                DeployedBy = resource.CreatedBy,
                Region = checklist.TemplateName,
                Date = DateTime.Now.ToString("dddd, MMMM dd yyyy")
            });

            //if the debugger is attached we can assume that the deployment method is being 
            //tested and should only send the email to developers
            if (System.Diagnostics.Debugger.IsAttached)
            {
                List<string> list = Properties.Settings.Default.DevEmailAddress.Cast<string>().ToList();

                SmtpHelper.Send(list.ToArray(), "Automated Deployment Notification", body, true);
            }
            else
            {
                List<string> list = Properties.Settings.Default.ProductionEmailAddress.Cast<string>().ToList();
                SmtpHelper.Send(list.ToArray(), "Automated Deployment Notification", body, true);
            }
        }

        /// <summary>
        /// Prepare an email for sending by replacing the values in the template with the
        /// correct values for the update that has been deployed
        /// </summary>
        /// <param name="model">The model that is used to create and email</param>
        /// <returns>The HTML template with the correct values to pass into the email sender</returns>
        private string PrepareEmailNotification(EmailModel model)
        {
            if (log.IsInfoEnabled) log.Info($"PrepareEmailNotification called with resource: {model}.");

            //get the template path
            string templatePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/deployed.html");

            //read the path
            var content = File.ReadAllText(templatePath);

            //replace the properties in the template
            content = content.Replace("{version}", model.Version);
            content = content.Replace("{description}", model.Description);
            content = content.Replace("{resultType}", model.ResultType);
            content = content.Replace("{result}", model.Result);
            content = content.Replace("{region}", model.Region);
            content = content.Replace("{deployedBy}", model.DeployedBy);
            content = content.Replace("{path}", model.Path);
            content = content.Replace("{date}", model.Date);

            //return the content
            return content;
        }

        /// <summary>
        /// Deploy a remote system update to any region that it has not already been deployed to
        /// </summary>
        /// <param name="RSUId"></param>
        /// <param name="resource"></param>
        /// <param name="regionId"></param>
        /// <param name="checklistId"></param>
        /// <param name="wikiUser"></param>
        /// <returns>An API response corresponding to the result of the action.</returns>
        internal async System.Threading.Tasks.Task DeployToNextRegion(int RSUId, ResourceUpdateBdo resource, int regionId, int checklistId, string wikiUser)
        {
            if (log.IsInfoEnabled) log.Info($"DeployToNextRegion called for RSU ID: {RSUId}.");

            List<DeploymentRegionDao> affectedRegions = logic.GetRegionsByChecklist(checklistId);
            var version = "";
            var localPath = "";

            //get a list of all of the deployments for the remote system update specified in the model
            var deployments = logic.GetDeploymentsByResourceId(RSUId);

            //This is moving inside the loop to account for multiple regions at once.  This was preventing INT from deploying correctly
            //get all of the destiantions that the deployment will go to.            
            //var destinations = logic.GetDeploymentDestinations(regionId);

            //since the files have to be the same on all servers once they're deployed the location that we 
            //start the copy from should not matter as long as it was deployed. so if we just grab one
            //from the first element in the list it should be fine.
            var firstDeployment = deployments[0];

            //get the physical path of one of the deployments so that we can just copy all of the files
            //and then add the version folder to path
            var previousLocation = logic.GetDeploymentDestinations(firstDeployment.Region).First().RemoteSystemUpdatesFolderPath;
            previousLocation = Path.Combine(previousLocation, firstDeployment.Version);

            //the update as a whole
            var update = logic.GetResourceUpdateById(RSUId);

            foreach (DeploymentRegionDao region in affectedRegions)
            {
                //get all of the destiantions that the deployment will go to.
                var destinations = logic.GetDeploymentDestinations(region.DeploymentRegionId);

                //deploy for each location in folder(s)  
                var versionProcessor = new Processor(destinations.First().RemoteSystemUpdatesFolderPath,
                previousLocation, update.ResourceGuid, region.ServerUrl, region.PromotePath, region.ConnectionString, update.Description, resource.DeploymentScheduled.ToString("yyyy-MM-dd"), resource.Version);
                
                try
                {
                    if (!string.IsNullOrEmpty(localPath))
                    {
                        localPath += " AND " + versionProcessor.LocalPath;
                    }
                    else
                    {
                        localPath = versionProcessor.LocalPath;
                    }

                    //attempt to process the update
                    version = versionProcessor.ProcessAlreadyDeployed();

                    //the deployment is currently inside of the promote folder and now should be put on the local promote folder on the servers
                    foreach (var location in destinations)
                    {
                        versionProcessor.CopyFilesToLocalServer(location.LocalPromotePath);
                        //versionProcessor.CopyFilesToRemoteSystemUpdatePath(location.RemoteSystemUpdatesFolderPath);
                        //TODO: Version 2
                        //versionProcessor.UpdateVersionFile(location.WebServerPath);
                        //versionProcessor.UpdateVersionFile(location.AppServerPath);
                        //versionProcessor.UpdateVersionFile(location.LifeServerPath);
                    }

                    foreach (var logItem in versionProcessor.Log)
                    {
                        if (log.IsDebugEnabled) log.Debug(logItem);
                    }
                }
                catch (Exception ex)
                {
                    if (log.IsErrorEnabled) log.Error("unable to process", ex);

                    foreach (var logItem in versionProcessor.Log)
                    {
                        if (log.IsDebugEnabled) log.Debug(logItem);
                    }

                    List<string> list = Properties.Settings.Default.DevEmailAddress.Cast<string>().ToList();

                    string templatePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/errordeployed.html");

                    //read the path
                    var errorBody = File.ReadAllText(templatePath);

                    SmtpHelper.Send(list.ToArray(), "Urgent Automated Deployment Notification", errorBody, true, versionProcessor.Log);

                    throw;
                }
            }

            var checklist = logic.GetChecklistTemplate(checklistId);
            checklist.Body = string.Format(checklist.Body, resource.DeploymentScheduled.ToString("yyyy-MM-dd"), resource.CreatedBy, DateTime.Today.ToString("MM/dd/yyyy"), resource.Version);
            checklist.Title = string.Format(checklist.Title, resource.DeploymentScheduled.ToString("MMMM dd, yyyy"));

            var response = await PublishChecklist(checklist, wikiUser, resource.WikiPassword);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                resource.ChecklistDetails = response.Message;
            }

            foreach (var region in affectedRegions)
            {
                logic.CreateDeployment(new DeploymentDao
                {
                    DeploymentDate = DateTime.Now,
                    Region = region.DeploymentRegionId,
                    Version = version,
                    ResourceUpdateId = RSUId,
                    DeployedBy = resource.CreatedBy,
                    ChecklistDetails = resource.ChecklistDetails,
                    DeploymentScheduled = resource.DeploymentScheduled.ToString("yyyy-MM-dd"),
                    Status = nameof(DeploymentStatus.READY)
                });
            }

            //prepare email
            string body = PrepareEmailNotification(new EmailModel
            {
                Version = version,
                Description = update.Description,
                ResultType = "success",
                Result = "successfully",
                Path = $"{Properties.Settings.Default.WikiBaseUrl}/pages/viewpage.action?pageId={resource.ChecklistDetails}",
                DeployedBy = update.CreatedBy,
                Region = checklist.TemplateName,
                Date = DateTime.Now.ToString("dddd, MMMM dd yyyy")
            });

            //if the debugger is attached we can assume that the deployment method is being 
            //tested and should only send the email to developers
            if (System.Diagnostics.Debugger.IsAttached)
            {
                List<string> list = Properties.Settings.Default.DevEmailAddress.Cast<string>().ToList();

                SmtpHelper.Send(list.ToArray(), "Automated Deployment Notification", body, true);
            }
            else
            {
                List<string> list = Properties.Settings.Default.ProductionEmailAddress.Cast<string>().ToList();
                SmtpHelper.Send(list.ToArray(), "Automated Deployment Notification", body, true);
            }

            //return new ApiResponseModel
            //{
            //    StatusCode = System.Net.HttpStatusCode.OK,
            //    Message = "Success!"
            //};
        }

        /// <summary>
        /// Since we have already saved the file somewhere we just need to get the version and move it to the correct places.
        /// </summary>
        private string ProcessFileFromFileSystem(int id)
        {
            if (log.IsInfoEnabled) log.Info($"ProcessFileFromFileSystem called with id: {id}.");

            //find the last version that was deployed.
            var lastDeployment = logic.GetDeploymentsByResourceId(id).OrderByDescending(d => d.DeploymentId).FirstOrDefault();

            //the actual region that we are deploying to.
            var nextRegion = logic.GetDeploymentRegion(lastDeployment.Region);

            //get the location of the new deployment region
            var nextFolderLocation = logic.GetDeploymentDestinations(nextRegion.NextDeploymentRegionId);

            //the last location where it was deployed.
            var previousFolderLocation = logic.GetDeploymentDestinations(lastDeployment.Region).First();

            var resourceUpdate = logic.GetResourceUpdateById(lastDeployment.ResourceUpdateId);

            string version = "";

            //deploy for each location in folder(s)
            //to ensure that all regions in a location have the same GUID once must be created and passed into the processor
            var newGuid = Guid.NewGuid();
            foreach (var location in nextFolderLocation)
            {
                var basePathOfLastFile = previousFolderLocation.RemoteSystemUpdatesFolderPath + lastDeployment.Version;
                //version = new Processor(location.RemoteSystemUpdatesFolderPath, basePathOfLastFile, newGuid, 
                //nextRegion.ServerUrl, resourceUpdate.Description).Process();
            }

            return version;
        }

        /// <summary>
        /// Deploy an update from the service
        /// </summary>
        /// <param name="id">the id of the resource update</param>
        internal ApiResponseModel DeployFromService(int id)
        {
            if (log.IsInfoEnabled) log.Info($"DeployFromService called with id: {id}.");

            //get the resource update 
            var resourceUpdate = logic.GetResourceUpdateById(id);

            //this shouldn't happen
            //TODO: Log this??
            if (resourceUpdate == null)
            {
                return new ApiResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = "Success!"
                };
            }

            //make sure that we aren't deploying a failure.
            if (resourceUpdate.Status == (int)Status.Fail)
            {
                //do nothing.
                return new ApiResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = "The update has already been marked as a failure. Dying silently.."
                };
            }

            //get the version
            var version = ProcessFileFromFileSystem(id);

            //since the deployment already exists we just need to find the last one and update it with this new information.
            var lastDeployment = logic.GetDeploymentsByResourceId(id).OrderByDescending(d => d.DeploymentId).FirstOrDefault();

            //check if the deployment already has a version. If this is the case it has already been deployed
            //and we can die quietly.
            if (string.IsNullOrEmpty(lastDeployment.Version))
            {
                return new ApiResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = "Unable to deploy because a version is going to happen in the future."
                };
            }

            lastDeployment.Version = version;

            //update the deployment
            logic.UpdateDeployment(lastDeployment);

            return new ApiResponseModel
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Success!"
            };
        }

        /// <summary>
        /// Mark a resource update as a failure.
        /// </summary>
        /// <param name="id">The id of the resource update</param>
        /// <returns>An api response model.</returns>
        internal ApiResponseModel MarkDeploymentAsFailure(int id)
        {
            if (log.IsInfoEnabled) log.Info($"MarkDeploymentAsFailure called with id: {id}.");

            //mark the update as a failure
            return logic.MarkResourceUpdateAsFailure(id);
        }

        /// <summary>
        /// Schedule a Deployment for the future
        /// </summary>
        internal ApiResponseModel ScheduleDeployment(ScheduledDeploymentModel deploymentModel)
        {
            if (log.IsInfoEnabled) log.Info($"ScheduleDeployment called with deploymentModel: {deploymentModel}.");

            deploymentModel.Date = deploymentModel.Date.ToLocalTime();
            var deploymentThreshold = DateTime.Now.AddMinutes(3).ToLocalTime();

            //validate that the deployment date isn't too soon
            if (deploymentThreshold > deploymentModel.Date)
            {
                return new ApiResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "A deployment must be scheduled at least 3 minutes in the future."
                };
            }

            //var resourceUpdate = logic.GetResourceUpdateById(deploymentModel.Id);
            //find the last version that was deployed.
            var lastDeployment = logic.GetDeploymentsByResourceId(deploymentModel.ResourceUpdateId).OrderByDescending(d => d.DeploymentId).FirstOrDefault();

            //check if the resource update doesn't exist
            if (lastDeployment == null)
            {
                return new ApiResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "The remote system update was not found"
                };
            }

            //The deployment has no where to go after production.
            if (lastDeployment.Region == (int)DeploymentRegion.Prod)
            {
                return new ApiResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "This item can not be moved any higher it is already in production"
                };
            }

            //If the version is '' then we know a version is going to be deployed in the future.
            if (lastDeployment.Version?.Length == 0)
            {
                return new ApiResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "A version is already scheduled to be deployed in the future."
                };
            }

            using (TaskService taskService = new TaskService())
            {
                // Create a new task definition and assign properties
                var td = taskService.NewTask();
                td.RegistrationInfo.Description = "Deployment of remote system update";

                td.Triggers.Add(new TimeTrigger() { StartBoundary = deploymentModel.Date });

                var arguments = new List<string>()
                {
                    deploymentModel.HostIp + "/api/DeploymentManagement/DeployFromScheduledService?id=" + deploymentModel.ResourceUpdateId
                };

                //have the deployment launch.
                td.Actions.Add(new ExecAction(@"C:\Work\tfs_dev\WOW.Illustration\1_DEVL\WindowsServices\ScheduleDeploymentService\bin\Debug\ScheduleDeploymentService.exe", string.Join(",", arguments), null));
                taskService.RootFolder.RegisterTaskDefinition("RSU update", td);

                //actually create the deployment.
                logic.CreateDeployment(new DeploymentDao
                {
                    ResourceUpdateId = deploymentModel.ResourceUpdateId,
                    DeploymentDate = deploymentModel.Date,
                    Region = lastDeployment.Region + 1,
                    DeployedBy = deploymentModel.Name,
                    Version = string.Empty
                });
            }

            return new ApiResponseModel
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Success!"
            };
        }

        /// <summary>
        /// Create Deployment Checklist
        /// </summary>
        /// <param name="deploymentId"></param>
        /// <param name="checklistId"></param>
        /// <param name="wikiUser"></param>
        /// <param name="wikiPassword"></param>
        /// <returns>ApiResponseModel</returns>
        internal async Task<ApiResponseModel> CreateDeploymentChecklist(int deploymentId, int checklistId, string wikiUser, string wikiPassword)
        {
            try
            {
                var dep = await logic.GetDeploymentById(deploymentId);

                var checklist = logic.GetChecklistTemplate(checklistId);
                checklist.Body = string.Format(checklist.Body, dep.DeploymentScheduled, dep.DeployedBy, dep.DeploymentDate.ToString("MM/dd/yyyy"), dep.Version);
                checklist.Title = string.Format(checklist.Title, DateTime.Parse(dep.DeploymentScheduled).ToString("MMMM dd, yyyy"));

                var response = await PublishChecklist(checklist, wikiUser, wikiPassword);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    dep.ChecklistDetails = response.Message;
                    logic.UpdateDeployment(dep);
                }

                return new ApiResponseModel { StatusCode = response.StatusCode, Message = response.StatusCode == System.Net.HttpStatusCode.OK ? "Checklist Created." : $"Create checklist failed: {response.Message}" };
            }
            catch (Exception ex)
            {
                return new ApiResponseModel { Message = $"Create checklist failed. - {ex.Message}", StatusCode = System.Net.HttpStatusCode.BadRequest };
            }
        }

        /// <summary>
        /// Delete Checklist
        /// </summary>
        /// <param name="deployment"></param>
        /// <param name="wikiUser"></param>
        /// <param name="wikiPassword"></param>
        /// <returns>ApiResponseModel</returns>
        internal async Task<ApiResponseModel> DeleteChecklist(ResourceUpdateModel deployment, string wikiUser, string wikiPassword)
        {
            var baseUrl = Properties.Settings.Default.WikiBaseUrl;

            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            var byteArray = System.Text.Encoding.ASCII.GetBytes($"{wikiUser}:{wikiPassword}");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var result = await client.DeleteAsync($"/rest/api/content/{deployment.ChecklistDetail}");

            if (result.IsSuccessStatusCode)
            {
                logic.ClearDeploymentChecklist(deployment.ChecklistDetail);

                return new ApiResponseModel { Message = "Checklist successfully deleted.", StatusCode = System.Net.HttpStatusCode.OK };
            }
            else
            {
                var responseContent = await result.Content.ReadAsStringAsync();
                try
                {
                    var badResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<WikiBadResponse>(responseContent);
                    return new ApiResponseModel { Message = $"Delete checklist failed: {badResponse.Message}", StatusCode = result.StatusCode };
                }
                catch (Exception)
                {
                    try
                    {
                        //Try to remove the HTML and CSS from the response
                        responseContent = Regex.Replace(Regex.Replace(responseContent, "(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", string.Empty), "<.*?>|&.*?;", string.Empty);

                        return new ApiResponseModel { Message = $"Delete checklist failed: {responseContent}", StatusCode = result.StatusCode };
                    }
                    catch (Exception)
                    {
                        return new ApiResponseModel { Message = responseContent, StatusCode = result.StatusCode };
                    }
                }
            }
        }

        /// <summary>
        /// Publish Checklist
        /// </summary>
        /// <param name="checklist"></param>
        /// <param name="wikiUser"></param>
        /// <param name="wikiPassword"></param>
        /// <returns>ApiResponseModel</returns>
        internal async Task<ApiResponseModel> PublishChecklist(ChecklistTemplateDao checklist, string wikiUser, string wikiPassword)
        {
            var baseUrl = Properties.Settings.Default.WikiBaseUrl;

            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            var byteArray = System.Text.Encoding.ASCII.GetBytes($"{wikiUser}:{wikiPassword}");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var searchResponse = await client.GetAsync($"/rest/api/content?title={checklist.Title}");
            if (searchResponse.IsSuccessStatusCode)
            {
                var searchResults = Newtonsoft.Json.JsonConvert.DeserializeObject<WikiContentSearchResponse>(await searchResponse.Content.ReadAsStringAsync());

                if (searchResults.Results.Count > 0)
                {
                    var existingPageId = searchResults.Results.FirstOrDefault().Id;
                    return new ApiResponseModel { Message = existingPageId, StatusCode = searchResponse.StatusCode };
                }
            }
            else
            {
                var responseContent = await searchResponse.Content.ReadAsStringAsync();
                try
                {
                    var badResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<WikiBadResponse>(responseContent);
                    return new ApiResponseModel { Message = $"Error: Search existing checklist failed - {badResponse.Message}", StatusCode = searchResponse.StatusCode };
                }
                catch (Exception)
                {
                    try
                    {
                        //Try to remove the HTML and CSS from the response
                        responseContent = Regex.Replace(Regex.Replace(responseContent, "(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", string.Empty), "<.*?>|&.*?;", string.Empty);

                        return new ApiResponseModel { Message = $"Error: Search existing checklist failed - {responseContent}", StatusCode = searchResponse.StatusCode };
                    }
                    catch (Exception)
                    {
                        return new ApiResponseModel { Message = $"Error: Search existing checklist failed - {responseContent}", StatusCode = searchResponse.StatusCode };
                    }
                }
            }

            var content = new WikiContent
            {
                Ttitle = checklist.Title
            };
            content.Body.Storage.Value = checklist.Body;
            content.Ancestors[0].Id = checklist.Ancestor;
            content.Metadata.Labels.Add(new WikiLabel { Name = checklist.Label });

            var requestBody = Newtonsoft.Json.JsonConvert.SerializeObject(content);
            var requestLabels = Newtonsoft.Json.JsonConvert.SerializeObject(content.Metadata.Labels);

            var buffer = System.Text.Encoding.UTF8.GetBytes(requestBody);
            var byteContent = new System.Net.Http.ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var result = await client.PostAsync("/rest/api/content", byteContent);

            if (result.IsSuccessStatusCode)
            {
                var newPage = Newtonsoft.Json.JsonConvert.DeserializeObject<WikiContentResponse>(await result.Content.ReadAsStringAsync());

                buffer = System.Text.Encoding.UTF8.GetBytes(requestLabels);
                byteContent = new System.Net.Http.ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                _ = await client.PostAsync($"/rest/api/content/{newPage.Id}/label", byteContent);

                //return new ApiResponseModel { Message = baseUrl + string.Format(pageUrl, newPage.Id), StatusCode = result.StatusCode };
                return new ApiResponseModel { Message = newPage.Id, StatusCode = result.StatusCode };
            }
            else
            {
                var responseContent = await result.Content.ReadAsStringAsync();
                try
                {
                    var badResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<WikiBadResponse>(responseContent);
                    return new ApiResponseModel { Message = $"Error: Publish checklist failed - {badResponse.Message}", StatusCode = result.StatusCode };
                }
                catch (Exception)
                {
                    try
                    {
                        //Try to remove the HTML and CSS from the response
                        responseContent = Regex.Replace(Regex.Replace(responseContent, "(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", string.Empty), "<.*?>|&.*?;", string.Empty);

                        return new ApiResponseModel { Message = $"Error: Publish checklist failed - {responseContent}", StatusCode = result.StatusCode };
                    }
                    catch (Exception)
                    {
                        return new ApiResponseModel { Message = $"Error: Publish checklist failed - {responseContent}", StatusCode = result.StatusCode };
                    }
                }
            }
        }

        /// <summary>
        /// Delete Deployment
        /// </summary>
        /// <param name="deployment"></param>
        /// <param name="wikiUser"></param>
        /// <param name="wikiPassword"></param>
        /// <returns>ApiResponseModel</returns>
        internal async Task<ApiResponseModel> DeleteDeployment(ResourceUpdateModel deployment, string wikiUser, string wikiPassword)
        {
            var dep = await logic.GetDeploymentById(deployment.DeploymentId);
            var resDeployments = logic.GetDeploymentsByResourceId(dep.ResourceUpdateId);
            var depRegion = logic.GetDeploymentRegion(dep.Region);
            var depDestinations = logic.GetDeploymentDestinations(dep.Region);

            if (dep != null)
            {
                try
                {
                    //Delete the Promote folder
                    var promoteRsuPath = Path.Combine(depRegion.PromotePath, "RSU", dep.DeploymentScheduled);
                    if (Directory.Exists(promoteRsuPath))
                    {
                        log.Info($"Deleting folder - {promoteRsuPath}");
                        Directory.Delete(promoteRsuPath, true);
                    }

                    //Delete the Server folders
                    foreach (var location in depDestinations)
                    {
                        var serverPath = Path.Combine(location.LocalPromotePath, dep.DeploymentScheduled);
                        if (Directory.Exists(serverPath))
                        {
                            log.Info($"Deleting folder - {serverPath}");
                            Directory.Delete(serverPath, true);
                        }
                    }

                    //Delete the checklist if there is one
                    if (!string.IsNullOrEmpty(dep.ChecklistDetails) && !dep.ChecklistDetails.StartsWith("Error:"))
                    {
                        var resp = await DeleteChecklist(deployment, wikiUser, wikiPassword);
                        if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                        {
                            return new ApiResponseModel { Message = $"Delete deployment failed. - Checklist delete failed - {resp.Message}", StatusCode = resp.StatusCode };
                        }
                    }

                    //Delete the deployment from the database
                    logic.DeleteDeployment(dep);

                    //If this was the only deployment for the resource update then delete the resource update
                    if (resDeployments.Count <= 1)
                    {
                        var res = logic.GetResourceUpdateById(dep.ResourceUpdateId);
                        if (res != null) { logic.DeleteResourceUpdate(res); }
                    }
                }
                catch (Exception ex)
                {
                    return new ApiResponseModel { Message = $"Delete deployment failed. - {ex.Message}", StatusCode = System.Net.HttpStatusCode.BadRequest };
                }

                return new ApiResponseModel { Message = "Deployment successfully deleted.", StatusCode = System.Net.HttpStatusCode.OK };
            }

            return new ApiResponseModel { Message = "Deployment Not Found.", StatusCode = System.Net.HttpStatusCode.NotFound };
        }

        /// <summary>
        /// Edit Deployment
        /// </summary>
        /// <param name="deployment"></param>
        /// <param name="checklistId"></param>
        /// <param name="wikiUser"></param>
        /// <param name="wikiPassword"></param>
        /// <returns>ApiResponseModel</returns>
        internal async Task<ApiResponseModel> EditDeployment(ResourceUpdateModel deployment, int checklistId, string wikiUser, string wikiPassword)
        {
            var dep = await logic.GetDeploymentById(deployment.DeploymentId);
            var depRegion = logic.GetDeploymentRegion(dep.Region);
            var depDestinations = logic.GetDeploymentDestinations(dep.Region);

            if (dep != null)
            {
                try
                {
                    //Rename the Promote folder
                    var promoteRsuPath = Path.Combine(depRegion.PromotePath, "RSU", dep.DeploymentScheduled);
                    var newPromoteRsuPath = Path.Combine(depRegion.PromotePath, "RSU", deployment.DeploymentScheduled);
                    if (Directory.Exists(promoteRsuPath))
                    {
                        log.Info($"Renaming folder - {promoteRsuPath} to {newPromoteRsuPath}");
                        Directory.Move(promoteRsuPath, newPromoteRsuPath);
                    }

                    //Rename the Server folders
                    foreach (var location in depDestinations)
                    {
                        var serverPath = Path.Combine(location.LocalPromotePath, dep.DeploymentScheduled);
                        var newServerPath = Path.Combine(location.LocalPromotePath, deployment.DeploymentScheduled);
                        if (Directory.Exists(serverPath))
                        {
                            log.Info($"Renaming folder - {serverPath} to {newServerPath}");
                            Directory.Move(serverPath, newServerPath);
                        }
                    }

                    //Update the deployment in the database
                    dep.DeploymentScheduled = deployment.DeploymentScheduled;
                    logic.UpdateDeployment(dep);

                    //Delete the old checklist if there is one
                    if (!string.IsNullOrEmpty(dep.ChecklistDetails) && !dep.ChecklistDetails.StartsWith("Error:"))
                    {
                        var resp = await DeleteChecklist(deployment, wikiUser, wikiPassword);
                        if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                        {
                            return new ApiResponseModel { Message = $"Edit Deployment failed. - Delete old checklist failed - {resp.Message}", StatusCode = resp.StatusCode };
                        }
                    }

                    var createResp = await CreateDeploymentChecklist(dep.DeploymentId, checklistId, wikiUser, wikiPassword);

                    if (createResp.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return new ApiResponseModel { Message = $"Edit Deployment failed. - Create new checklist failed - {createResp.Message}", StatusCode = createResp.StatusCode };
                    }
                }
                catch (Exception ex)
                {
                    return new ApiResponseModel { Message = $"Edit Deployment failed. - {ex.Message}", StatusCode = System.Net.HttpStatusCode.BadRequest };
                }

                return new ApiResponseModel { Message = "Deployment successfully updated.", StatusCode = System.Net.HttpStatusCode.OK };
            }

            return new ApiResponseModel { Message = "Deployment Not Found.", StatusCode = System.Net.HttpStatusCode.NotFound };
        }

        private async Task<string> ExecutePuppetTask(string puppetTask, string puppetToken)
        {
            try
            {
                var taskUri = "/orchestrator/v1/command/task";
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };

                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Properties.Settings.Default.PuppetBaseUrl)
                };

                client.DefaultRequestHeaders.Add("X-Authentication", puppetToken);

                var buffer = System.Text.Encoding.UTF8.GetBytes(puppetTask);
                var byteContent = new System.Net.Http.ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                var response = await client.PostAsync(taskUri, byteContent);
                if (response.IsSuccessStatusCode)
                {
                    var taskJob = JsonConvert.DeserializeObject<TaskExecuteResponse>(await response.Content.ReadAsStringAsync());
                    var jobId = taskJob.Job.Name;
                    return jobId;
                }
                else
                {
                    var puppetError = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());
                    throw new Exception(puppetError.Msg);
                }
            }
            catch (Exception ex)
            {
                log.Error($"Unable to execute Puppet task - {ex.Message}");
                throw new Exception($"Unable to execute Puppet task - {ex.Message}");
            }
        }

        private async Task<string> CheckPuppetJobStaus(string puppetJobId, string puppetToken)
        {
            try
            {
                var jobStatusUri = $"/orchestrator/v1/jobs/{puppetJobId}/report";
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };

                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Properties.Settings.Default.PuppetBaseUrl)
                };

                client.DefaultRequestHeaders.Add("X-Authentication", puppetToken);
                var statusResponse = await client.GetAsync(jobStatusUri);
                if (statusResponse.IsSuccessStatusCode)
                {
                    var report = JsonConvert.DeserializeObject<JobStatusResponse>(await statusResponse.Content.ReadAsStringAsync());

                    return report.Reports[0].State;
                }
                else
                {
                    var puppetError = JsonConvert.DeserializeObject<ErrorResponse>(await statusResponse.Content.ReadAsStringAsync());
                    throw new Exception(puppetError.Msg);
                }
            }
            catch (Exception ex)
            {
                log.Error($"Unable to check Puppet job status - {ex.Message}");
                throw new Exception($"Unable to check Puppet job status - {ex.Message}");
            }

        }

        internal async Task<ApiResponseModel> ExecuteDeployment(ResourceUpdateModel deployment)
        {
            DeploymentDao dep = null;
            try
            {
                dep = await logic.GetDeploymentById(deployment.DeploymentId);
                var depRegion = logic.GetDeploymentRegion(dep.Region);
                var depDestinations = logic.GetDeploymentDestinations(dep.Region);

                if (dep != null)
                {
                    dep.Status = nameof(DeploymentStatus.PROCESSING);
                    logic.UpdateDeployment(dep);                    
                    
                    var deploymentToken = depRegion.TokenValue;
                    var deploymentTask = depRegion.DeploymentTask.Replace("{sourceFolder}", dep.DeploymentScheduled);
                    var rebootTask = depRegion.RebootTask;

                    DeploymentStatusHub.UpdateClients("Puppet Deployment Task Starting");
                    //Execute the deployment task
                    var jobId = await ExecutePuppetTask(deploymentTask, deploymentToken);
                    bool complete = false;
                    while (!complete)
                    {
                        complete = (await CheckPuppetJobStaus(jobId, deploymentToken)).Equals("finished", StringComparison.OrdinalIgnoreCase);
                    }

                    DeploymentStatusHub.UpdateClients("Puppet Deployment Task Completed");

                    DeploymentStatusHub.UpdateClients("SQL Script Execution Starting");
                                        
                    var scriptsFolder = $"{depDestinations.FirstOrDefault().LocalPromotePath}\\{dep.DeploymentScheduled}\\{dep.Version}";
                    var depConnString = depRegion.ConnectionString;
                    var reconConnString = depRegion.ReconConnectionString;
                    var scripts = Directory.GetFiles(scriptsFolder, "*.sql");                    

                    foreach (var scriptFile in scripts)
                    {
                        var fi = new FileInfo(scriptFile);

                        var connString = fi.Name.Equals(depRegion.ReconScriptName, StringComparison.OrdinalIgnoreCase)
                            ? reconConnString
                            : depConnString;

                        await logic.ExecuteDeploymentSqlScripts(scriptFile, connString);
                        
                        log.Info($"Executing {scriptFile}");
                        DeploymentStatusHub.UpdateClients($"SQL Script {scriptFile} Executed Successfully");
                    }

                    DeploymentStatusHub.UpdateClients("SQL Scripts Execution Completed");

                    DeploymentStatusHub.UpdateClients("Puppet Reboot Task Starting");
                    //Execute the reboot task
                    jobId = await ExecutePuppetTask(rebootTask, deploymentToken);
                    complete = false;
                    while (!complete)
                    {                        
                        complete = (await CheckPuppetJobStaus(jobId, deploymentToken)).Equals("finished", StringComparison.OrdinalIgnoreCase);
                    }

                    DeploymentStatusHub.UpdateClients("Puppet Reboot Task Completed");

                    foreach (var item in depDestinations)
                    {
                        var uri = new Uri(item.LocalPromotePath);
                        var host = uri.Host;                        

                        DeploymentStatusHub.UpdateClients($"Checking Server {host} Reboot Status.");
                        var serverUp = false;
                        var ping = new Ping();

                        while (!serverUp)
                        {
                            var pingReply = await ping.SendPingAsync(host, 3000);
                            serverUp = pingReply.Status == IPStatus.Success;

                            var message = serverUp
                                ? $"Server {host} is back up."
                                : $"Server {host} - {pingReply.Status.ToString()}.";

                            DeploymentStatusHub.UpdateClients(message);
                        }
                    }

                    dep.Status = nameof(DeploymentStatus.COMPLETE);
                    logic.UpdateDeployment(dep);

                    DeploymentStatusHub.UpdateClients($"Deployment Successfully executed.");
                    return new ApiResponseModel { Message = "Deployment successfully executed.", StatusCode = System.Net.HttpStatusCode.OK };
                }
            }
            catch (Exception ex)
            {
                dep.Status = nameof(DeploymentStatus.ERROR);
                logic.UpdateDeployment(dep);

                log.Error($"Execute deployment failed. - {ex.Message}");

                DeploymentStatusHub.UpdateClients($"Deployment Execution Failed.");
                return new ApiResponseModel { Message = $"Execute deployment failed. - {ex.Message}", StatusCode = System.Net.HttpStatusCode.BadRequest };
            }

            return new ApiResponseModel { Message = "Deployment Not Found.", StatusCode = System.Net.HttpStatusCode.NotFound };
        }
    }
}