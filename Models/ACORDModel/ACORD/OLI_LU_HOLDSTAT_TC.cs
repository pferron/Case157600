using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_HOLDSTAT_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,


        /// <summary>Active the Holding is in force</summary>
        [XmlEnum("1")]
        OLI_HOLDSTAT_ACTIVE = 1,


        /// <summary>Inactive Terminated, Lapsed or expired</summary>
        [XmlEnum("2")]
        OLI_HOLDSTAT_INACTIVE = 2,


        /// <summary>Proposed - Pending - Not yet inforce</summary>
        /// <remarks>Not applicable for statuses other than Holding</remarks>
        [XmlEnum("3")]
        OLI_HOLDSTAT_PROPOSED = 3,


        /// <summary>Dormant - Suspended</summary>
        [XmlEnum("4")]
        OLI_HOLDSTAT_DORMANT = 4,


        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
