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
    public partial class SICGIGILimits
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public double GIFaceMin { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public double GIFaceMax { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public double CGIFaceMin { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public double CGIFaceMax { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public double OverallFaceMin { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public double OverallFaceMax { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public double OverallPremMin { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public double OverallPremMax { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public double CalculatedFace { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public double CalculatedPremium { get; set; }
    }
}
