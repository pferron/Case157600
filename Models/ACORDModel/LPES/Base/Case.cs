using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class Case
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string CaseLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string CaseDescription { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int GroupID { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool GroupIDSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string SAGUID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string SICCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string SICDiv { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string SICType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public int BillingSort { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BillingSortSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public int BillNumSortBy { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BillNumSortBySpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public int BillingElec { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BillingElecSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public int BillingOpt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BillingOptSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public string BillOtherDesc { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public int BillingMethod { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BillingMethodSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public int BillTPAType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BillTPATypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        public string TPAName { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 15)]
        public DateTime SolicitationDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SolicitationDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 16)]
        public string EIN { get; set; }

        /// <remarks/>
        [XmlElement(Order = 17)]
        public int FPORider { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool FPORiderSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 18)]
        public int Section125 { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool Section125Specified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 19)]
        public string ContactName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 20)]
        public string ContactPhone { get; set; }

        /// <remarks/>
        [XmlElement(Order = 21)]
        public string ContactFax { get; set; }

        /// <remarks/>
        [XmlElement(Order = 22)]
        public string ContactEMail { get; set; }

        /// <remarks/>
        [XmlElement(Order = 23)]
        public int ContactMethod { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ContactMethodSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 24)]
        public int CaseStatus { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CaseStatusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 25)]
        public DateTime EnrollmentYr { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentYrSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 26)]
        public DateTime EnrollmentThru { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentThruSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 27)]
        public int DefaultCase { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DefaultCaseSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 28)]
        public int YearsInBusiness { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool YearsInBusinessSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 29)]
        public int NumberEmployees { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool NumberEmployeesSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 30)]
        public DateTime FirstDeductionDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool FirstDeductionDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 31)]
        public DateTime RequestedIssueDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool RequestedIssueDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 32)]
        public DeductionsPerYearList DeductionsPerYear { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DeductionsPerYearSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 33)]
        public BillingFrequencyList BillingFrequency { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BillingFrequencySpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 34)]
        public int GroupSitusState { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool GroupSitusStateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 35)]
        public DateTime PlanAnniversaryDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PlanAnniversaryDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 36)]
        public int Section125Lock { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool Section125LockSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 37)]
        public DateTime CaseModifyDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CaseModifyDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 38)]
        public int ModifiedAfterSync { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ModifiedAfterSyncSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 39)]
        public double SyncTime { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SyncTimeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 40)]
        public double BillingPremium { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BillingPremiumSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 41)]
        [CLSCompliant(false)]
        public sbyte IsOnHold { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsOnHoldSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 42)]
        public double EnrollmentBeginDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentBeginDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 43)]
        public double EnrollmentEndDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentEndDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 44)]
        [CLSCompliant(false)]
        public sbyte RulesFlag { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool RulesFlagSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 45)]
        [CLSCompliant(false)]
        public sbyte IndustryClass { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IndustryClassSpecified { get; set; }

        /// <remarks/>
        [XmlElement("EmployerCaseProduct", Order = 46)]
        public EmployerCaseProduct[] EmployerCaseProduct { get; set; }

        /// <remarks/>
        [XmlElement("EmployerCaseRule", Order = 47)]
        public EmployerCaseRule[] EmployerCaseRule { get; set; }

        /// <remarks/>
        [XmlElement(Order = 48)]
        public string CaseNumber { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 49)]
        public DateTime InitialBillingDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool InitialBillingDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement("Address", Namespace = "http://ACORD.org/Standards/Life/2", Order = 50)]
        public Address[] Address { get; set; }

        /// <remarks/>
        [XmlElement("Phone", Namespace = "http://ACORD.org/Standards/Life/2", Order = 51)]
        public Phone[] Phone { get; set; }
    }
}
