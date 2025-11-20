using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class TempTableRatingOption
    {
        /// <remarks/>
        [XmlElement("TempTableRating", Namespace = "http://ACORD.org/Standards/Life/2", Order = 0)]
        public OLI_LU_RATINGS[] TempTableRating { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public ControlInfo ControlInfo { get; set; }
    }
}
