using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOW.MobileRaterService.ValuesModel
{
    public enum ColumnDataEnum
    {
        None = 0,
        GuaranteedGrossPremium = 1000,
        AssumedGrossPremium = 1001,
        NonGuaranteedGrossPremium = 1002,
        MidpointPremiumOutlay = 1101,
        NonGuaranteedPremiumOutlay = 1102,
        GuaranteedModalPremium = 1110,
        CurrentModalPremium = 1112,
        GuaranteedPartialSurrender = 1200,
        NonGuaranteedPartialSurrender = 1202,
        GuaranteedLoanBalance = 1320,
        AssumedLoanBalance = 1321,
        NonGuaranteedLoanBalance = 1322,
        GuaranteedLoanInterestCash = 1340,
        AssumedLoanInterestCash = 1341,
        NonGuaranteedLoanInterestCash = 1342,
        GuaranteedTobaccoKickout = 1400,
        NonGuaranteedTobaccoKickout = 1402,
        NonGuaranteedRefundTrad = 1502,
        CurrentBasis = 1702,
        GuaranteedAccountValue = 2000,
        AssumedAccountValue = 2001,
        NonGuaranteedAccountValue = 2002,
        GuaranteedSurrenderCharge = 2010,
        AssumedSurrenderCharge = 2011,
        NonGuaranteedSurrenderCharge = 2012,
        GuaranteedDeathBenefit = 2020,
        AssumedDeathBenefit = 2021,
        NonGuaranteedDeathBenefit = 2022,
        GuaranteedNetPaymentIndex = 2070,
        NonGuaranteedNetPaymentIndex = 2072,
        GuaranteedSurrenderCostIndex = 2080,
        NonGuaranteedSurrenderCostIndex = 2082,
        GuaranteedSettlementOptionIncome = 2090,
        NonGuaranteedCashValueFromAdditionalInsuranceTrad = 2102,
        NonGuaranteedAdditionalInsuranceFromRefundsTrad = 2122,
        NonGuaranteedRefundAccumulationTrad = 2202,
        NonGuaranteedOneYearTermFromRefunds = 2522,
        GuaranteedNetAccountValue = 2970,
        AssumedNetAccountValue = 2971,
        GuaranteedApfBalanceTrad = 10005,
        NonGuaranteedApfBalanceTrad = 10007,
        GuaranteedApfInterestTrad = 10010,
        NonGuaranteedApfInterestTrad = 10012,
        GuaranteedCashOutlay = 10020,
        CurrentCashOutlay = 10022,
        GuaranteedReducedPaidUp = 10030,
        ExtendedTermInsuranceYears = 10040,
        ExtendedTermInsuranceDays = 10050,
        GuaranteedDeathBenefitCB = 10210,
        GuaranteedBasePremiumCB = 10310,
        CurrentBasePremiumCB = 10312,
        GuaranteedAcceleratedDeathBenefitPremiumCB = 10320,
        GuaranteedWaiverOfPremiumCB = 10330,
        GuaranteedTotalPremiumCB = 10340,
        GuaranteedNetPaymentOtherInsuredCB = 10350,
        GuaranteedOtherInsuredPremiumsCB = 10370,
        NonGuaranteedRefundUL = 11012,
        NonGuaranteedRefundInCash = 11016,
        NonGuaranteedCashValueFromAdditionalInsuranceUL = 11022,
        NonGuaranteedRefundAccumulationUL = 11032,
        NonGuaranteedAdditionalInsuranceFromRefundsUL = 11042,
        GuaranteedApfOutlayUL = 11050,
        NonGuaranteedApfOutlayUL = 11052,
        GuaranteedApfWithdrawalUL = 11060,
        AssumedApfWithdrawal = 11061,
        NonGuaranteedApfWithdrawalUL = 11062,
        GuaranteedApfInterestUL = 11070,
        NonGuaranteedApfInterestUL = 11072,
        GuaranteedApfBalanceUL = 11080,
        GuaranteedNetSurrenderValueRollover = 11080,
        NonGuaranteedNetSurrenderValueRollover = 11081,
        NonGuaranteedApfBalanceUL = 11082,
        GuaranteedMaxCashYear = 11090, // Dupe
        GuaranteedNetSurrenderValuePremium = 11090,
        NonGuaranteedNetSurrenderValuePremium = 11091,
        MidPointMaxCashYear = 11091, // Dupe
        NonGuaranteedMaxCashYear = 11092,
        GuaranteedDeathBenefitChangeKickout = 11100,
        NonGuaranteedDeathBenefitChangeKickout = 11102,
        GuaranteedFaceDecreaseKickout = 11110,
        NonGuaranteedFaceDecreaseKickout = 11112,
        CumulativePremium = 11130,
        // These values are overloaded by StoneRiver
        // The meaning is based on the product type.
        // Parsing an integer back to enum might result in the wrong enum return.
        // This should only cause a problem if printing out the text value of the enum.
        AulGuaranteedCostOfInsuranceRate = 11140, // Universal Life
        PremiumDepositFundOutlay = 11140, // Whole Life

        NlgulGuaranteedCostOfInsuranceRate = 11150, // Universal Life
        PremiumAndFraternalDuesWithdrawal = 11150, // Whole Life

        GuaranteedDeathBenefitFactor = 11160,
        SurrenderChargeRate = 11170,
        WaiverOfPremiumRate = 11180,
    }
}