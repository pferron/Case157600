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
    public partial class MissingRequiredForm
    {
        /// <remarks/>
        [XmlElement("FormName", Namespace = "http://ACORD.org/Standards/Life/2", Order = 0)]
        public string[] FormName { get; set; }

        /// <remarks/>
        [XmlElement("ProviderFormNumber", Namespace = "http://ACORD.org/Standards/Life/2", Order = 1)]
        public string[] ProviderFormNumber { get; set; }

        /// <remarks/>
        [XmlElement("AttachFormInfo", Order = 2)]
        public AttachFormInfo[] AttachFormInfo { get; set; }
    }
}
