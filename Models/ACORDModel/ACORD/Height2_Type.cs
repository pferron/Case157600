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
    [XmlRoot("Height2", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class Height2_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_MEASUREUNITS MeasureUnits { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public double MeasureValue { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MeasureValueSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OLI_LU_BOOLEAN HeightMeasuredInd { get; set; }
    }
}
