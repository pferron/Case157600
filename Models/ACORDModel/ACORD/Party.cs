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
    public partial class Party
    {
        /// <remarks/>
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string EstNetWorth { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_PARTY PartyTypeCode { get; set; }

        /// <remarks/>
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string PartyKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string FullName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string GovtID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OLI_LU_GOVTIDTC GovtIDTC { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public OLI_LU_PREFCOMM PrefComm { get; set; }

        /// <remarks/>
        [XmlElement("Organization", typeof(Organization), Order = 7)]
        [XmlElement("Person", typeof(Person), Order = 7)]
        public object Item { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public Address Address { get; set; }

        /// <remarks/>
        [XmlElement("Phone", Order = 9)]
        public Phone[] Phone { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public Client_Type Client { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public Producer Producer { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public EMailAddress EMailAddress { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public Employment Employment { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        public OLifEExtension OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
