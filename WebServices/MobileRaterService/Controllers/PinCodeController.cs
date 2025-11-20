using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WOW.MobileRaterService.Models;
using WOW.MobileRaterService.Data;
using log4net;
using System.Threading.Tasks;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;

namespace WOW.MobileRaterService.Controllers
{
    public class PinCodeController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(PinCodeController));

        /// <summary>
        /// Accepts POST to login with Pin Code
        /// </summary>
        /// <param name="input">PIN code and Sales Rep code</param>
        /// <returns>1 on success, 0 on failure</returns>
        [HttpPost]
        public int ValidatePin(PinInput input)
        {
            if(input == null)
            {
                throw new ArgumentNullException("input", "PinInput model cannot be null.");
            }

            if(!input.IsValid())
            {
                throw new ArgumentException("One or more properties of the PinInput are null or empty.", "input");
            }

            try
            {
                return PinDAO.ValidatePinCode(input.PinCode, input.SalesRepCode);
            }
            catch (Exception ex)
            {
                if(log.IsErrorEnabled) { log.Error("DB Error", ex); }
                
                return 0;
            }
        }
    }

}
