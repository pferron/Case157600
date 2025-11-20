using log4net;
using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using WOW.MyWoodmenIllustrationClient.Properties;

namespace WOW.MyWoodmenIllustrationClient.Data
{
    /// <summary>
    /// This class is used to consolidate common methods for accessing the WOWTB.PORTAL_ILLUS_REQ data source.
    /// </summary>
    public static class IllustrationRequest
    {
        private const int MaxErrorMessageLength = 256;
        private static readonly ILog log = LogManager.GetLogger(typeof(IllustrationRequest));

         /// <summary>
        /// Gets a data table containing new illustration requests.
        /// </summary>
        /// <returns>A data table containing zero or more rows.</returns>
        public static DataTable SelectNewRequests()
        {
            const string sql = "SELECT CAST(PIRQ_REQ_TS AS CHAR(26)) AS PIRQ_REQ_TS, PIRQ_REQ_USER_ID, PIRQ_POL_ID, PIRQ_FIP_FILE FROM WOWTB.PORTAL_ILLUS_REQ WHERE PIRQ_STATUS = 'SUBMITTED' and PIRQ_ADMIN_SYS_ID = 'I'";

            if (log.IsDebugEnabled) log.Debug("SelectNewRequests");

            using (var dt = new DataTable("PORTAL_ILLUS_REQ"))
            {
                dt.Locale = CultureInfo.InvariantCulture;
                using (var da = new OleDbDataAdapter(sql, Settings.Default.DB2Connection))
                {
                    DataUtilities.Fill(da, dt);
                }

                if (log.IsDebugEnabled) log.DebugFormat(CultureInfo.InvariantCulture, "SelectNewRequests - Records:{0}", dt.Rows.Count);
                return dt;
            }
        }

        /// <summary>
        /// Updates the specified record to an error status.
        /// </summary>
        /// <param name="policyId">The policy ID of the record to update.</param>
        /// <param name="requestDate">A string representation of the record timestamp (string used to preserve precision).</param>
        /// <param name="errorMessage">A brief message indicating the cause of the error.</param>
        /// <returns>True, if a record was updated; otherwise, False.</returns>
        public static bool UpdateAsError(string policyId, string requestDate, string errorMessage)
        {
 //           const string sql = "UPDATE WOWTB.PORTAL_ILLUS_REQ SET PIRQ_STATUS = 'ERROR', PIRQ_PRCS_ERR_MSG = ?, PIRQ_CMPLTN_TS = CURRENT_TIMESTAMP WHERE PIRQ_STATUS = 'SUBMITTED' AND PIRQ_ADMIN_SYS_ID = 'I' AND PIRQ_POL_ID = ? AND PIRQ_REQ_TS = ? ";
            const string sql = "UPDATE WOWTB.PORTAL_ILLUS_REQ SET PIRQ_STATUS = 'ERROR', PIRQ_PRCS_ERR_MSG = ? WHERE PIRQ_STATUS = 'SUBMITTED' AND PIRQ_ADMIN_SYS_ID = 'I' AND PIRQ_POL_ID = ? AND PIRQ_REQ_TS = ? ";

            if (policyId == null)
            {
                if (log.IsErrorEnabled) log.Error("UpdateAsError - The passed PolicyId was null.");
                throw new ArgumentNullException("policyId", "PolicyID cannot be null.");
            }

            if (requestDate == null)
            {
                if (log.IsErrorEnabled) log.Error("UpdateAsError - The passed RequestDate was null.");
                throw new ArgumentNullException("requestDate", "RequestDate cannot be null.");
            }

            errorMessage = errorMessage ?? string.Empty;
            if (errorMessage.Length > MaxErrorMessageLength) errorMessage = errorMessage.Substring(0, MaxErrorMessageLength);
            
            if (log.IsDebugEnabled) log.DebugFormat(CultureInfo.InvariantCulture, "UpdateAsError - policyId:{0}, requestDate:{1}, errorMessage:{2}", policyId, requestDate, errorMessage);
            
            using (var conn = new OleDbConnection(Settings.Default.DB2Connection))
            {
                using (var cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("h1", errorMessage.ToUpper());
                    cmd.Parameters.AddWithValue("h2", policyId);
                    cmd.Parameters.AddWithValue("h3", requestDate);
                    var records = DataUtilities.ExecuteNonQuery(cmd);
                    if (log.IsDebugEnabled) log.DebugFormat(CultureInfo.InvariantCulture, "UpdateAsError - Records Affected:{0}", records);
                    return records > 0;
                }
            }
        }
        /// <summary>
        ///     convert base 64 string to binary stream for portal
        /// </summary>
        /// <param name="pdf"></param>
        /// <returns></returns>
        /// <summary>
        /// Updates the specified record with a serialized PDF.
        /// </summary>
        /// <param name="policyId">The policy ID of the record to update.</param>
        /// <param name="requestDate">A string representation of the record timestamp (string used to preserve precision).</param>
        /// <param name="pdf">The serialized PDF to upload.</param>
        /// <returns>True, if a record was updated; otherwise, False.</returns>
        public static bool UploadPdf(string policyId, string requestDate, byte[] pdf)
        {
            const string sql = "UPDATE WOWTB.PORTAL_ILLUS_REQ SET PIRQ_STATUS = 'COMPLETE', PIRQ_CMPLTN_TS = CURRENT TIMESTAMP, PIRQ_ILLUS_PDF = ? WHERE PIRQ_STATUS = 'SUBMITTED' AND PIRQ_ADMIN_SYS_ID = 'I' AND PIRQ_POL_ID = ? AND PIRQ_REQ_TS = ? ";

            if (policyId == null)
            {
                if (log.IsErrorEnabled) log.Error("UploadPdf - The passed PolicyId was null.");
                throw new ArgumentNullException("policyId", "PolicyID cannot be null.");
            }

            if (requestDate == null)
            {
                if (log.IsErrorEnabled) log.Error("UploadPdf - The passed RequestDate was null.");
                throw new ArgumentNullException("requestDate", "RequestDate cannot be null.");
            }

            if (pdf == null)
            {
                if (log.IsErrorEnabled) log.Error("UploadPdf - The passed PDF was null.");
                throw new ArgumentNullException("pdf", "PDF cannot be null.");
            }

            if (log.IsDebugEnabled) log.DebugFormat(CultureInfo.InvariantCulture, "UploadPDF - policyId:{0}, requestDate:{1}, pdf.Length:{2}", policyId, requestDate, pdf.Length);

            using (var conn = new OleDbConnection(Settings.Default.DB2Connection))
            {
                using (var cmd = new OleDbCommand(sql, conn))
                {
                    var filebytes = pdf;
                    cmd.Parameters.AddWithValue("h1", filebytes);
                    cmd.Parameters.AddWithValue("h2", policyId);
                    cmd.Parameters.AddWithValue("h3", requestDate);

                    var records = DataUtilities.ExecuteNonQuery(cmd);
                    if (log.IsDebugEnabled) log.DebugFormat(CultureInfo.InvariantCulture, "UploadPDF - Records Affected:{0}", records);
                    return records > 0;
                }
            }
        }
    }
}
