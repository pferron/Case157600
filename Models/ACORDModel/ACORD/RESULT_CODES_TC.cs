using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum RESULT_CODES_TC
    {
        /// <summary>Success</summary>
        /// <remarks>The transaction was processed Successfully with no more information. No ResultInfo object is expected when this Result Code is produced.</remarks>
        [XmlEnum("1")]
        RESULT_SUCCESS = 1,

        /// <summary>Success with information</summary>
        /// <remarks>The transaction was processed successfully but some condition causes information to be returned. This is sometimes informational only and sometimes a warning. At least one ResultInfo object is expected when this Result Code is produced.</remarks>
        [XmlEnum("2")]
        RESULT_SUCCESSINFO = 2,

        /// <summary>Received Pending (transaction in queue)</summary>
        /// <remarks>This transaction will be processed as soon as possible but cannot be processed at this time. No ResultInfo object is expected when this Result Code is returned.</remarks>
        [XmlEnum("3")]
        RESULT_RECDPEND = 3,

        /// <summary>Received Pending with information</summary>
        /// <remarks>Applicable in cases where business rules are processed while transaction is pending execution. This transaction has been received and will be processed as soon as possible. There was some information regarding this transaction that was returned. At least one ResultInfo object is expected when this Result Code is produced.</remarks>
        [XmlEnum("4")]
        RESULT_RECDPENDINFO = 4,

        /// <summary>Failure</summary>
        /// <remarks>The transaction was not processed. The reason for the failure must be returned. At least one ResultInfo object is expected when this Result Code is produced.</remarks>
        [XmlEnum("5")]
        RESULT_FAILURE = 5,
    }
}
