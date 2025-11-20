using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    public enum REFUNDS_TYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <remarks/>
        [XmlEnum("1")]
        Cash = 1,

        /// <remarks/>
        [XmlEnum("2")]
        PaidUpInsurance = 2,

        /// <remarks/>
        [XmlEnum("3")]
        AccumulatedWithInterest = 3,

        /// <remarks/>
        [XmlEnum("4")]
        ReducePremiums = 4,

        /// <remarks/>
        [XmlEnum("6")]
        CashAfterMax = 6,

        /// <remarks/>
        [XmlEnum("7")]
        PaymentOfPremium = 7,

        /// <remarks/>
        [XmlEnum("8")]
        PaidUpAdditionalInsurance = 8,

        /// <remarks/>
        [XmlEnum("111")]
        LoanRepay_PaidUpAdditionalInsurance = 111,

        /// <remarks/>
        [XmlEnum("113")]
        LoanRepay_ReducePremiums = 113,

        /// <remarks/>
        [XmlEnum("114")]
        LoanRepay_Cash = 114,

        /// <remarks/>
        [XmlEnum("117")]
        LoanRepay_LeftWithWoodmenAtInterest = 117,
    }
}
