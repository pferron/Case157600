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
    public partial class PLANSPDEPCOVERAGELIMITS
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public long SPOUSEPERCENTORAMT { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SPOUSEPERCENTORAMTSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public double SPOUSEPERCENT { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SPOUSEPERCENTSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public double SPOUSEAMT { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SPOUSEAMTSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public long DEPENDENTPERCENTORAMT { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DEPENDENTPERCENTORAMTSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public double DEPENDENTPERCENT { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DEPENDENTPERCENTSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public double DEPENDENTAMT { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DEPENDENTAMTSpecified { get; set; }
    }
}
