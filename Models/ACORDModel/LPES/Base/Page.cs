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
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class Page
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string pageName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int pageGroup { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool pageGroupSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int pageOrder { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool pageOrderSpecified { get; set; }

        /// <remarks/>
        [XmlElement("sections", Order = 3)]
        public ArrayOfSection[] Items { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int pageNumber { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool pageNumberSpecified { get; set; }
    }
}
