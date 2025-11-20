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
    public partial class EmployerCaseRule
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public long RuleID { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool RuleIDSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public long SubRuleID { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SubRuleIDSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string StartDate { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string EndDate { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public double UnitMax { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool UnitMaxSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public double UniMin { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool UniMinSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public double AmountMax { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AmountMaxSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public double AmountMin { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AmountMinSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public string RuleMessage { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public long StateCode { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool StateCodeSpecified { get; set; }
    }
}
