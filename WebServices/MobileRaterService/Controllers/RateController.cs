using System;
using System.Collections.Generic;
using log4net;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WOW.MobileRaterService.Filters;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Responses;
using WOW.MobileRaterService.Builders;
using WOW.MobileRaterService.Code;

namespace WOW.MobileRaterService.Controllers
{
    public class RateController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(RateController));

        [HttpPost]
        [CheckModelForNull]
        [ValidateRaterRequestModel]
        public List<RateResponse> FetchIndependenceSeriesRates(IndependenceRateInput model)
        {
            try
            {
                return IndependenceProcessor.CreateIndependenceResponse(model);
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error("An error occurred while fetching Independence Series rates.", ex); }

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]
        [CheckModelForNull]
        [ValidateRaterRequestModel]
        public List<RateResponse> FetchFamilyTermRates(FamilyTermRateInput model)
        {
            try
            {
                return FamilyTermProcessor.CreateFamilyTermRateResponse(model);
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error("An error occurred while fetching Family Term rates.", ex); }

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]
        [CheckModelForNull]
        [ValidateRaterRequestModel]
        public List<RateResponse> FetchPatriotSeriesRate(PatriotInput model)
        {
            if (logger.IsDebugEnabled) logger.Debug($"FetchPatriotSeriesRate called with PatriotInput: {model.ToString()}.");

            try
            {
                return PatriotProcessor.CreatePatriotResponse(model);
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error("An error occurred while fetching Patriots Series rates.", ex); }

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]  
        public List<RateResponse> FetchLifeRatesByHeaderCode(LifeRateInput model, int headerCode, DateTime? rateDeterminationDate)
        {
            List<RateResponse> result = new List<RateResponse>();

            try
            {
                return LifeRateProcessor.CreateLifeRateResponse(model, headerCode,rateDeterminationDate);
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error("An error occurred while fetching Life rates.", ex); }

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]
        [CheckModelForNull]
        [ValidateRaterRequestModel]
        public List<RateResponse> FetchLifeRates(LifeRateInput model)
        {
            List<RateResponse> result = new List<RateResponse>();

            try
            {
                return LifeRateProcessor.CreateLifeRateResponse(model);
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error("An error occurred while fetching Life rates.", ex); }

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                throw new HttpResponseException(errorResponse);
            }
        }
        
        [HttpPost]
        public List<ReverseLookupResponse> FetchReverseRates(ReverseLookupInput model)
        {
            try
            {
                return ReverseProcessor.CreateReverseLookupResponse(model);
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error("An error occurred while fetching reverse rates.", ex); }

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                throw new HttpResponseException(errorResponse);
            }
        }
        
    }
}
