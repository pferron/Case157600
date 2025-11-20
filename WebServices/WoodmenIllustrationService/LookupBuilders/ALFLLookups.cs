using Microsoft.Ajax.Utilities;
using System;
using WoodmenLife.Enterprise.Illustration.Models.Titanium;
using WOW.Illustration.Model.Enums;
using WOW.WoodmenIllustrationService.Exceptions;
namespace WOW.WoodmenIllustrationService.LookupBuilders
{
    public class ALFLLookups
    {       

        internal int GetRefundOption(string dividendTypeCode)
        {
            int refundOption = 0;

            switch (dividendTypeCode.ToUpper())
            {
                case "CASH":
                    refundOption = 1;
                    break;
                case "REDPUA":
                case "REDLNPUA":
                case "ADDITIONALINSURANCEAFTERMAXCASH":
                    refundOption = 2;
                    break;
                case "REDACCUM":
                case "REDLNACCUM":
                case "ACCUMULATEDATINTERESTAFTERMAX":
                    refundOption = 3;
                    break;
                case "REDCASH":
                case "REDLNCASH":
                case "CASHAFTERMAX":
                    refundOption = 6;
                    break;
                default:
                    throw new PolicyConverterException($"GetRefundOption failed to process invalid dividend type code: {dividendTypeCode} while executing the ALFL Policy Converter.");
            }

            return refundOption;
        }

        internal int GetMaturationAge(string planId)
        {
            //Maturity age for AL is 95, FL is 96
            int maturationAge = 0;

            switch (planId.ToUpper())
            {
                case string x when x.StartsWith("LUAL622"):
                    maturationAge = 95;
                    break;
                case string x when x.StartsWith("LUFL626"):
                    maturationAge = 96;
                    break;
                case string x when x.StartsWith("LU58AL1"):
                    maturationAge = 95;
                    break;
                case string x when x.StartsWith("LU58AL2"):
                    maturationAge = 95;
                    break;
                case string x when x.StartsWith("LUAL640"):
                    maturationAge = 95;
                    break;
                case string x when x.StartsWith("LUFL630"):
                    maturationAge = 96;
                    break;
                case string x when x.StartsWith("LUAL660"):
                    maturationAge = 95;
                    break;
                case string x when x.StartsWith("LUFL670"):
                    maturationAge = 96;
                    break;
                case string x when x.StartsWith("LUUNIFL"):
                    maturationAge = 96;
                    break;
                case string x when x.StartsWith("LRFL630"):
                    maturationAge = 96;
                    break;
                case string x when x.StartsWith("LRFL626"):
                    maturationAge = 96;
                    break;
                case string x when x.StartsWith("LRFL670"):
                    maturationAge = 96;
                    break;
                case string x when x.StartsWith("LRUNIFL"):
                    maturationAge = 96;
                    break;
                default:
                    throw new PolicyConverterException($"GetMaturationAge failed to process invalid planId: {planId} while executing the ALFL Policy Converter.");
            }

            return maturationAge;
        }

        internal int ConvertClass(string planId)
        {
            int insuredClass = 0;

            switch (planId.Substring(planId.Length - Math.Min(1, planId.Length)).ToUpperInvariant())
            {                
                case "N":
                    insuredClass = 2;
                    break;
                case "T":
                    insuredClass = 4;
                    break;
                case "P":
                    insuredClass = 1;
                    break;
                case "R":
                    insuredClass = 3;
                    break;
                case "U":
                    insuredClass = 5;
                    break;
                default:
                    throw new PolicyConverterException($"ConvertClass failed to process invalid planId: {planId} while executing the ALFL Policy Converter.");
            }

            return insuredClass;
        }

        internal decimal GetModalLoanPayment(TiPolicyDetail policy)
        {
            decimal modalPayment = 0;

            if (policy != null && policy.Billing != null && policy.Billing.Mode != null && policy.Billing.Mode.Code != null)
            {
                var billingModeCode = string.Empty;

                if (!string.IsNullOrEmpty(policy.ProposedChanges?.ProposedBillingChange?.BillingModeCode))
                {
                    billingModeCode = policy.ProposedChanges?.ProposedBillingChange?.BillingModeCode;
                }
                else
                {
                    billingModeCode = policy.Billing.Mode.Code;
                }
                
                switch (billingModeCode)
                {
                    case nameof(BillingModalType.ANNUAL):
                    case nameof(BillingModalType.SINGLEPAY):
                        modalPayment = policy.ProposedChanges.ProposedLoanPayoffChange.LoanPaymentAmount ?? 0;
                        break;
                    case nameof(BillingModalType.BIANNUAL):                    
                        modalPayment = policy.ProposedChanges.ProposedLoanPayoffChange.LoanPaymentAmount / 2 ?? 0;
                        break;
                    case nameof(BillingModalType.QUARTLY):
                        modalPayment = policy.ProposedChanges.ProposedLoanPayoffChange.LoanPaymentAmount / 4 ?? 0;
                        break;
                    case nameof(BillingModalType.MNTHLY):
                        modalPayment = policy.ProposedChanges.ProposedLoanPayoffChange.LoanPaymentAmount / 12 ?? 0;
                        break;                   
                    default:
                        break;
                }
            }

            return modalPayment;
        }

        internal int ConvertBillingMode(string billingModeCode)
        {
            switch (billingModeCode)
            {
                case "QUARTLY":
                    return 3;
                case "BIANNUAL":
                case "SINGLEPAY":
                    return 2;
                case "MNTHLY":
                    return 6;
                default:
                    return 1; // Annual 'ANNUAL'
            }
        }

        internal string ConvertFundAccount(string fundAccountId)
        {
            //'IUFIXD' – WoodmenLife IUL -Fixed Account
            //'WLINDX' -S & P500 Point - to - Point with Cap Rate

            switch (fundAccountId.ToUpperInvariant())
            {
                case "IUFIXD":
                    return "100";
                case "WLINDX":
                    return "200";
                default:
                    throw new PolicyConverterException($"ConvertFundAccount failed to process invalid fundAccountId: {fundAccountId} while executing the ALFL Policy Converter.");
            }
        }

        internal int ConvertBillType(string billingMethodCode)
        {
            // { BillType.ListBill, 2 } does not apply to IUL
            switch (billingMethodCode?.ToUpper())
            {
                case "REGBILL": //{ BillType.Direct, 1 },
                    return 1;

                case "PAC": //{ BillType.PAC, 3 }
                    return 2;

                case "LISTBILL":
                    return 3;

                default:
                    throw new PolicyConverterException($"ConvertBillType failed to process invalid billingMethodCode: {billingMethodCode??"null"} while executing the ALFL Policy Converter.");
            }
        }
    }
}