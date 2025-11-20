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
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot("FIPReports", Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class FIP_REPORTS_TYPE
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public REPORT_CODE_TYPE ReportCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public decimal ReportInterestRate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ReportInterestRateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public decimal ReportSalesCharge { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ReportSalesChargeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int ReportTermRates { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ReportTermRatesSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public INCLUDE_GRAPH_TYPE ReportIncludeGraph { get; set; }
    }
}
