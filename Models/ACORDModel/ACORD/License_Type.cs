using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
/// <remarks/>
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace="http://ACORD.org/Standards/Life/2")]
[XmlRoot("License", Namespace="http://ACORD.org/Standards/Life/2", IsNullable=false)]
public partial class License_Type
{
    /// <remarks/>
    [XmlElement(Order=0)]
    public string LicenseID { get; set; }
    
    /// <remarks/>
    [XmlElement(Order=1)]
    public OLI_LU_STATESELL LicenseState { get; set; }
}
}
