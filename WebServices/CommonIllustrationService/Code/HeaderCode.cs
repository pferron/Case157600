using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wow.CommonIllustrationService.Code
{
    public class HeaderCode
    {

        // TODO Why all the commented code here? Do we not know the acceptable codes?
        // TODO Possibly add to a DB table
        public enum HeaderCodes
        {
            None,
            NoLapse = 119,
            NoLapseWorksite = 120,
            AccumulatedUniversalLife = 121,
            AccumulatedUniversalLifeWorksite = 122,
            IndexedUniversalLife = 123,

            WholeLifeRegularAppPaidUpAtAge100 = 220,
            WholeLifeRegularAppPaidUpAt65 = 221,
            WholeLifeRegularApp20Pay = 222,
            WholeLifeRegularAppSinglePremium = 223,
            WholeLifeEZAppPaidUpAt100 = 224,

            WholeLifeEZAppPaidUpAt65 = 225,

            WholeLifeEZApp20Pay = 226,

            WholeLifeEZAppSinglePremium = 227,

            WholeLifeLP100ConversionApplication = 228,

            WholeLifeRegularAppUnisexPaidUpAt100 = 230,
            WholeLifeEZAppUnisexPaidUpAt100 = 234,

            WholeLifeUnisexLP100ConversionApplication = 238,
            RedPaidUpAt100 = 250,
            BlueWhitePaidUpAt100 = 260,

            BlueWhitePaidUpAt65 = 261,

            BlueWhite20Pay = 262,

            BlueWhiteSinglePremium = 263,

            BlueWhiteUnisexPaidUpAt100 = 264,

            RedUnisexPaidUpAt100 = 265,
            WorksitePaidUpAt100 = 274,
            WorksitePaidUpAt65 = 275,

            // <-Livio --------------------------------------------------------
            WholeLifePaidAt100_2017 = 280,
            WholeLifePaidAt65_2017 = 281,
            WholeLifePaidAt20Life2017 = 282,
            WholeLifePaidAt10Life2017 = 283,
            WholeLifeUnisexLifePaidAt100_2017 = 284,
            WholeLifeBlueWhiteLifePaidAt100_2017 = 290,
            WholeLifeBlueWhiteLifePaidAt65_2017 = 291,
            WholeLifeBlueWhite20PayLife2017 = 292,
            WholeLifeBlueWhite10PayLife2017 = 293,
            WholeLifeBlueWhiteUnisexLifePaidAt100_2017 = 294,
            WholeLifeLP100ConversionApplication2017 = 295,
            WholeLifeLP100UnisexConversionApplication2017 = 296,
            WholeLifeREDLifePaidAt100_2017 = 297,
            WholeLifeREDUnisexLifePaidAt100_2017 = 298,

            // ------------------------------------------------------------------
            TermBaseLevel10Year = 750,
            TermBaseLevel15Year = 755,
            TermBaseLevel20Year = 760,
            TermWorksiteBaseLevel20Year = 765,
            TermBaseLevel30Year = 770,
            TermWorksiteBaseLevel30Year = 775,
            TermBaseLevel10Year2016 = 850,
            TermBaseLevel15Year2016 = 855,
            TermBaseLevel20Year2016 = 860,
            TermWorksiteBaseLevel20Year2016 = 870,
            TermBaseLevel30Year2016 = 865,
            TermWorksiteBaseLevel30Year2016 = 875,
            FamilyTerm10Year2016 = 880,
            FamilyTerm20Year2016 = 885,
            FamilyTerm = 780,

            TermBaseLevelYouthWithAcceleratedDeathBenefit = 790,
            FixedAnnuityFlexiblePremiumDeferredAnnuityNonBonus = 1001,

            FixedAnnuityFlexiblePremiumDeferredAnnuityBonus = 1002,

            FixedAnnuitySinglePremiumDeferredAnnuityNonBonus = 1003,

            FixedAnnuitySinglePremiumDeferredAnnuityBonus = 1004,

            RequiredMinimumDistributionLetter = 1409
        }

        public enum CategoryCode
        {
            None,
            UniversalLife = 3,
            TermLife = 4,
            WholeLife = 8,
            FixedAnnuity = 10
        }
        //static public int CategoryOf(int hc)
        //{
        //    switch ((HeaderCodes) hc)
        //    {
        //        case HeaderCodes.NoLapse:
        //        case HeaderCodes.IndexedUniversalLife:
        //        case HeaderCodes.NoLapseWorksite:
        //            return (int)CategoryCode.UniversalLife;
        //        default:
        //            return (int)CategoryCode.None;
        //    }
        //}
        //static public bool IsRedType(int hc)
        //{
        //    switch ((HeaderCodes)hc)
        //    {
        //        case HeaderCodes.RedPaidUpAt100:
        //        case HeaderCodes.RedUnisexPaidUpAt100:
        //        case HeaderCodes.WholeLifeREDLifePaidAt100_2017:
        //        case HeaderCodes.WholeLifeREDUnisexLifePaidAt100_2017:
        //            return true;
        //        default:
        //            return false;
        //    }
        //}
        //static public bool IsWholeLifeSinglePremiumType(int hc)
        //{
        //    switch ((HeaderCodes)hc)
        //    {
        //        case HeaderCodes.BlueWhiteSinglePremium:
        //        case HeaderCodes.WholeLifeEZAppSinglePremium:
        //        case HeaderCodes.WholeLifeRegularAppSinglePremium:
        //            return true;
        //        default:
        //            return false;
        //    }
        //}
        //static public bool IsBlueWhiteType(int hc)
        //{
        //    switch ((HeaderCodes)hc)
        //    {
        //        case HeaderCodes.BlueWhite20Pay:
        //        case HeaderCodes.BlueWhitePaidUpAt100:
        //        case HeaderCodes.BlueWhitePaidUpAt65:
        //        case HeaderCodes.BlueWhiteSinglePremium:
        //        case HeaderCodes.BlueWhiteUnisexPaidUpAt100:
        //        case HeaderCodes.WholeLifeBlueWhiteLifePaidAt100_2017:
        //        case HeaderCodes.WholeLifeBlueWhiteLifePaidAt65_2017:
        //        case HeaderCodes.WholeLifeBlueWhite20PayLife2017:
        //        case HeaderCodes.WholeLifeBlueWhite10PayLife2017:
        //        case HeaderCodes.WholeLifeBlueWhiteUnisexLifePaidAt100_2017:
        //            return true;
        //        default:
        //            return false;
        //    }
        //}
        //static public bool IsWholeLife100Type(int hc)
        //{
        //    switch ((HeaderCodes)hc)
        //    {
        //        case HeaderCodes.WholeLifeRegularAppPaidUpAtAge100:
        //        case HeaderCodes.WholeLifeEZAppPaidUpAt100:
        //        case HeaderCodes.WholeLifeEZAppUnisexPaidUpAt100:
        //        case HeaderCodes.WholeLifeLP100ConversionApplication:
        //        case HeaderCodes.WholeLifeRegularAppUnisexPaidUpAt100:
        //        case HeaderCodes.WholeLifeUnisexLP100ConversionApplication:
        //        case HeaderCodes.BlueWhitePaidUpAt100:
        //        case HeaderCodes.BlueWhiteUnisexPaidUpAt100:
        //        case HeaderCodes.WorksitePaidUpAt100:
        //        case HeaderCodes.WholeLifePaidAt100_2017:
        //        case HeaderCodes.WholeLifeUnisexLifePaidAt100_2017:
        //        case HeaderCodes.WholeLifeBlueWhiteLifePaidAt100_2017:
        //        case HeaderCodes.WholeLifeBlueWhiteUnisexLifePaidAt100_2017:
        //        case HeaderCodes.WholeLifeLP100ConversionApplication2017:
        //        case HeaderCodes.WholeLifeLP100UnisexConversionApplication2017:
        //            return true;
        //        default:
        //            return false;
        //    }
        //}
        //static public bool IsWholeLife10PayType(int hc)
        //{
        //    switch ((HeaderCodes)hc)
        //    {
        //        case HeaderCodes.WholeLifePaidAt10Life2017:
        //        case HeaderCodes.WholeLifeBlueWhite10PayLife2017:
        //            return true;
        //        default:
        //            return false;
        //    }
        //}
        //static public bool IsWholeLife20PayType(int hc)
        //{
        //    switch ((HeaderCodes)hc)
        //    {
        //        case HeaderCodes.WholeLifeRegularApp20Pay:
        //        case HeaderCodes.WholeLifeEZApp20Pay:
        //        case HeaderCodes.BlueWhite20Pay:
        //        case HeaderCodes.WholeLifePaidAt20Life2017:
        //        case HeaderCodes.WholeLifeBlueWhite20PayLife2017:
        //            return true;
        //        default:
        //            return false;
        //    }
        //}
        //static public bool IsWholeLife65Type(int hc)
        //{
        //    switch ((HeaderCodes)hc)
        //    {
        //        case HeaderCodes.WholeLifeRegularAppPaidUpAt65:
        //        case HeaderCodes.WholeLifeEZAppPaidUpAt65:
        //        case HeaderCodes.BlueWhitePaidUpAt65:
        //        case HeaderCodes.WorksitePaidUpAt65:
        //        case HeaderCodes.WholeLifePaidAt65_2017:
        //        case HeaderCodes.WholeLifeBlueWhiteLifePaidAt65_2017:
        //            return true;
        //        default:
        //            return false;
        //    }
        //}
        //static public bool IsAccumulatedUniversalLifeType(int hc)
        //{
        //    switch ((HeaderCodes)hc)
        //    {
        //    case HeaderCodes.AccumulatedUniversalLife:
        //    case HeaderCodes.AccumulatedUniversalLifeWorksite:
        //        return true;
        //    default:
        //        return false;
        //    }
        //}
        //static public bool IsFamilyTermType(int hc)
        //{
        //    switch ((HeaderCodes)hc)
        //    {
        //    case HeaderCodes.FamilyTerm:
        //    case HeaderCodes.FamilyTerm10Year2016:
        //    case HeaderCodes.FamilyTerm20Year2016:
        //        return true;
        //    default:
        //        return false;
        //    }
        //}
        //static public bool IsFixedAnnuityType(int hc)
        //{
        //    switch ((HeaderCodes)hc)
        //    {
        //        case HeaderCodes.FixedAnnuityFlexiblePremiumDeferredAnnuityBonus:
        //        case HeaderCodes.FixedAnnuityFlexiblePremiumDeferredAnnuityNonBonus:
        //        case HeaderCodes.FixedAnnuitySinglePremiumDeferredAnnuityBonus:
        //        case HeaderCodes.FixedAnnuitySinglePremiumDeferredAnnuityNonBonus:
        //            return true;
        //        default:
        //            return false;
        //    }
        //}
        //static public bool IsTermNormalType(int hc)
        //{
        //    switch ((HeaderCodes)hc)
        //    {
        //    case HeaderCodes.TermBaseLevel10Year:
        //    case HeaderCodes.TermBaseLevel15Year:
        //    case HeaderCodes.TermBaseLevel20Year:
        //    case HeaderCodes.TermWorksiteBaseLevel20Year:
        //    case HeaderCodes.TermBaseLevel30Year:
        //    case HeaderCodes.TermWorksiteBaseLevel30Year:
        //    case HeaderCodes.TermBaseLevel10Year2016:
        //    case HeaderCodes.TermBaseLevel15Year2016:
        //    case HeaderCodes.TermBaseLevel20Year2016:
        //    case HeaderCodes.TermWorksiteBaseLevel20Year2016:
        //    case HeaderCodes.TermBaseLevel30Year2016:
        //    case HeaderCodes.TermWorksiteBaseLevel30Year2016:
        //        return true;
        //    default:
        //        return false;
        //    }
        //}
        //static public bool IsWorksitePaidUpType(int hc)
        //{
        //    switch ((HeaderCodes)hc)
        //    {
        //        case HeaderCodes.WorksitePaidUpAt100:
        //        case HeaderCodes.WorksitePaidUpAt65:
        //            return true;
        //        default:
        //            return false;
        //    }
        //}
    }
}
