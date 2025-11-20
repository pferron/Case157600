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
    [XmlRoot("DistributionChannelInfo", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class DistributionChannelInfo_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_DISTCHAN DistributionChannel { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string DistributionChannelName { get; set; }
    }
}
