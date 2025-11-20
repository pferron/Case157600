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
    [XmlRoot("IssueGenderCC", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class IssueGenderCC_Type
    {
        /// <remarks/>
        [XmlElement("IssueGender", Order = 0)]
        public OLI_LU_GENDER[] IssueGender { get; set; }
    }
}
