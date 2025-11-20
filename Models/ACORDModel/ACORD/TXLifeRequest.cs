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
    public partial class TXLifeRequest
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
        [XmlElement(Order = 3)]
        public CriteriaExpression_Type CriteriaExpression { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public IllustrationRequest_Type IllustrationRequest { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public FormInstanceRequest_Type FormInstanceRequest { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public OLifE OLifE { get; set; }

        /// <remarks/>
        [XmlElement("XTbML", Order = 7)]
        public XTbML_Type[] XTbML { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 8)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string PrimaryObjectID { get; set; }
    }
}
