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
    [XmlRoot("CarrierAppointment", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class CarrierAppointment_Type
    {
        /// <remarks/>
        [XmlElement("DistributionChannelInfo", Order = 0)]
        public DistributionChannelInfo_Type[] DistributionChannelInfo { get; set; }
    }
}
