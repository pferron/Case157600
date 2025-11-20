using System;
using log4net;
using System.Collections.Generic;
using System.Linq;
using Wow.IllustrationCommonModels.Request;


namespace Wow.CommonIllustrationService.DAO
{
    /// <summary>
    /// Thrown when an entity element is not found that corresponds to the provided input value.
    /// </summary>
    [Serializable()]
    public class EntityValueNotFoundException : System.Exception
    {
        public EntityValueNotFoundException() : base() { }
        public EntityValueNotFoundException(string message) : base(message) { }
        public EntityValueNotFoundException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected EntityValueNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }

    public enum RiderType
    {
        None,
        AcceleratedDeathRider,
        WaiverOfPremiumRider,
        WaiverOfMonthlyDeductionRider,
        AccidentalDeathBenefitRider,
        GuarateedInsurabilityRider
    }

    public enum ConversionType
    {
        Rating,
        BillingMode,
        BillingMethod,
        RiderCode,
        IsSmoker,
        PreferredRating,
        CommonRiderEnum
    }

    public static class EntitiesRepository
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(EntitiesRepository));

        static public Dictionary<string, BasePlan> Plans { get; private set; }
        static public Dictionary<int, HeaderCode> HeaderCodes { get; private set; }
        static public Dictionary<string, StateCode> States { get; private set; }
        static public Dictionary<string, string> Conversions { get; private set; }
        static EntitiesRepository()
        {

            using(var db=new IllusWisEntities())
            {
                Plans = new Dictionary<string, BasePlan>();
                foreach (var row in db.BasePlans)
                    Plans.Add(row.PlanId, row);

                HeaderCodes = new Dictionary<int, HeaderCode>();
                foreach (var row in db.HeaderCodes)
                    HeaderCodes.Add(row.HeaderCode1, row);

                States = new Dictionary<string, StateCode>();
                foreach (var row in db.StateCodes)
                    States.Add(row.Abbr, row);

                Conversions = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (var row in db.Conversions)
                    if (row.start <= DateTime.Now && row.expiration > DateTime.Now)
                        Conversions.Add(row.ConversionId + row.CommonVal, row.LpaVal);

                foreach (string name in Enum.GetNames(typeof(ConversionType)))
                    try
                    {
                        db.ConversionIds.Single(row => row.ConversionId1 == name);
                    }
                    catch (Exception ex)
                    {
                        {
                            var ex1 = new EntityValueNotFoundException($"Converion Type {name} not present in ConversionIds Table", ex);
                            if (log.IsErrorEnabled)
                                log.Error($"Exception:\r\n{ex1.ToString()}");
                            throw ex1;
                        }
                    }
            }
            if (log.IsInfoEnabled) { log.Info($"Illustration Entities loaded - Base Plans:{Plans.Count}; Header Codes:{HeaderCodes.Count}; States:{States.Count}; Conversions:{Conversions.Count}"); }
        
        }
        static public BasePlan GetPlan(string code)
        {
            if (!Plans.ContainsKey(code))
            {
                var ex1 = new EntityValueNotFoundException($"Unknown Base Plan {code}.");
                if(log.IsErrorEnabled)
                    log.Error($"Exception:\r\n{ex1.ToString()}");
                throw ex1;
            }


            var plan = Plans[code];
            return plan;
        }
        static public HeaderCode GetHeaderCode(int hc)
        {
            if (!HeaderCodes.ContainsKey(hc))
            {
                var ex1 = new EntityValueNotFoundException($"Unknown Header {hc}.");
                if (log.IsErrorEnabled)
                    log.Error($"Exception:\r\n{ex1.ToString()}");
                throw ex1;
            }

            return HeaderCodes[hc]; ;
        }
        static public StateCode GetState(string code)
        {
            if (!States.ContainsKey(code))
                {
                var ex1 = new EntityValueNotFoundException($"Unknown State {code}.");
                if (log.IsErrorEnabled)
                    log.Error($"Exception:\r\n{ex1.ToString()}");
                throw ex1;
            }

            return States[code];
        }
        static public int GetRating(string tivalue)
        {
            if (int.TryParse(Convert(ConversionType.Rating.ToString(), tivalue), out int ratingcode))
                return ratingcode;
            else
            {
                var ex1 = new ArgumentException($"Not numeric value for \"Rating Class\": {tivalue}");
                if (log.IsErrorEnabled)
                    log.Error($"Exception:\r\n{ex1.ToString()}");
                throw ex1;
            }
        }
        static public int GetRiderType(string tivalue)
        {
            if (int.TryParse(Convert(ConversionType.RiderCode.ToString(), tivalue), out int intvalue))
                return intvalue;
            else
            {
                var ex1 = new ArgumentException($"Not numeric value for \"Rider Type Code\": {tivalue}");
                if (log.IsErrorEnabled)
                    log.Error($"Exception:\r\n{ex1.ToString()}");
                throw ex1;
            }
        }
        static public int GetBillingMethod(string tivalue)
        {
            if (int.TryParse(Convert(ConversionType.BillingMethod.ToString(), tivalue, true), out int intvalue))
                return intvalue;
            else
            {
                var ex1 = new ArgumentException($"Not numeric value for \"Billing Method\": {tivalue}");
                if (log.IsErrorEnabled)
                    log.Error($"Exception:\r\n{ex1.ToString()}");
                throw ex1;
            }
        }
        static public int GetBillingMode(string tivalue)
        {
            if (int.TryParse(Convert(ConversionType.BillingMode.ToString(), tivalue, true), out int intvalue))
                return intvalue;
            else
            {
                var ex1 = new ArgumentException($"Not numeric value for \"Billing Mode\": {tivalue}");
                if (log.IsErrorEnabled)
                    log.Error($"Exception:\r\n{ex1.ToString()}");
                throw ex1;
            }
        }
        static public bool IsSmoker(string tivalue)
        {
            if (bool.TryParse(Convert(ConversionType.IsSmoker.ToString(), tivalue, true), out bool boolvalue))
                return boolvalue;
            else
            {
                var ex1 = new ArgumentException($"Not Thruth value for \"IsSmoker\": {tivalue}");
                if (log.IsErrorEnabled)
                    log.Error($"Exception:\r\n{ex1.ToString()}");
                throw ex1;
            }
        }
        static public int PreferredRating(string tivalue)
        {
            if (int.TryParse(Convert(ConversionType.PreferredRating.ToString(), tivalue, true), out int intvalue))
                return intvalue;
            else
            {
                var ex1 = new ArgumentException($"Not numeric value for \"PreferredRating\": {tivalue}");
                if (log.IsErrorEnabled)
                    log.Error($"Exception:\r\n{ex1.ToString()}");
                throw ex1;
            }
        }
        static public RiderType GetCommonRiderEnum(string tivalue)
        {
            string name = Convert(ConversionType.CommonRiderEnum.ToString(), tivalue);
            if (Enum.TryParse(name, true, out RiderType type))
                return type;
            else
            {
                var ex1 = new ArgumentException($"Not defined in \"CommonRiderType\" Enum: {tivalue}");
                if (log.IsErrorEnabled)
                    log.Error($"Exception:\r\n{ex1.ToString()}");
                throw ex1;
            }
        }
        static public string Convert(string titable, string tivalue, bool defaultvalue = false)
        {
            string key = titable + tivalue;
            if (Conversions.ContainsKey(key))
            {
                return Conversions[key];
            }
            else
            {
                if (defaultvalue)
                {
                    key = titable + "<Default>";
                    if (Conversions.ContainsKey(key))
                        return Conversions[key];
                }
                {
                    var ex1 = new EntityValueNotFoundException($"Conversion table '{titable}' doesn't contain \"{key}\".");
                    if (log.IsErrorEnabled)
                        log.Error($"Exception:\r\n{ex1.ToString()}");
                    throw ex1;
                }
            }
        }
    }
}