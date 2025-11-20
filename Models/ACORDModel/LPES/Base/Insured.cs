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
    public partial class Insured
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string insuredGUID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string firstName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string middleInitial { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string lastName { get; set; }

        /// <remarks/>
        [XmlElement("answers", Order = 4)]
        public ArrayOfAnswer[] Items { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int relationToPI { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool relationToPISpecified { get; set; }
    }
}
