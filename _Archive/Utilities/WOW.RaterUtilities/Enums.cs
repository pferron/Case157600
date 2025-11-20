
namespace WOW.RaterUtilities.Enums
{

    /// <summary>
    /// Enumerates the plans and special job types available.
    /// </summary>
    enum HeaderCode
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
        FixedAnnuitySinglePremiumDeferredAnnuityBonus = 1004,

        RequiredMinimumDistributionLetter = 1409
    }

    /// <summary>
    /// Enumerates the state codes
    /// </summary>
    enum StateCode
    {
        None,
        Alabama = 1,
        Arizona = 2,
        Arkansas = 3,
        California = 4,
        Colorado = 5,
        Connecticut = 6,
        Delaware = 7,
        DistrictOfColumbia = 8,
        Florida = 9,
        Georgia = 10,
        Idaho = 11,
        Illinois = 12,
        Indiana = 13,
        Iowa = 14,
        Kansas = 15,
        Kentucky = 16,
        Louisiana = 17,
        Maine = 18,
        Maryland = 19,
        Massachusetts = 20,
        Michigan = 21,
        Minnesota = 22,
        Mississippi = 23,
        Missouri = 24,
        Montana = 25,
        Nebraska = 26,
        Nevada = 27,
        NewHampshire = 28,
        NewJersey = 29,
        NewMexico = 30,
        NewYork = 31,
        NorthCarolina = 32,
        NorthDakota = 33,
        Ohio = 34,
        Oklahoma = 35,
        Oregon = 36,
        Pennsylvania = 37,
        RhodeIsland = 38,
        SouthCarolina = 39,
        SouthDakota = 40,
        Tennessee = 41,
        Texas = 42,
        Utah = 43,
        Virginia = 44,
        Washington = 45,
        WestVirginia = 46,
        Wisconsin = 47,
        Wyoming = 48,
        Vermont = 49,
        Alaska = 50,
        Hawaii = 51,
        PuertoRico = 52,
        Other = 53
    }
}
