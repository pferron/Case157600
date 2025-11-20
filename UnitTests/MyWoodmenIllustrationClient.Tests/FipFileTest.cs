using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyWoodmenIllustrationClient.Tests
{
    [TestClass]
    public class FipFileTest
    {
        //[TestMethod]
        //public void TestDeserialize()
        //{
        //    var privateType = CreateFipFileType();
        //    var content = SharedUtilities.GetFipSample1();

        //    var fipFile = privateType.InvokeStatic("Deserialize", content);

        //    //Validate the results.
        //    var privateObjectCount = new PrivateObject(fipFile, "Sections.Count");
        //    var count = (int)privateObjectCount.Target;

        //    Assert.AreEqual(15, count, "There should be 15 sections in the first FIP sample.");
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestDeserialize_Null()
        //{
        //    var privateType = CreateFipFileType();
        //    string content = null;

        //    privateType.InvokeStatic("Deserialize", content);
        //}

        //[TestMethod]
        //public void TestConstructor()
        //{
        //    var privateObjectFipFile = CreateFipFileObject();

        //    //Validate the results.
        //    var privateObjectCount = new PrivateObject(privateObjectFipFile, "Sections.Count");
        //    var count = (int)privateObjectCount.Target;

        //    Assert.AreEqual(0, count, "There not be any sections from the default constructor.");
        //}

        //[TestMethod]
        //public void TestToBytes_Empty()
        //{
        //    object[] args = null;
        //    var privateObjectFipFile = new PrivateObject("MyWoodmenIllustrationClient", "WOW.MyWoodmenIllustrationClient.Model.FipFile", args);

        //    var byteState = (byte[])privateObjectFipFile.Invoke("ToBytes", args);
        //    Assert.AreEqual(0, byteState.Length, "There should not be any bytes from the default constructor.");
        //}

        //[TestMethod]
        //public void TestToBytes_FipSample1()
        //{
        //    var privateType = CreateFipFileType();
        //    var content = SharedUtilities.GetFipSample1();

        //    var fipFile = privateType.InvokeStatic("Deserialize", content);

        //    //Validate the results.
        //    var privateObjectFipFile = new PrivateObject(fipFile);
        //    object[] args = null;
        //    var byteState = (byte[])privateObjectFipFile.Invoke("ToBytes", args);

        //    var message = string.Format("There should be {0} bytes returned from processing the first FIP sample.", SharedUtilities.FipSample1ProcessedByteLenth);
        //    Assert.AreEqual(SharedUtilities.FipSample1ProcessedByteLenth, byteState.Length, message);
        //}

        //[TestMethod]
        //public void TestToString_Empty()
        //{
        //    var privateObjectFipFile = CreateFipFileObject();
        //    object[] args = null;
        //    var stringState = (string)privateObjectFipFile.Invoke("ToString", args);
        //    Assert.AreEqual(string.Empty, stringState, "The string state from the default constructor should be empty.");
        //}

        //[TestMethod]
        //public void TestToString_FipSample1()
        //{
        //    var privateType = CreateFipFileType();
        //    var content = SharedUtilities.GetFipSample1();

        //    var fipFile = privateType.InvokeStatic("Deserialize", content);

        //    //Validate the results.
        //    var privateObjectFipFile = new PrivateObject(fipFile);
        //    object[] args = null;
        //    var stringState = (string)privateObjectFipFile.Invoke("ToString", args);

        //    var message = string.Format("There should be {0} characters returned from processing the first FIP sample.", SharedUtilities.FipSample1ProcessedStringLength);
        //    Assert.AreEqual(SharedUtilities.FipSample1ProcessedStringLength, stringState.Length, message);
        //}

        //[TestMethod]
        //public void TestUpdateOutputLocation_Empty()
        //{
        //    var privateObjectFipFile = CreateFipFileObject();
        //    string newFileName = "It doesn't matter";
        //    privateObjectFipFile.Invoke("UpdateOutputLocation", newFileName);

        //    object[] args = null;
        //    var stringState = (string)privateObjectFipFile.Invoke("ToString", args);
        //    Assert.AreEqual(string.Empty, stringState, "The string state from the default constructor should be empty.");
        //}

        //[TestMethod]
        //public void TestUpdateOutputLocation_FipSample1()
        //{
        //    var privateType = CreateFipFileType();
        //    var content = SharedUtilities.GetFipSample1();

        //    var fipFile = privateType.InvokeStatic("Deserialize", content);

        //    //Validate the results.
        //    var privateObjectFipFile = new PrivateObject(fipFile);
        //    string newFileName = "It doesn't matter";
        //    privateObjectFipFile.Invoke("UpdateOutputLocation", newFileName);

        //    object[] args = null;
        //    var stringState = (string)privateObjectFipFile.Invoke("ToString", args);

        //    var containsName = stringState.Contains(newFileName);
        //    Assert.IsTrue(containsName, "The string state from processing the first FIP sample should contain the new file name");
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestUpdateOutputLocation_Null()
        //{
        //    var privateObjectFipFile = CreateFipFileObject();
        //    string newFileName = null;

        //    privateObjectFipFile.Invoke("UpdateOutputLocation", newFileName);
        //}

        //[TestMethod]
        //public void TestValidate()
        //{
        //    // This method is obsolete and will be removed.
        //}

        private PrivateObject CreateFipFileObject()
        {
            object[] args = null;

            return new PrivateObject("MyWoodmenIllustrationClient", "WOW.MyWoodmenIllustrationClient.Model.FipFile", args);

        }

        private PrivateType CreateFipFileType()
        {
            return new PrivateType("MyWoodmenIllustrationClient", "WOW.MyWoodmenIllustrationClient.Model.FipFile");
        }
    }
}
