using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class Trustee
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string TrusteeName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string AddressLine { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string AddressLine2 { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string City { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string State { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string Zip { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string DialNumber { get; set; }
    }
}
