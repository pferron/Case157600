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
    public partial class EmployerInformation
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string ARGUID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string SAGUID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string CltAgtID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string AORName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string CeoOwner { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string CeoOwnerTitle { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public long YearInBusiness { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool YearInBusinessSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public int Section125 { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool Section125Specified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public long NumberofEmployee { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool NumberofEmployeeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        [CLSCompliant(false)]
        public sbyte FPO { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool FPOSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public string SignerTitle { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public OLI_LU_STATE SignerState { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public long EmployerStatus { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EmployerStatusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public long NumberEligibleEmplyeeNY { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool NumberEligibleEmplyeeNYSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        public long GroupTermFlagNY { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool GroupTermFlagNYSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 15)]
        public string GroupTermDetails { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 16)]
        public DateTime EnrollmentYear { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentYearSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 17)]
        public DateTime EnrollmentThrough { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentThroughSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 18)]
        public long DistributionChannelID { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DistributionChannelIDSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 19)]
        public string SICCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 20)]
        public long RequireCASA { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool RequireCASASpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 21)]
        [CLSCompliant(false)]
        public sbyte Secion125LockStatus { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool Secion125LockStatusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 22)]
        [CLSCompliant(false)]
        public sbyte IncludeExistingBenefit { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IncludeExistingBenefitSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 23)]
        public string Phone { get; set; }

        /// <remarks/>
        [XmlElement(Order = 24)]
        public string Fax { get; set; }

        /// <remarks/>
        [XmlElement(Order = 25)]
        public string Email { get; set; }

        /// <remarks/>
        [XmlElement(Order = 26)]
        public int SentToCreditUnion { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SentToCreditUnionSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 27)]
        public string CreditUnionName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 28)]
        public string GROUPFPO { get; set; }

        /// <remarks/>
        [XmlElement(Order = 29)]
        [CLSCompliant(false)]
        public sbyte IsOnHold { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsOnHoldSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 30)]
        [CLSCompliant(false)]
        public sbyte AllStateFlag { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AllStateFlagSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 31)]
        public double EnrollmentBeginDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentBeginDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 32)]
        public double EnrollmentEndDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentEndDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 33)]
        [CLSCompliant(false)]
        public sbyte PremiumTiers { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PremiumTiersSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 34)]
        [CLSCompliant(false)]
        public sbyte IsCallCenter { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsCallCenterSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 35)]
        [CLSCompliant(false)]
        public sbyte HIPAAFlag { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool HIPAAFlagSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 36)]
        [CLSCompliant(false)]
        public sbyte AORSalesChannel { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AORSalesChannelSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 37)]
        [CLSCompliant(false)]
        public sbyte VisionPremiumTiers { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool VisionPremiumTiersSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 38)]
        [CLSCompliant(false)]
        public sbyte AP2ExistingIllus { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AP2ExistingIllusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 39)]
        [CLSCompliant(false)]
        public sbyte AP3ExistingIllus { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AP3ExistingIllusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 40)]
        [CLSCompliant(false)]
        public sbyte OptPortabilityBenefit { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool OptPortabilityBenefitSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 41)]
        [CLSCompliant(false)]
        public sbyte OptMentalNervousExclusion { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool OptMentalNervousExclusionSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 42)]
        [CLSCompliant(false)]
        public sbyte OptAllstateAutoRef { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool OptAllstateAutoRefSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 43)]
        public EmployerGroupEnroll EmployerGroupEnroll { get; set; }

        /// <remarks/>
        [XmlElement(Order = 44)]
        public EmployerPriorInsurer EmployerPriorInsurer { get; set; }

        /// <remarks/>
        [XmlElement("EmployerCaseProduct", Order = 45)]
        public EmployerCaseProduct[] EmployerCaseProduct { get; set; }

        /// <remarks/>
        [XmlElement("EmployerClass", Order = 46)]
        public EmployerClass[] EmployerClass { get; set; }

        /// <remarks/>
        [XmlElement("EmployerGrpEnrollAffiliate", Order = 47)]
        public EmployerGrpEnrollAffiliate[] EmployerGrpEnrollAffiliate { get; set; }

        /// <remarks/>
        [XmlElement("Case", Order = 48)]
        public Case[] Case { get; set; }

        /// <remarks/>
        [XmlElement("EmployerEnrollmentMethod", Order = 49)]
        public EmployerEnrollmentMethod[] EmployerEnrollmentMethod { get; set; }

        /// <remarks/>
        [XmlElement("Location", Order = 50)]
        public Location[] Location { get; set; }

        /// <remarks/>
        [XmlElement("EmployerProduct", Order = 51)]
        public EmployerProduct[] EmployerProduct { get; set; }

        /// <remarks/>
        [XmlElement(Order = 52)]
        public string EmployerName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 53)]
        public string ShortName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 54)]
        public string EmployerEIN { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "http://ACORD.org/Standards/Life/2", Order = 55)]
        public SitusInfo_Type SitusInfo { get; set; }

        /// <remarks/>
        [XmlElement(Order = 56)]
        public int EligibilityStatus { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EligibilityStatusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 57)]
        public string AdminContactName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 58)]
        public string AdminContactEmail { get; set; }

        /// <remarks/>
        [XmlElement("Address", Namespace = "http://ACORD.org/Standards/Life/2", Order = 59)]
        public Address[] Address { get; set; }

        /// <remarks/>
        [XmlElement("Phone", Namespace = "http://ACORD.org/Standards/Life/2", Order = 60)]
        public Phone[] Phone1 { get; set; }

        /// <remarks/>
        [XmlElement("EmployerSplit", Order = 61)]
        public EmployerSplit[] EmployerSplit { get; set; }

        /// <remarks/>
        [XmlElement(Order = 62)]
        public CCDetail CCDetail { get; set; }
    }
}
