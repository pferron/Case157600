using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using WOW.Illustration.ValuesModel;

namespace PEIllustrationListener.Tests
{
    [TestClass]
    public class MessageHelperTest
    {
        //[TestMethod]
        //public void TestUnpackValuesResponse()
        //{
        //    var testResponse = CreateTestValueResponse();
        //    var responseString = Serialize(testResponse);

        //    var privateType = CreateMessageHelper();

        //    var newValues = (IllustrationValue)privateType.InvokeStatic("UnpackValuesResponse", responseString);

        //    Assert.AreEqual<int>(testResponse.AssumedLapseYear, newValues.AssumedLapseYear);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void TestUnpackValuesResponse_Empty()
        //{
        //    var responseString = string.Empty;
        //    var privateType = CreateMessageHelper();

        //    var newValues = (IllustrationValue)privateType.InvokeStatic("UnpackValuesResponse", responseString);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(JsonReaderException))]
        //public void TestUnpackValuesResponse_Invalid()
        //{
        //    var responseString = "This is an invalid response";
        //    var privateType = CreateMessageHelper();

        //    var newValues = (IllustrationValue)privateType.InvokeStatic("UnpackValuesResponse", responseString);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestUnpackValuesResponse_Null()
        //{
        //    string responseString = null;
        //    var privateType = CreateMessageHelper();

        //    var newValues = (IllustrationValue)privateType.InvokeStatic("UnpackValuesResponse", responseString);
        //}

        private PrivateType CreateMessageHelper()
        {
            return new PrivateType("MyWoodmenIllustrationClient", "WOW.MyWoodmenIllustrationClient.Utilities.MessageHelper");
        }

        private IllustrationValue CreateTestValueResponse()
        {
            var values = new IllustrationValue();
            values.AssumedLapseYear = 20;

            return values;
        }

        private string Serialize(IllustrationValue values)
        {
            return JsonConvert.SerializeObject(values);
        }
    }
}
