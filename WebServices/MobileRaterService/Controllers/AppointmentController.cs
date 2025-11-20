using log4net;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WOW.MobileRaterService.Data;
using WOW.MobileRaterService.Filters;
using WOW.MobileRaterService.Properties;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;

namespace WOW.MobileRaterService.Controllers
{
    public class AppointmentController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AppointmentController));

        [HttpPost]
        [CheckModelForNull]
        public void UpdateAppointment (AppointmentInput model)
        {
            Guid _quoteId;

            if(!Guid.TryParse(model.QuoteId, out _quoteId))
            {
                if (log.IsErrorEnabled) { log.Error($"QuoteId '{model.QuoteId}' could not be parsed to a GUID."); }

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "QuoteId is not a valid GUID."));
            }

            try
            {
                using (var dbContext = new MwagDbContext())
                {
                    dbContext.Database.CommandTimeout = (int)Settings.Default.DatabaseQueryTimeout.TotalSeconds;

                    var record = dbContext.QuoteRequests.Where(r => r.ID == _quoteId).FirstOrDefault();

                    if (record != null)
                    {
                        record.LikedQuote = model.HasAppointment;
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,"Quote record was not found."));
                    }
                }
            }
            catch(Exception ex)
            {
                if(log.IsErrorEnabled) { log.Error($"An error occurred while updating quote record '{model.QuoteId}'.", ex); }

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"An error occurred while updating quote record '{model.QuoteId}'."));
            }
        }
    }
}
