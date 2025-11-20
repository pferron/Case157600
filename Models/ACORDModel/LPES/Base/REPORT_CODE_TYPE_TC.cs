using System;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [Serializable()]
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    public enum REPORT_CODE_TYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        [XmlEnum("6")]
        SPIA_BASIC_ILLUSTRATION = 6,

        [XmlEnum("10")]
        DA_BASIC_ILLUSTRATION = 10,

        /// <summary>Cover Page</summary>
        [XmlEnum("200")]
        COVER_PAGE = 200,

        /// <summary>FPDA Disclosure (Annuity)</summary>
        [XmlEnum("201")]
        FPDA_DISCLOSURE = 201,

        /// <summary>Insurance and Value – Graph (Annuity)</summary>
        [XmlEnum("202")]
        INSURANCE_AND_VALUE_GRAPH = 202,

        /// <summary>NLGUL Disclosure (NLG UL)</summary>
        [XmlEnum("203002")]
        NLGUL_DISCLOSURE = 203002,

        /// <summary>Narrative Summary</summary>
        [XmlEnum("203004")]
        NARRATIVE_SUMMARY = 203004,

        /// <summary>Numeric Summary (Universal Life)</summary>
        [XmlEnum("203005")]
        NUMERIC_SUMMARY_UNIVERSAL_LIFE = 203005,

        /// <summary>Tabular Detail (Universal Life)</summary>
        [XmlEnum("203006")]
        TABULAR_DETAIL_UNIVERSAL_LIFE = 203006,

        /// <summary>Numeric Summary, Page 3 (Whole Life)</summary>
        [XmlEnum("203007")]
        NUMERIC_SUMMARY_PAGE_3_WHOLE_LIFE = 203007,

        /// <summary>Tabular Detail, Page 4 & Supp (Whole Life)</summary>
        [XmlEnum("203008")]
        TABULAR_DETAIL_PAGE_4_WHOLE_LIFE = 203008,

        /// <summary>Numeric Summary, Page 3 (Term Life)</summary>
        [XmlEnum("203009")]
        NUMERIC_SUMMARY_PAGE_3_TERM_LIFE = 203009,

        /// <summary>Tabular Detail, Page 4 & Supp (Term Life)</summary>
        [XmlEnum("203010")]
        TABULAR_DETAIL_PAGE_4_TERM_LIFE = 203010,

        /// <summary>Tabular Detail, Page 3 (Whole Life)</summary>
        [XmlEnum("203018")]
        TABULAR_DETAIL_PAGE_3_WHOLE_LIFE = 203018,

        [XmlEnum("203020")]
        SPIA_DISCLOSURE = 203020,

        [XmlEnum("203030")]
        SETTLEMENT_OPTIONS_BASIC_ILLUSTRATION = 203030,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647
    }
}
