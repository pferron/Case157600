using System;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [Serializable()]
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    public enum FIP_ILLUS_TXN_TERTIARY_TYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>IRS RMD (Cash flow option)</summary>
        [XmlEnum("8")]
        RequiredMinimumDistribution = 8,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647
    }
}
