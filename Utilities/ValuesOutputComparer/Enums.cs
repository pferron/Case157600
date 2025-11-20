
namespace WOW.Illustration.Utilities.ValuesOutputComparer.Enums
{
    public enum ProductType
    {
        NoLapse,
        AccumulatedUniversalLife,
        WholeLife,
        Red,
        Term,
        FamilyTerm,
        YouthTerm,
        FixedAnnuity
    }

    public enum HeaderCode
    {
        None,
        NoLapse = 119,
        NoLapseWorksite = 120,

        AccumulatedUniversalLife = 121,
        AccumulatedUniversalLifeWorksite = 122,

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

        TermBaseLevel10Year = 750,
        TermBaseLevel15Year = 755,
        TermBaseLevel20Year = 760,
        TermWorksiteBaseLevel20Year = 765,
        TermBaseLevel30Year = 770,
        TermWorksiteBaseLevel30Year = 775,
        FamilyTerm = 780,
        TermBaseLevelYouthWithAcceleratedDeathBenefit = 790,

        FixedAnnuityFlexiblePremiumDeferredAnnuityNonBonus = 1001,
        FixedAnnuityFlexiblePremiumDeferredAnnuityBonus = 1002,
        FixedAnnuitySinglePremiumDeferredAnnuityNonBonus = 1003,
        FixedAnnuitySinglePremiumDeferredAnnuityBonus = 1004
    }
}
