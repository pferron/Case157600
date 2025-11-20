using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class CasePlanSCGIDetails
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        [CLSCompliant(false)]
        public sbyte IsNewEnrollment { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsNewEnrollmentSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 1)]
        public DateTime EnrollStartDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollStartDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 2)]
        public DateTime EnrollEndDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollEndDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public long EnrollPeriod { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollPeriodSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 4)]
        public DateTime TerminateDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TerminateDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 5)]
        public DateTime HireDateFrom { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool HireDateFromSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 6)]
        public DateTime HireDateTo { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool HireDateToSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        [CLSCompliant(false)]
        public sbyte OmitQuestionFour { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool OmitQuestionFourSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public long NumberofEmployees { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool NumberofEmployeesSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public double MinWeekPremiumEE { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinWeekPremiumEESpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public double MaxWeekPremiumEE { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxWeekPremiumEESpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public double MinWeekPremiumSpouse { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinWeekPremiumSpouseSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public double MaxWeekPremiumSpouse { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxWeekPremiumSpouseSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public double MinWeekPremiumChild { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinWeekPremiumChildSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        public double MaxWeekPremiumChild { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxWeekPremiumChildSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 15)]
        public double MinIssueEEAndSpouse { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinIssueEEAndSpouseSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 16)]
        public double MinIssueChild { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinIssueChildSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 17)]
        public double MaxIssueEE { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxIssueEESpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 18)]
        public double MaxIssueSpouse { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxIssueSpouseSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 19)]
        public double MaxIssueChild { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxIssueChildSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 20)]
        [CLSCompliant(false)]
        public sbyte OmitQ1 { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool OmitQ1Specified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 21)]
        [CLSCompliant(false)]
        public sbyte OmitQ2 { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool OmitQ2Specified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 22)]
        [CLSCompliant(false)]
        public sbyte SPOmitQ2 { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SPOmitQ2Specified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 23)]
        [CLSCompliant(false)]
        public sbyte SPOmitQ4 { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SPOmitQ4Specified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 24)]
        public double GITerminationDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool GITerminationDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 25)]
        public double GIMaxFaceAmount { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool GIMaxFaceAmountSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 26)]
        public double GIMaxWeeklyPrem { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool GIMaxWeeklyPremSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 27)]
        public long NewHireRange { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool NewHireRangeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 28)]
        public long OmitMultipleQs { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool OmitMultipleQsSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 29)]
        [CLSCompliant(false)]
        public sbyte HOIndustryClass { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool HOIndustryClassSpecified { get; set; }
    }
}
