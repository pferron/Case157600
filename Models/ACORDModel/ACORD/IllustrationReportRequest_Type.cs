using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using WOW.Illustration.Model.LPES.OLifeExtensions;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot("IllustrationReportRequest", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class IllustrationReportRequest_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_ILLUSREPORTTYPE IllustrationReportType { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", typeof(AcordIllustrationReportRequestExtension), Order = 1)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
