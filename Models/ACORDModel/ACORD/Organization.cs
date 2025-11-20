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
    public partial class Organization
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_ORGFORM OrgForm { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_TRUSTTYPE TrustType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OLI_LU_BOOLEAN IrrevokableInd { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string AbbrName { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 4)]
        public DateTime EstabDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EstabDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement("SitusInfo", Order = 5)]
        public SitusInfo_Type[] SitusInfo { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 6)]
        public OLifEExtension[] OLifEExtension { get; set; }
    }
}
