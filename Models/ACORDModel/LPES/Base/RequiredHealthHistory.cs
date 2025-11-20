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
    public partial class RequiredHealthHistory
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string LastContact { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 1)]
        public System.DateTime LastContactDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool LastContactDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string PhysicianOrHospitalName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string DateOrDuration { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string ConsultingReason { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string PartyID { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "http://ACORD.org/Standards/Life/2", Order = 6)]
        public Phone Phone { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "http://ACORD.org/Standards/Life/2", Order = 7)]
        public Address Address { get; set; }

        /// <remarks/>
        [XmlElement("KeyedValue", Namespace = "http://ACORD.org/Standards/Life/2", Order = 8)]
        public KeyedValue_Type[] KeyedValue { get; set; }
    }
}
