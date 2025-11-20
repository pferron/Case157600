using log4net;
using System;
using Wow.CommonIllustrationService.Exceptions;
using Wow.IllustrationCommonModels.Request;
using WOW.Illustration.Model.Generation.Request;

namespace Wow.CommonIllustrationService.Builders
{
    public class ConverterFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ConverterFactory));

        internal static Policy CreaterConverter(IllustrationRequest illustrationRequest)
        {
            if (log.IsInfoEnabled) log.InfoFormat($"CreaterConverter called with illustrationRequest.ProductTypeCode: {illustrationRequest.ProductTypeCode}.");

            switch (illustrationRequest.ProductTypeCode.ToUpper())
            {
                case "INDXUL":
                    return GenerateIndexedUniversalLifeWIM(illustrationRequest);

                default:
                    throw new PolicyConverterException($"CreaterConverter - Invalid productTypeCode: {illustrationRequest.ProductTypeCode} specified.");
            }
            
        }

        private static Policy GenerateIndexedUniversalLifeWIM(IllustrationRequest illustrationRequest)
        {
            if (log.IsInfoEnabled) log.InfoFormat($"GenerateIndexedUniversalLifeWIM called with illustrationRequest: {illustrationRequest.ToString()}.");

            try
            {
                // Create WIM factory
                var converter = IndexedUniversalLifePolicyConverter.CreateConverter(illustrationRequest);
                var wimObject = converter.HydratePolicyData();

                return wimObject;
            }
            catch (Exception ex)
            {
                throw new PolicyConverterException($"GenerateIndexedUniversalLifeWIM: Failed to generate WIM object from illustrationRequest.", ex);
            }
        }



    }
}