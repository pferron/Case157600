using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace MyWoodmenIllustrationClient.Tests
{
    [TestClass]
    public class DataUtilitiesTest
    {
        //[TestMethod]
        //public void TestExecuteNonQuery()
        //{
        //    var privateType = CreateDataUtilties();
        //    int result = -1;

        //    using (var cmd = CreateCommand(SharedUtilities.GetDefaultDB2Connection()))
        //    {
        //        result = (int)privateType.InvokeStatic("ExecuteNonQuery", cmd);
        //    }

        //    Assert.AreEqual(0, result, "No Records should have been affected.");
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestExecuteNonQuery_Null()
        //{
        //    var privateType = CreateDataUtilties();
        //    OleDbCommand cmd = null;

        //    privateType.InvokeStatic("ExecuteNonQuery", cmd);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(OleDbException))]
        //public void TestExecuteNonQuery_OleDbException()
        //{
        //    var privateType = CreateDataUtilties();

        //    // Use a bad connection to trigger the retry logic.
        //    using (var cmd = CreateCommand(SharedUtilities.GetBadDB2Connection()))
        //    {
        //        privateType.InvokeStatic("ExecuteNonQuery", cmd);
        //    }
        //}

        //[TestMethod]
        //public void TestFill()
        //{
        //    var privateType = CreateDataUtilties();

        //    using (var dt = CreateDataTable())
        //    {
        //        using (var da = CreateDataAdapter(SharedUtilities.GetDefaultDB2Connection()))
        //        {
        //            privateType.InvokeStatic("Fill", da, dt);
        //        }
        //        Assert.AreEqual(1, dt.Rows.Count, "One records should have been returned.");
        //    }
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestFill_NullDataAdapter()
        //{
        //    var privateType = CreateDataUtilties();

        //    using (var dt = CreateDataTable())
        //    {
        //        object da = null;
        //        privateType.InvokeStatic("Fill", da, dt);
        //    }
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestFill_NullDataTable()
        //{
        //    var privateType = CreateDataUtilties();

        //    object dt = null;
        //    using (var da = CreateDataAdapter(SharedUtilities.GetDefaultDB2Connection()))
        //    {
        //        privateType.InvokeStatic("Fill", da, dt);
        //    }
        //}

        //[TestMethod]
        //[ExpectedException(typeof(OleDbException))]
        //public void TestFill_OleDbException()
        //{
        //    var privateType = CreateDataUtilties();

        //    using (var dt = CreateDataTable())
        //    {
        //        // Use a bad connection to trigger the retry logic.
        //        using (var da = CreateDataAdapter(SharedUtilities.GetBadDB2Connection()))
        //        {
        //            privateType.InvokeStatic("Fill", da, dt);
        //        }
        //    }
        //}

        private PrivateType CreateDataUtilties()
        {
            return new PrivateType("MyWoodmenIllustrationClient", "WOW.MyWoodmenIllustrationClient.Data.DataUtilities");            
        }

        private OleDbDataAdapter CreateDataAdapter(string connection)
        {
            const string sql = "select current timestamp AS CurrentTime from WOWTB.DUMMY";

            return new OleDbDataAdapter(sql, connection);
        }

        private DataTable CreateDataTable()
        {
            using (var dt = new DataTable("Dummy"))
            {
                dt.Locale = CultureInfo.InvariantCulture;
                return dt;
            }
        }

        private OleDbCommand CreateCommand(string connection)
        {
            const string sql = "UPDATE WOWTB.PORTAL_ILLUS_REQ SET PIRQ_STATUS = 'TEST' WHERE PIRQ_STATUS = 'TEST'";

            var conn = CreateConnection(connection);
            return new OleDbCommand(sql, conn);
        }

        private OleDbConnection CreateConnection(string connection)
        {
            return new OleDbConnection(connection);
        }
    }
}
