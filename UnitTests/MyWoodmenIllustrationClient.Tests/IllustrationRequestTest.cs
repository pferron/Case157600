using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.OleDb;
using WOW.MyWoodmenIllustrationClient.Data;

namespace MyWoodmenIllustrationClient.Tests
{
    [TestClass]
    public class IllustrationRequestTest
    {
        private const string TestPolicyId = "009999999";
        private const string TestErrorMessage = "This is a test";

        //[TestMethod]
        //public void TestSelectNewRequests()
        //{
        //    try
        //    {
        //        InsertTestRecord();

        //        using (var dt = IllustrationRequest.SelectNewRequests())
        //        {
        //            Assert.AreNotEqual(0, dt.Rows.Count, "There should be at least one new request.");
        //        }
        //    }
        //    finally
        //    {
        //        DeleteTestRecord();
        //    }
        //}

        //[TestMethod]
        //public void TestUpdateAsError()
        //{
        //    try
        //    {
        //        InsertTestRecord();

        //        using (var dt = IllustrationRequest.SelectNewRequests())
        //        {
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                var policyId = (string)dr["PIRQ_POL_ID"];
        //                if (TestPolicyId.Equals(policyId))
        //                {
        //                    var requestTime = (string)dr["PIRQ_REQ_TS"]; // Use string to maintain timestamp precision.
        //                    var errorMessage = TestErrorMessage;
        //                    var result = IllustrationRequest.UpdateAsError(policyId, requestTime, errorMessage);
        //                    Assert.IsTrue(result, "Update did not affect any records.");
        //                }
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        DeleteTestRecord();
        //    }
        //}

        //[TestMethod]
        //public void TestUpdateAsError_Invalid()
        //{
        //    var policyId = TestPolicyId;
        //    var requestTime = SharedUtilities.GetCurrentDB2Timestamp();
        //    var errorMessage = TestErrorMessage;
        //    var result = IllustrationRequest.UpdateAsError(policyId, requestTime, errorMessage);

        //    Assert.IsFalse(result, "No records should have been updated.");
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestUpdateAsError_NullPolicyId()
        //{
        //    string policyId = null;
        //    var requestTime = SharedUtilities.GetCurrentDB2Timestamp();
        //    var errorMessage = string.Empty;

        //    var result = IllustrationRequest.UpdateAsError(policyId, requestTime, errorMessage);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestUpdateAsError_NullRequestDate()
        //{
        //    var policyId = TestPolicyId;
        //    string requestTime = null;
        //    var errorMessage = string.Empty;

        //    var result = IllustrationRequest.UpdateAsError(policyId, requestTime, errorMessage);
        //}

        //[TestMethod]
        //public void TestUploadPdf()
        //{
        //    try
        //    {
        //        InsertTestRecord();

        //        using (var dt = IllustrationRequest.SelectNewRequests())
        //        {
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                var policyId = (string)dr["PIRQ_POL_ID"];
        //                if (TestPolicyId.Equals(policyId))
        //                {
        //                    var requestTime = (string)dr["PIRQ_REQ_TS"]; // Use string to maintain timestamp precision.
        //                    var pdf = SharedUtilities.GetPdfSample2();
        //                    var result = IllustrationRequest.UploadPdf(policyId, requestTime, pdf);
        //                    Assert.IsTrue(result, "Update did not affect any records.");
        //                }
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        DeleteTestRecord();
        //    }
        //}

        //[TestMethod]
        //public void TestUploadPdf_Invalid()
        //{
        //    var policyId = TestPolicyId;
        //    var requestTime = SharedUtilities.GetCurrentDB2Timestamp();
        //    var pdf = SharedUtilities.GetPdfSample2();
        //    var result = IllustrationRequest.UploadPdf(policyId, requestTime, pdf);

        //    Assert.IsFalse(result, "No records should have been updated.");
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestUploadPdf_NullPolicyId()
        //{
        //    string policyId = null;
        //    var requestTime = SharedUtilities.GetCurrentDB2Timestamp();
        //    var pdf = SharedUtilities.GetPdfSample2();

        //    var result = IllustrationRequest.UploadPdf(policyId, requestTime, pdf);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestUploadPdf_NullRequestDate()
        //{
        //    var policyId = TestPolicyId;
        //    string requestTime = null;
        //    var pdf = SharedUtilities.GetPdfSample2();

        //    var result = IllustrationRequest.UploadPdf(policyId, requestTime, pdf);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestUploadPdf_NullPdf()
        //{
        //    var policyId = TestPolicyId;
        //    var requestTime = SharedUtilities.GetCurrentDB2Timestamp();
        //    byte[] pdf = null;

        //    var result = IllustrationRequest.UploadPdf(policyId, requestTime, pdf);
        //}

        public void InsertTestRecord()
        {
            const string sql = "INSERT INTO WOWTB.PORTAL_ILLUS_REQ (PIRQ_REQ_TS, PIRQ_ACTV_REQ_TS, PIRQ_POL_ID, PIRQ_STATUS, PIRQ_CMPLTN_TS, PIRQ_ADMIN_SYS_ID, PIRQ_REQ_USER_ID, PIRQ_CHG, PIRQ_CHG_DESCR, PIRQ_PRCS_ERR_MSG, PIRQ_FIP_FILE, PIRQ_ILLUS_PDF, PIRQ_SCNTRCT_ID) VALUES (CURRENT TIMESTAMP, CURRENT TIMESTAMP, ?, 'SUBMITTED', '1111-11-11-10.11.11.111000', 'I', 'SDG5989', 'N', 'Unit Test', '', ?, null, 0) ";

            using (var conn = new OleDbConnection(SharedUtilities.GetDefaultDB2Connection()))
            {
                using (var cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("h1", TestPolicyId);
                    cmd.Parameters.AddWithValue("h2", SharedUtilities.GetFipSample1());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTestRecord()
        {
            const string sql = "DELETE FROM WOWTB.PORTAL_ILLUS_REQ WHERE PIRQ_ADMIN_SYS_ID = 'I' AND PIRQ_REQ_USER_ID = 'SDG5989' AND PIRQ_POL_ID = ? AND PIRQ_CHG_DESCR = 'Unit Test'";

            using (var conn = new OleDbConnection(SharedUtilities.GetDefaultDB2Connection()))
            {
                using (var cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("h1", TestPolicyId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
