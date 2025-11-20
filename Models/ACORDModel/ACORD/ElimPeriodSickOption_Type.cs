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
    [XmlRoot("ElimPeriodSickOption", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class ElimPeriodSickOption_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_ELIMPERIOD ElimPeriodSick { get; set; }
    }
}
