using System;
using System.Collections.Generic;

namespace WOW.WoodmenIllustrationService.SharedModels
{
    public class RaterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public int ConformToTamra { get; set; }
        //public string Misc2 { get; set; }
        //public string Misc3 { get; set; }
        //public string Misc4 { get; set; }
        //public string Misc7 { get; set; }
        //public string Misc8 { get; set; }
        //public string Misc9 { get; set; }
        //public string Misc10 { get; set; }
        //public int LoanUsageType { get; set; }
        public decimal Lump1035Amt { get; set; }
        //public int LumpSumUsage { get; set; }
        //public int PlanQualified { get; set; }
        //public int PlanUnisex { get; set; }
        public int RtgAmt { get; set; }
        public int RtgAmtToAge { get; set; }
        public decimal RtgExtra_1 { get; set; }
        public int RtgExtra_1ToAge { get; set; }
        //public decimal RtgExtra_2 { get; set; }
        //public int RtgExtra_2ToAge { get; set; }
        //public int RtgAmtPerm { get; set; }
        //public int RtgAmtPermToAge { get; set; }
        //public int SettlementAge { get; set; }
        //public int ResumeAge { get; set; }
        public int RefundOpt { get; set; }
        //public decimal Ten35Basis { get; set; }
        //public int WdrlToLoan { get; set; }
        //public int StateNAICApproved { get; set; }
        //public int RTOAge { get; set; }
        //public decimal RTOAmount { get; set; }
        //public int RPUPrimaryDiv { get; set; }
        //public int PUAStopPremium { get; set; }
        //public int VanishMaintainCode { get; set; }
        //public int VanishType { get; set; }
        public decimal FrDues { get; set; }
        public int ClassType { get; set; }
        public int HeaderCode { get; set; }
        public int CategoryCode { get; set; }
        public int ConceptCode { get; set; }
        //public int StrategyCode { get; set; }
        public int PremMode { get; set; }
        public int BillType { get; set; }
        public int FaceCode { get; set; }
        public decimal FacePremAmt { get; set; }
        //public int SearchType { get; set; }
        //public decimal SearchTarget { get; set; }
        //public int searchAssumption { get; set; }
        //public int SearchAge { get; set; }
        //public decimal SearchPremium { get; set; }
        //public decimal SearchIntRate { get; set; }
        //public decimal SearchPremiumPercentage { get; set; }
        //public int SearchPremiumToAge { get; set; }
        //public int SearchTargetCode { get; set; }

        // Riders
        public List<RaterRider> Riders { get; set; }

        // Joints
        //public List<RaterJointData> Joints { get; set; }

        // NonLevelData
        public List<RaterNonLevelData> NonLevelData { get; set; }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}