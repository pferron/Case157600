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
    public partial class LocationEE
    {
        /// <remarks/>
        [XmlElement(DataType = "date", Order = 0)]
        public DateTime LastSeenDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool LastSeenDateSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string EmployeeID { get; set; }
    }
}
