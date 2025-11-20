using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace MyWoodmenIllustrationClient.Tests
{
    [TestClass]
    public class FipSectionTest
    {
        //[TestMethod]
        //public void TestConstructor()
        //{
        //    var testSectionName = "TestSection";
        //    var privateObject = CreateFipSectionObject(testSectionName);

        //    object[] args = null;
        //    //Validate the results.
        //    var sectionName = (string)privateObject.GetProperty("Name", args);
        //    var message = string.Format(CultureInfo.InvariantCulture, "The section name {0} should be equal to {1}", sectionName, testSectionName);
        //    Assert.AreEqual(testSectionName, sectionName, message);
        //}

        //[TestMethod]
        //public void TestToString()
        //{
        //    var testSectionName = "TestSection";
        //    var expectedState = string.Format(CultureInfo.InvariantCulture, "[{0}]\r\n", testSectionName);
        //    var privateObjectFipFile = CreateFipSectionObject(testSectionName);

        //    object[] args = null;
        //    var stringState = (string)privateObjectFipFile.Invoke("ToString", args);
        //    var message = string.Format(CultureInfo.InvariantCulture, "The section state {0} should be equal to {1}", stringState, expectedState);
        //    Assert.AreEqual(expectedState, stringState, message);
        //}

        private PrivateObject CreateFipSectionObject(string sectionName)
        {
            var args = new object[] { sectionName };

            return new PrivateObject("MyWoodmenIllustrationClient", "WOW.MyWoodmenIllustrationClient.Model.FipSection", args);

        }
    }
}
