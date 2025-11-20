using log4net;
using Newtonsoft.Json;
using System;
using System.Globalization;
using WOW.Illustration.Model.Generation.Response;

namespace WOW.MyWoodmenIllustrationClient.Utilities
{
    /// <summary>
    /// This class contains helper methods for working with messages.
    /// </summary>
    internal static class MessageHelper
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(MessageHelper));

        internal static WoodmenIllustrationResponse UnpackWoodmenIllustrationResponse(string message)
        {
            if (message == null)
            {
                var errorMessage = "UnpackWoodmenIllustrationResponse - Null message received.";
                if (logger.IsErrorEnabled) logger.Error(errorMessage);
                throw new ArgumentNullException("message", errorMessage);
            }
            else if (string.IsNullOrWhiteSpace(message))
            {
                var errMessage = "UnpackWoodmenIllustrationResponse - Empty message received.";
                if (logger.IsErrorEnabled) logger.Error(errMessage);
                throw new ArgumentOutOfRangeException("message", errMessage);
            }

            if (logger.IsDebugEnabled) logger.DebugFormat(CultureInfo.InvariantCulture, "UnpackWoodmenIllustrationResponse - message received. {0}", message);

            // Try to deserialize message
            var response = JsonConvert.DeserializeObject<WoodmenIllustrationResponse>(message);

            // if (logger.IsDebugEnabled) logger.DebugFormat(CultureInfo.InvariantCulture, "UnpackWoodmenIllustrationResponse - Response message - {0}", response);
            return response;
        }
        /// <summary>
        ///     convert base 64 string to binary stream for portal
        /// </summary>
        /// <param name="pdf"></param>
        /// <returns></returns>

    }
}
