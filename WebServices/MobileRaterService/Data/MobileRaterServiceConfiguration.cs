using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.MobileRaterService.Data;
using WOW.MobileRaterService.Properties;

namespace WOW.MobileRaterService.Data
{
    internal static class MobileRaterServiceConfiguration
    {
        private static List<SupportedPlan> _plans;
        private static List<RiderRating> _riderRatings;
        private static List<RaterBillingOption> _raterBillingOptions;
        private static List<BillingMethod> _billingMethods;
        private static List<BillingMode> _billingModes;
        private static List<BaseRating> _baseRatings;
        private static List<StateSetting> _stateSettings;
        private static int _maxTableRating;
        private static int _maxRiderRating;

        static MobileRaterServiceConfiguration()
        {
            using (var ef = new MobileRaterServiceEntities())
            {
                ef.Database.CommandTimeout = (int)Settings.Default.DatabaseQueryTimeout.TotalSeconds;

                _plans = ef.SupportedPlans.ToList();
                _riderRatings = ef.RiderRatings.ToList();
                _raterBillingOptions = ef.RaterBillingOptions.ToList();
                _billingMethods = ef.BillingMethods.ToList();
                _billingModes = ef.BillingModes.ToList();
                _baseRatings = ef.BaseRatings.ToList();
                _stateSettings = ef.StateSettings.ToList();
                _maxTableRating = ef.BaseRatings.Max(r => r.Code);
                _maxRiderRating = ef.RiderRatings.Max(r => r.Code);
            }
        }

        internal static int MaxTableRating { get { return _maxTableRating; } }

        internal static int MaxRiderRating { get { return _maxRiderRating; } }

        internal static List<SupportedPlan> Plans { get { return _plans; } }

        internal static List<RiderRating> RiderRatings { get { return _riderRatings; } }

        internal static List<RaterBillingOption> RaterBillingOptions { get { return _raterBillingOptions; } }

        internal static List<BillingMethod> BillingMethods { get { return _billingMethods; } }

        internal static List<BillingMode> BillingModes { get { return _billingModes; } }

        internal static List<BaseRating> BaseRatings { get { return _baseRatings; } }

        internal static List<StateSetting> StateSettings { get { return _stateSettings; } }
    }
}