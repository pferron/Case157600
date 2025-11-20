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
    public partial class GatewayLiteData
    {
        /// <remarks/>
        [XmlElement(DataType = "IDREF", Order = 0)]
        public string GLEmployerGUID { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "IDREF", Order = 1)]
        public string GLEmployeeGUID { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "IDREF", Order = 2)]
        public string GLAgentID { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "IDREF", Order = 3)]
        public string GLUserID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string GLLanguageFolder { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string GLRegionFolder { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string GLStyleName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public string GLTempAccountID { get; set; }
    }
}
