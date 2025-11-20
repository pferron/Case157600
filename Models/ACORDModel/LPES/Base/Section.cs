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
    public partial class Section
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string sectionNumber { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string sectionText { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string sectionTitle { get; set; }

        /// <remarks/>
        [XmlElement("sectionQuestions", Order = 3)]
        public ArrayOfQuestion1[] Items { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int includeEmptySection { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool includeEmptySectionSpecified { get; set; }
    }
}
