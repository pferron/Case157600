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
    [XmlType(AnonymousType = true, Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot(Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    [XmlInclude(typeof(AcordAnnuityExtension))]
    [XmlInclude(typeof(AcordCoverageExtension))]
    [XmlInclude(typeof(AcordIllustrationReportRequestExtension))]
    [XmlInclude(typeof(AcordIllustrationRequestExtension))]
    [XmlInclude(typeof(AcordIllustrationTxnExtension))]    
    [XmlInclude(typeof(AcordLifeParticipantExtension))]
    [XmlInclude(typeof(AcordPolicyExtension))]
    [XmlInclude(typeof(AcordPolicyStatementDetailExtension))]
    public partial class OLifEExtension
    {
        ///// <remarks/>
        //[XmlText()]
        //[XmlAnyElement(Order = 0)]
        //public XmlNode[] Any { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string VendorCode { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string ExtensionCode { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string SystemCode { get; set; }
    }
}
