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
    public partial class CoverageDetails
    {
        /// <remarks/>
        [XmlAttribute()]
        public int CoverageType { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int PlanCode { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string CoveragePerson { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int RiderType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool RiderTypeSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int RiderSubType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool RiderSubTypeSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string RiderShortName { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public long UnitAmount { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool UnitAmountSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public double IncomePercent { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IncomePercentSpecified { get; set; }
    }
}
