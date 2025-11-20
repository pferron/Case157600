using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WOW.MobileRaterService.Data;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Responses;

namespace WOW.MobileRaterService.Code
{
    internal static class ReverseProcessor
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ReverseProcessor));
        internal static List<ReverseLookupResponse> CreateReverseLookupResponse(ReverseLookupInput input)
        {
            var returnObject = new List<ReverseLookupResponse>();

            var parameterList = new List<SqlParameter>
            {
                new SqlParameter("@MaxMonthlyPremium", input.MaximumMonthlyValue),
                new SqlParameter("@MinMontlyPremium", input.MinimumMonthlyValue),
                new SqlParameter("@Gender", input.Gender),
                new SqlParameter("@Age", input.Age),
                new SqlParameter("@Tabacco", input.Tobacco),
                new SqlParameter("@AioGir", input.AioGir),
                new SqlParameter("@FaceAmount", input.FaceAmount)
            };

            using (var ef = new MobileRaterServiceEntities())
            {
                returnObject = ef.Database.SqlQuery<ReverseLookupResponse>("exec dbo.FetchReverseProducts @MaxMonthlyPremium, @MinMontlyPremium, @Gender, @Age," +
                    "@Tabacco, @AioGir, @FaceAmount", parameterList.ToArray()).ToList();
            }

            return returnObject;
        }
    }
}