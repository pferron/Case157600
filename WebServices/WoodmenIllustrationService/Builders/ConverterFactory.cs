using System;
using WoodmenLife.Enterprise.Illustration.Models.Titanium;
using log4net;
using WOW.Illustration.Model.Generation.Request;
using WOW.WoodmenIllustrationService.Exceptions;
// TODO - FWB
namespace WOW.WoodmenIllustrationService.Builders
{
    public class ConverterFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ConverterFactory));

        internal static Policy CreaterConverter(TiPolicyDetail illustrationRequest)
        {
            if (log.IsInfoEnabled) log.InfoFormat($"CreaterConverter called with illustrationRequest.ProductTypeCode: {illustrationRequest.ProductType.Code}.");

            switch (illustrationRequest.ProductType.Code.ToUpper())
            {
                case "INDXUL":
                    return GenerateIndexedUniversalLifeWIM(illustrationRequest);
                case "UL":
                    return GenerateAdjustableLifeFlexibleLifeWIM(illustrationRequest);
                default:
                    throw new PolicyConverterException($"CreaterConverter - Invalid productTypeCode: {illustrationRequest.ProductType.Code} specified.");
            }
        }

        private static Policy GenerateIndexedUniversalLifeWIM(TiPolicyDetail illustrationRequest)
        {
            if (log.IsInfoEnabled) log.InfoFormat($"GenerateIndexedUniversalLifeWIM called with illustrationRequest: {illustrationRequest}.");

            try
            {
                // Create WIM factory
                var converter = IndexedUniversalLifePolicyConverter.CreateConverter(illustrationRequest);

                return converter.HydratePolicyData();
            }
            catch (Exception ex)
            {
                throw new PolicyConverterException("GenerateIndexedUniversalLifeWIM: Failed to generate WIM object from illustrationRequest.", ex);
            }
        }

        private static Policy GenerateAdjustableLifeFlexibleLifeWIM(TiPolicyDetail illustrationRequest)
        {
            if (log.IsInfoEnabled) log.InfoFormat($"GenerateIndexedUniversalLifeWIM called with illustrationRequest: {illustrationRequest}.");

            try
            {
                // Create WIM factory
                var converter = AdjustableLifeFlexibleLifePolicyConverter.CreateConverter(illustrationRequest);

                return converter.HydratePolicyData();
            }
            catch (Exception ex)
            {
                throw new PolicyConverterException("GenerateAdjustableLifeFlexibleLifeWIM: Failed to generate WIM object from illustrationRequest.", ex);
            }
        }
    }
}