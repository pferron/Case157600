using System.Collections.Generic;

namespace FipAnalyzerDeluxe
{
    static class IllustrationOptions
    {
        public enum AgeGroup
        {
            Any,
            Under18,
            Adult
        }

        public enum SignedState
        {
            Any,
            AL,
            AK,
            AZ,
            AR,
            CA,
            CO,
            CT,
            DE,
            FL,
            GA,
            HI,
            ID,
            IL,
            IN,
            IA,
            KS,
            KY,
            LA,
            ME,
            MD,
            MA,
            MI,
            MN,
            MS,
            MO,
            MT,
            NE,
            NV,
            NH,
            NJ,
            NM,
            NY,
            NC,
            ND,
            OH,
            OK,
            OR,
            PA,
            RI,
            SC,
            SD,
            TN,
            TX,
            UT,
            VT,
            VA,
            WA,
            WV,
            WI,
            WY
        }

        public enum IllustrationType
        {
            Any,
            NewBusiness,
            Inforce
        }

        public enum RatingClass
        {
            Any,
            NonTobacco,
            Tobacco,
            PreferredNonTobacco,
            PreferredTobacco,
            SuperPreferred,
            JuvenileStandard
        }

        public enum BillType
        {
            Any,
            Direct,
            PAC,
            ListBill
        }

        public enum BillMode
        {
            Any,
            Annual,
            Semiannual,
            Quarterly,
            Monthly
        }

        public enum ProductType
        {
            Any,
            Term,
            Whole,
            Universal,
            Annuity,
            FamilyTerm
        }

        public static Dictionary<RatingClass, int[]> FipRatingClassValues = new Dictionary<RatingClass, int[]>
        {
            { RatingClass.NonTobacco, new int[]{ 2 } },
            { RatingClass.Tobacco, new int[]{ 4 } },
            { RatingClass.PreferredNonTobacco, new int[]{ 1 } },
            { RatingClass.PreferredTobacco, new int[]{ 3 } },
            { RatingClass.SuperPreferred, new int[]{ 5, 14 } },
            { RatingClass.JuvenileStandard, new int[]{ 12 } }
        };

        public static Dictionary<IllustrationType, int> FipIllustrationTypeValues = new Dictionary<IllustrationType, int>
        {
            { IllustrationType.Inforce, 5 },
            { IllustrationType.NewBusiness, 1 },
        };

        public static Dictionary<BillType, int> FipBillTypeValues = new Dictionary<BillType, int>
        {
            { BillType.Direct, 1 },
            { BillType.ListBill, 2 },
            { BillType.PAC, 3 }
        };

        public static Dictionary<BillMode, int[]> FipBillModeValues = new Dictionary<BillMode, int[]>
        {
            { BillMode.Annual, new int[] { 1 } },
            { BillMode.Semiannual, new int[] { 12,2,52,62,72 } },
            { BillMode.Quarterly, new int[] { 13,20,3,53,63,73,8 } },
            { BillMode.Monthly, new int[] { 14,16,17,18,19,21,31,44,54,6,64,7,74 } }
        };

        public static Dictionary<ProductType, int[]> FipProductTypeValues = new Dictionary<ProductType, int[]>
        {
            { ProductType.Term, new int[] { 4 } },
            { ProductType.FamilyTerm, new int[] { 4 } },
            { ProductType.Whole, new int[] { 8 } },
            { ProductType.Universal, new int[] { 3 } },
            { ProductType.Annuity, new int[] { 10,6 } }
        };
    }
}
