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
    public partial class EmployerGrpEnrollAffiliate
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        [CLSCompliant(false)]
        public sbyte AffiliateOrder { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AffiliateOrderSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string AffiliateCompanyName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string AffiliateCompanyAddress { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public long AffiliateNumberOfEmployees { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AffiliateNumberOfEmployeesSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        [CLSCompliant(false)]
        public sbyte AffiliateIsWhollyOwned { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AffiliateIsWhollyOwnedSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "http://ACORD.org/Standards/Life/2", Order = 5)]
        public Address Address { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string AffiliateRelationship { get; set; }
    }
}
