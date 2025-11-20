using Newtonsoft.Json;
using System;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// <remarks></remarks>
    /// </summary>
    public abstract class TraditionalLifePolicy : LifePolicy
    {
        /// <summary>IEW Flag, typically set to 1</summary>
        public int FaceCode { get; set; }

        /// <summary>FIP:FacePremAmt</summary>
        public decimal FaceAmount { get; set; }

        /// <summary>FIP:FacePremAmt, this field was split out of the original FIP field.
        /// Used for a reverse solve (solving for face) scenarios.</summary>
        public decimal PremiumAmount { get; set; }

        /// <summary>FIP:PremMode, code indicating frequency of premium payment. (Annual, Semi-annual, Quarterly, Monthly)</summary>
        public int PremiumMode { get; set; }

        /// <summary>Policy issue date</summary>
        public DateTime CertificateDate { get; set; }

        /// <summary>State abbreviation for lodge state of the insured</summary>
        public string LodgeState { get; set; }

        /// <summary>Number of the lodge of the insured</summary>
        public string LodgeNumber { get; set; }

        public DateTime WaiverDate { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
