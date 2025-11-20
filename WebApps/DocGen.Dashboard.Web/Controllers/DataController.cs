using log4net;
using LPA.Dashboard.Web.Code;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WOW.IllustrationMgmntTool.Common.Extensions;

namespace LPA.Dashboard.Web.Controllers
{
    [RoutePrefix("api/Data")]
    public class DataController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DataController));
        
        [HttpGet]
        [Route("TestGroups")]
        public IHttpActionResult TestGroups(string id)
        {

            if (log.IsInfoEnabled) log.Info($"API TestGroups called with productTypeCode: {id} by {Request.GetClientIpAddress()}.");
            
            try
            {
                TestGroupUtils testGroupUtils = new TestGroupUtils();

                List<System.Web.Mvc.SelectListItem > testGroups = testGroupUtils.GetTestGroupList(id);


                if (log.IsInfoEnabled) log.Info($"API returning testGroups: {testGroups.ToString()}.");
                return Ok(testGroups);
            }
            catch (Exception ex)
            {
                if (log.IsFatalEnabled) log.Fatal($"Exception: {ex.Message}.", ex);

                //don't return our internal error message, create a new one to return
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                message.Content = new StringContent(ex.Message);
                throw new HttpResponseException(message);
            }

        }
    }
}
