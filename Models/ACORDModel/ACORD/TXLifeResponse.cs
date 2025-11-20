using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot(Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class TXLifeResponse
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string TransRefGUID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_TRANS_TYPE_CODES TransType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public TRANS_SUBTYPE_CODES TransSubType { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 3)]
        public DateTime TransExeDate { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "time", Order = 4)]
        public DateTime TransExeTime { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public IllustrationRequest_Type IllustrationRequest { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public IllustrationResult_Type IllustrationResult { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public TransResult TransResult { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public OLifE OLifE { get; set; }

        /// <remarks/>
        [XmlElement("XTbML", Order = 9)]
        public XTbML_Type[] XTbML { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public OLifEExtension OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string PrimaryObjectID { get; set; }
    }
}
