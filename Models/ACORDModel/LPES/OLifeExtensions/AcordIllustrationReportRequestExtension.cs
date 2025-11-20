using System;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;
using WOW.Illustration.Model.LPES.Base;

namespace WOW.Illustration.Model.LPES.OLifeExtensions
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public class AcordIllustrationReportRequestExtension : OLifEExtension
    {
        [XmlElement("ReportCode", Order = 1)]
        public REPORT_CODE_TYPE ReportCode { get; set; }

        [XmlElement("ReportInterestRate", Order = 2)]
        public decimal ReportInterestRate { get; set; }

        [XmlIgnore()]
        public bool ReportInterestRateSpecified { get { return !ReportInterestRate.Equals(decimal.Zero); } }

        [XmlElement("ReportSalesCharge", Order = 3)]
        public decimal ReportSalesCharge { get; set; }

        [XmlIgnore()]
        public bool ReportSalesChargeSpecified { get { return !ReportSalesCharge.Equals(decimal.Zero); } }

        [XmlElement("ReportTermRates", Order = 4)]
        public int ReportTermRates { get; set; }

        [XmlIgnore()]
        public bool ReportTermRatesSpecified { get { return !ReportTermRates.Equals(0); } }

        [XmlElement("ReportIncludeGraph", Order = 5)]
        public INCLUDE_GRAPH_TYPE ReportIncludeGraph { get; set; }
    }
}