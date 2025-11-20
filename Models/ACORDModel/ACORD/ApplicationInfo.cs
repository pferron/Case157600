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
    public partial class ApplicationInfo
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_STATE ApplicationJurisdiction { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 1)]
        public DateTime SubmissionDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SubmissionDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 2)]
        public DateTime HOReceiptDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool HOReceiptDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public decimal CWAAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CWAAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OLI_LU_CLIENTLANGUAGES PrefLanguage { get; set; }

        /// <remarks/>
        [XmlElement("SignatureInfo", Order = 5)]
        public SignatureInfo_Type[] SignatureInfo { get; set; }
    }
}
