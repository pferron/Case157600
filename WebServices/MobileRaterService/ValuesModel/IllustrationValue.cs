using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOW.MobileRaterService.ValuesModel
{
    public class IllustrationValue
    {
        public IllustrationValue()
        {
            GenerationDate = new DateTime();
            BackEndMessage = string.Empty;
            MiscellaneousValues = new List<string>();
            Riders = new List<RiderValue>();
            ColumnData = new SortedList<ColumnDataEnum, IList<decimal>>();
        }

        public DateTime GenerationDate { get; set; }

        public decimal GuaranteedInterestRate { get; set; }
        public decimal AssumedInterestRate { get; set; }
        public decimal CurrentInterestRate { get; set; }

        public int GuaranteedLapseYear { get; set; }
        public int GuaranteedLapseMonth { get; set; }

        public int AssumedLapseYear { get; set; }
        public int AssumedLapseMonth { get; set; }

        public int CurrentLapseYear { get; set; }
        public int CurrentLapseMonth { get; set; }

        public int ZeroPremiumLapseYear { get; set; }
        public int ZeroPremiumLapseMonth { get; set; }

        public decimal LumpSumAmount { get; set; }
        public decimal Lump1035Amount { get; set; }
        public decimal LifeContingent { get; set; }

        public decimal GuaranteedSettleRate { get; set; }
        public decimal CurrentSettleRate { get; set; }

        public decimal GuaranteedLapseYearMortality { get; set; }
        public decimal AssumedLapseYearMortality { get; set; }
        public decimal CurrentLapseYearMortality { get; set; }

        public decimal InitialDeathBenefit { get; set; }
        public decimal MinimumPremium { get; set; }
        public decimal TargetPremium { get; set; }

        public decimal GuaranteedNetPay5 { get; set; }
        public decimal GuaranteedNetPay10 { get; set; }
        public decimal GuaranteedNetPay20 { get; set; }

        public decimal GuaranteedSurrenderCost5 { get; set; }
        public decimal GuaranteedSurrenderCost10 { get; set; }
        public decimal GuaranteedSurrenderCost20 { get; set; }

        public decimal AssumedNetPay5 { get; set; }
        public decimal AssumedNetPay10 { get; set; }
        public decimal AssumedNetPay20 { get; set; }

        public decimal AssumedSurrenderCost5 { get; set; }
        public decimal AssumedSurrenderCost10 { get; set; }
        public decimal AssumedSurrenderCost20 { get; set; }

        public decimal CurrentNetPay5 { get; set; }
        public decimal CurrentNetPay10 { get; set; }
        public decimal CurrentNetPay20 { get; set; }

        public decimal CurrentSurrenderCost5 { get; set; }
        public decimal CurrentSurrenderCost10 { get; set; }
        public decimal CurrentSurrenderCost20 { get; set; }

        public decimal GuaranteedNetPay5Mortality { get; set; }
        public decimal GuaranteedNetPay10Mortality { get; set; }
        public decimal GuaranteedNetPay20Mortality { get; set; }

        public decimal GuaranteedSurrenderCost5Mortality { get; set; }
        public decimal GuaranteedSurrenderCost10Mortality { get; set; }
        public decimal GuaranteedSurrenderCost20Mortality { get; set; }

        public decimal AssumedNetPay5Mortality { get; set; }
        public decimal AssumedNetPay10Mortality { get; set; }
        public decimal AssumedNetPay20Mortality { get; set; }

        public decimal AssumedSurrenderCost5Mortality { get; set; }
        public decimal AssumedSurrenderCost10Mortality { get; set; }
        public decimal AssumedSurrenderCost20Mortality { get; set; }

        public decimal CurrentNetPay5Mortality { get; set; }
        public decimal CurrentNetPay10Mortality { get; set; }
        public decimal CurrentNetPay20Mortality { get; set; }

        public decimal CurrentSurrenderCost5Mortality { get; set; }
        public decimal CurrentSurrenderCost10Mortality { get; set; }
        public decimal CurrentSurrenderCost20Mortality { get; set; }

        public int ResumeYear { get; set; }
        public IList<RiderValue> Riders { get; set; }
        public decimal MinimumPremiumGuaranteed { get; set; }
        public decimal InitialSurrenderCharge { get; set; }
        public string BackEndMessage { get; set; }
        public int CurrentNumberOfPayments { get; set; }
        public int GuaranteedNumberOfPayments { get; set; }
        public int SecondGuaranteedPeriodEnd { get; set; }

        public IList<string> MiscellaneousValues { get; set; }
        public SortedList<ColumnDataEnum, IList<decimal>> ColumnData { get; set; }
    }
}