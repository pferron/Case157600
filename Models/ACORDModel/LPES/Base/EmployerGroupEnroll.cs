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
    public partial class EmployerGroupEnroll
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string GroupName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string GrpEnrollContactTitle { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string GrpEnrollContactName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string GrpEnrollContactPhone { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string AdminPerson { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string AdminPhone { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string SicCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public string SicDiv { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public string SicType { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 9)]
        public DateTime EffectiveDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EffectiveDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        [CLSCompliant(false)]
        public sbyte IsReplacement { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsReplacementSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 11)]
        public DateTime PriorPlanTerminateDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PriorPlanTerminateDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public string PriorInsuranceCompany { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        [CLSCompliant(false)]
        public sbyte IsERISA { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsERISASpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        [CLSCompliant(false)]
        public sbyte ERISAWantSummary { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ERISAWantSummarySpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 15)]
        public string ERFedID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 16)]
        public string ERISAPlanNumber { get; set; }

        /// <remarks/>
        [XmlElement(Order = 17)]
        public string PlanYearFromDate { get; set; }

        /// <remarks/>
        [XmlElement(Order = 18)]
        public string PlanYearThroughDate { get; set; }

        /// <remarks/>
        [XmlElement(Order = 19)]
        public string PlanName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 20)]
        public long TotalNumberOfEEs { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TotalNumberOfEEsSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 21)]
        [CLSCompliant(false)]
        public sbyte EETypes { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EETypesSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 22)]
        public string EETypesOtherDesc { get; set; }

        /// <remarks/>
        [XmlElement(Order = 23)]
        public string EEClassExcluded { get; set; }

        /// <remarks/>
        [XmlElement(Order = 24)]
        public long WaitPeriodAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool WaitPeriodAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 25)]
        [CLSCompliant(false)]
        public sbyte WaitDayOrMonth { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool WaitDayOrMonthSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 26)]
        [CLSCompliant(false)]
        public sbyte EligibleDayType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EligibleDayTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 27)]
        public string EligibleOtherDesc { get; set; }

        /// <remarks/>
        [XmlElement(Order = 28)]
        [CLSCompliant(false)]
        public sbyte WaitEffectiveDateType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool WaitEffectiveDateTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 29)]
        [CLSCompliant(false)]
        public sbyte EnrollmentPeriodType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentPeriodTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 30)]
        public string EnrollmentOtherDesc { get; set; }

        /// <remarks/>
        [XmlElement(Order = 31)]
        public double InitialPayment { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool InitialPaymentSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 32)]
        [CLSCompliant(false)]
        public sbyte BillModeType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BillModeTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 33)]
        [CLSCompliant(false)]
        public sbyte HasIndProduct { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool HasIndProductSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 34)]
        [CLSCompliant(false)]
        public sbyte IsBillCombined { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsBillCombinedSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 35)]
        [CLSCompliant(false)]
        public sbyte BillType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BillTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 36)]
        public string EmailAddress { get; set; }

        /// <remarks/>
        [XmlElement(Order = 37)]
        public string ApplicantName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 38)]
        public string OfficerTitle { get; set; }

        /// <remarks/>
        [XmlElement(Order = 39)]
        public string EnrollComments { get; set; }

        /// <remarks/>
        [XmlElement(Order = 40)]
        public string SignedAtCity { get; set; }

        /// <remarks/>
        [XmlElement(Order = 41)]
        public string SignedAtState { get; set; }

        /// <remarks/>
        [XmlElement(Order = 42)]
        [CLSCompliant(false)]
        public sbyte ReadApplication { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ReadApplicationSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 43)]
        [CLSCompliant(false)]
        public sbyte EEEnrollType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EEEnrollTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement("ElectronicDelivery", Order = 44)]
        [CLSCompliant(false)]
        public sbyte[] ElectronicDelivery { get; set; }

        /// <remarks/>
        [XmlElement("EEAssoci", Order = 45)]
        [CLSCompliant(false)]
        public sbyte[] EEAssoci { get; set; }

        /// <remarks/>
        [XmlElement("EffectiveEndDate", Order = 46)]
        public double[] EffectiveEndDate { get; set; }

        /// <remarks/>
        [XmlElement("Address", Namespace = "http://ACORD.org/Standards/Life/2", Order = 47)]
        public Address[] Address { get; set; }

        /// <remarks/>
        [XmlElement("EmployerGrpEnrollContribute", Order = 48)]
        public EmployerGrpEnrollContribute[] EmployerGrpEnrollContribute { get; set; }

        /// <remarks/>
        [XmlElement("EmployerGrpEnrollAffiliate", Order = 49)]
        public EmployerGrpEnrollAffiliate[] EmployerGrpEnrollAffiliate { get; set; }

        /// <remarks/>
        [XmlElement("EmployerGrpEnrollSplit", Order = 50)]
        public EmployerGrpEnrollSplit[] EmployerGrpEnrollSplit { get; set; }

        /// <remarks/>
        [XmlElement(Order = 51)]
        [CLSCompliant(false)]
        public sbyte CanOfferAssistance { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CanOfferAssistanceSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 52)]
        [CLSCompliant(false)]
        public sbyte CanOfferAutoInsurance { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CanOfferAutoInsuranceSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 53)]
        public DateTime TakeoverDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TakeoverDateSpecified { get; set; }
    }
}
