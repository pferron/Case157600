
namespace WOW.Illustration.FipAnalyzer
{
    internal enum CategoryCode
    {
        None,
        UniversalLife = 3,
        TermLife = 4,
        WholeLife = 8,
        FixedAnnuity = 10
    }

    internal enum ClassTypeLife
    {
        None,
        Preferred = 1, // Adult - Term, UL, WL
        Standard = 2,  // Adult - Term, UL, WL // Youth - UL (New Biz)
        TobaccoPreferred = 3, // Adult - Term, UL, WL
        Tobacco = 4, // Adult - Term, UL, WL
        SuperPreferredTerm = 5, // Adult - Term
        StandardYouth = 12, // Youth - Term, UL (Inforce), WL // Adult - WL (Red)
        SuperPreferred = 14, // Adult - UL, WL
    }

    internal enum ClassTypeAnnuity
    {
        None,
        FA = 1,
        FAIra = 2,
        FARoth = 3,
        FASimple = 4,
        FATsa = 5,
        FASep = 6,
        FAListBill = 7,
        FAIraListBill = 8,
        FARothListBill = 9,
        FASepListBill = 21,
        FASimpleListBill = 22,
        FATsaListBill = 23
    }

    internal enum RiderType
    {
        WaiverOfPremium = 1,
        AccidentalDeathBenefit = 2,
        GuaranteedInsurability = 3,
        OtherInsuredRider = 8,
        ApplicantWaiver = 12,
        PremiumDepositFund = 103,
        AcceleratedBenefit = 105
    }

    internal class FipAnalysis
    {
        public int HeaderCode { get; set; }
        public decimal FaceAmount { get; set; }
        public bool IsInForce { get; set; }
        public ClassTypeLife ClassTypeLife { get; set; }
        public ClassTypeAnnuity ClassTypeAnnuity { get; set; }
        public string Filename { get; set; }
        public int IssueAge { get; set; }
        public CategoryCode CategoryCode { get; set; }
        public bool HasTableRating { get; set; }
        public bool HasFlatExtra { get; set; }
        public bool HasWaiverOfPremium { get; set; }
        public bool HasAccidentalDeathBenefit { get; set; }
        public bool HasGuaranteedInsurability { get; set; }
        public bool HasOtherInsuredRider { get; set; }
        public bool HasApplicantWaiver { get; set; }
        public bool HasPremiumDepositFund { get; set; }
        public bool HasAcceleratedBenefit { get; set; }

        public int ClassType
        {
            get
            {
                if (CategoryCode == FipAnalyzer.CategoryCode.FixedAnnuity)
                {
                    return (int)ClassTypeAnnuity;
                }
                else
                {
                    return (int)ClassTypeLife;
                }
            }
        }
    }
}
