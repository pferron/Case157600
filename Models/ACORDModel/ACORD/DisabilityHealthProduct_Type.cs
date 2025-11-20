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
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot("DisabilityHealthProduct", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class DisabilityHealthProduct_Type
    {
        /// <remarks/>
        [XmlArray(Order = 0)]
        [XmlArrayItem("IssueGender", IsNullable = false)]
        public OLI_LU_GENDER[] IssueGenderCC { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_COVUNITTYPE CovUnitType { get; set; }

        /// <remarks/>
        [XmlElement("RiderProduct", Order = 2)]
        public RiderProduct_Type[] RiderProduct { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public DisabilityHealthProvisions_Type DisabilityHealthProvisions { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 4)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
