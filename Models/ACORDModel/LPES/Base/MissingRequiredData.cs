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
    public partial class MissingRequiredData
    {
        /// <remarks/>
        [XmlArray(Order = 0)]
        [XmlArrayItem("MissingRequiredForm", IsNullable = false)]
        public MissingRequiredForm[] MissingRequiredForms { get; set; }

        /// <remarks/>
        [XmlArray(Order = 1)]
        [XmlArrayItem("MissingRequiredDataForm", IsNullable = false)]
        public MissingRequiredDataForm[] MissingRequiredDataForms { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
