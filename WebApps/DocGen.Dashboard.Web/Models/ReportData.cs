using System;

namespace LPA.Dashboard.Web.Models
{
    /// <summary>
    /// The report data.
    /// </summary>
    public class ReportData
    {
        /// <summary>
        /// Gets or Sets the RECON report id.
        /// </summary>
        /// <value>An int.</value>
        public int ReconReportId { get; set; }

        /// <summary>
        /// Gets or Sets the report name.
        /// </summary>
        /// <value>A string.</value>
        public string ReportName { get; set; }

        /// <summary>
        /// Gets or Sets the date created UTC.
        /// </summary>
        /// <value>A DateTime.</value>
        public DateTime DateCreatedUtc { get; set; }

        /// <summary>
        /// Gets or Sets the data name.
        /// </summary>
        /// <value>A string.</value>
        public string DataName { get; set; }

        /// <summary>
        /// Gets or Sets the data value.
        /// </summary>
        /// <value>A string.</value>
        public string DataValue { get; set; }
    }
}