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
    [XmlRoot("IllustrationRequest", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class IllustrationRequest_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_STOPOPTION StopOption { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 1)]
        public string StopAgeYears { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OLI_LU_IMAGEFORMAT ImageType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public OLI_LU_ATTACHLOCATION AttachmentLocation { get; set; }

        /// <remarks/>
        [XmlElement("IllustrationTxn", Order = 4)]
        public IllustrationTxn_Type[] IllustrationTxn { get; set; }

        /// <remarks/>
        [XmlElement("IllustrationReportRequest", Order = 5)]
        public IllustrationReportRequest_Type[] IllustrationReportRequest { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", typeof(AcordIllustrationRequestExtension), Order = 6)]
        public OLifEExtension OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string AnchorBasisID { get; set; }
    }
}
