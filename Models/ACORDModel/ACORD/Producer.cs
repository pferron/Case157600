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
    [XmlType(AnonymousType = true, Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot(Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class Producer
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string CRDNumber { get; set; }

        /// <remarks/>
        [XmlElement("License", Order = 1)]
        public License_Type[] License { get; set; }

        /// <remarks/>
        [XmlArray(Order = 2)]
        [XmlArrayItem("DistributionChannelInfo", typeof(DistributionChannelInfo_Type), IsNullable = false)]
        public DistributionChannelInfo_Type[] CarrierAppointment { get; set; }
    }
}
