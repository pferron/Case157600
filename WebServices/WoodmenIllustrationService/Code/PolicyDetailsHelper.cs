using WoodmenLife.Enterprise.Illustration.Models.Titanium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.Illustration.Model.Enums;

namespace WOW.WoodmenIllustrationService.Code
{
    public static class PolicyDetailsHelper
    {
        public static decimal GetModalPayment(TiPolicyDetail policy)
        {
            decimal modalPayment = 0;

            if (policy != null && policy.Billing != null && policy.Billing.Mode != null && policy.Billing.Mode.Code != null)
            {
                switch (policy.Billing.Mode.Code)
                {
                    case nameof(BillingModalType.ANNUAL):
                        modalPayment = policy.Billing.AnnualAmount;
                        break;
                    case nameof(BillingModalType.BIANNUAL):
                        modalPayment = policy.Billing.SemiannualAmount;
                        break;
                    case nameof(BillingModalType.QUARTLY):
                        modalPayment = policy.Billing.QuarterlyAmount;
                        break;
                    case nameof(BillingModalType.MNTHLY):
                        modalPayment = policy.Billing.MonthlyAmount;
                        break;
                    case nameof(BillingModalType.SINGLEPAY):
                        modalPayment = policy.Billing.Amount;
                        break;
                    default:                        
                        break;
                }
            }            

            return modalPayment;
        }

        public static decimal GetMax7PayAmountAvailable(TiPolicyDetail policy)
        {
            if (policy == null || !policy.IssueDate.HasValue)
            {
                var message = "Issue Effective Date is missing.";

                throw new Exception(message);
            }
                        
            int policyYear = DateUtilities.CalculateAge(policy.IssueDate.Value, DateTime.Today) + 1; //BT-49365: Note: ageOfPolicy = number of policy anniversary years + 1
            decimal sevenPayAmount = policy.SevenPayPremiumAmount;
            decimal premiumReceivedItdAmount = policy.PremiumReceivedItdAmount;
            decimal exchange1035Amount = policy.Exchange1035Amount;

            //Calculate max7PayAmountAvailable [BT-49365: (ageOfPolicy * sevenPayPremiumAmount) - (premiumReceivedItdAmount - exchange1035Amount) ]
            decimal max7PayAmountAvailable = (sevenPayAmount * policyYear) - (premiumReceivedItdAmount - exchange1035Amount);
            
            return max7PayAmountAvailable;
        }
                
        public static decimal GetRemainingPlannedPremiumBeforeNextAnniversary(TiPolicyDetail policy, decimal additionalPremiumPayment)
        {
            if (policy == null || policy.Billing == null)
            {
                var message = "GetRemainingPlannedPremiumBeforeNextAnniversary(): Exception due to missing data element(s).";

                throw new Exception(message);
            }
            decimal modalPaymentWithDues = GetModalPayment(policy);
            decimal remainingPlannedPremiumBeforeNextAnniversary = modalPaymentWithDues * GetRemainingPaymentsBeforeAnniversary(policy);
            if (additionalPremiumPayment > 0)
            {
                remainingPlannedPremiumBeforeNextAnniversary = remainingPlannedPremiumBeforeNextAnniversary + additionalPremiumPayment;
            }
            
            return remainingPlannedPremiumBeforeNextAnniversary;
        }

        public static int GetRemainingPaymentsBeforeAnniversary(TiPolicyDetail policy)
        {
            DateTime billedToDate = policy.BilledToDate.Value;
            if (policy == null || policy.Billing == null || policy.Billing.Mode?.Code == null || !policy.BilledToDate.HasValue)
            {
                var message = "GetRemainingPaymentsBeforeAnniversary(): Exception due to missing data element(s).";
                throw new Exception(message);
            }
            string billingMode = policy.Billing.Mode.Code;
            int modalMonths;
            
            if (billingMode.Equals(nameof(BillingModalType.ANNUAL),StringComparison.OrdinalIgnoreCase))
            {
                modalMonths = 12;
            }
            else if (billingMode.Equals(nameof(BillingModalType.BIANNUAL), StringComparison.OrdinalIgnoreCase))
            {
                modalMonths = 6;
            }
            else if (billingMode.Equals(nameof(BillingModalType.QUARTLY), StringComparison.OrdinalIgnoreCase))
            {
                modalMonths = 3;
            }
            else if (billingMode.Equals(nameof(BillingModalType.MNTHLY), StringComparison.OrdinalIgnoreCase))
            {
                modalMonths = 1;
            }
            else
            {
                var message = "getRemainingPaymentsBeforeAnniversary(): Unknown BillingMode \"" + billingMode + "\"!";                
                throw new Exception(message);
            }

            int count = 0;
            DateTime? nextAnniversary = DateUtilities.GetNextAnniversary(policy.IssueDate, DateTime.Today).Value;
            DateTime ld = billedToDate.AddDays(1);
            while (nextAnniversary.HasValue && ld.AddMonths(modalMonths) < nextAnniversary)
            {
                ld = ld.AddMonths(modalMonths);
                count++;             
            }
            
            return count;
        }
    }
}