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
    public partial class PartySearchCriteria
    {
        /// <remarks/>
        [XmlElement(DataType = "token", Order = 0)]
        public string PartySearchFirstName { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 1)]
        public string PartySearchLastName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int PartySearchAge { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PartySearchAgeSpecified { get; set; }
    }
}
