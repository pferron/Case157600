using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WOW.LifePortraitsWebAuthentication.Controllers;
using WOW.LifePortraitsWebAuthentication.Models;

namespace LifePortraitsWebAuthentication.Tests
{
    [TestClass]
    public class LifePortraitsIntegrationTests
    {
        /// <summary>
        /// This method should return a valid LPA session URL.
        /// </summary>
        [TestMethod]
        public void RequestLpaSession_TestValidUser()
        {
            string user = "DAD7443";

            var controller = new WOW.LifePortraitsWebAuthentication.Controllers.IntegrationController();
            var result = controller.RequestLpaSession(user);

            Assert.IsTrue(result.Contains("TempAccountID"));
        }

        /// <summary>
        /// This method should return the error URL.
        /// </summary>
        [TestMethod]
        public void RequestLpaSession_TestInvalidUser()
        {
            string user = "XYZ1234";

            var controller = new WOW.LifePortraitsWebAuthentication.Controllers.IntegrationController();
            var result = controller.RequestLpaSession(user);

            Assert.IsTrue(result.Contains("Home/Error"));
        }

        /// <summary>
        /// This method should return the error URL.
        /// </summary>
        [TestMethod]
        public void RequestLpaSession_TestNullUser()
        {
            string user = null;

            var controller = new WOW.LifePortraitsWebAuthentication.Controllers.IntegrationController();
            var result = controller.RequestLpaSession(user);

            Assert.IsTrue(result.Contains("Home/Error"));
        }

        /// <summary>
        /// This method should return the error URL.
        /// </summary>
        [TestMethod]
        public void RequestLpaSession_TestEmptyUser()
        {
            string user = String.Empty;

            var controller = new WOW.LifePortraitsWebAuthentication.Controllers.IntegrationController();
            var result = controller.RequestLpaSession(user);

            Assert.IsTrue(result.Contains("Home/Error"));
        }

        /// <summary>
        /// The method should throw an exception when a null AuthorizationRequest is passed in.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void DetermineUserType_NullParameter()
        {
            var controller = new IntegrationController();

            var privateObject = new PrivateObject(controller);

            var result = privateObject.Invoke("DetermineUserType", new object[] { null });
        }

        /// <summary>
        /// When a valid username is passed to the integration service, the UserType should become known.
        /// The config file has whitelists that can be used to make specific usernames type a certain way.
        /// </summary>
        [TestMethod]
        public void DetermineUserType_ValidParameter()
        {
            var controller = new IntegrationController();

            var privateObject = new PrivateObject(controller);

            var authRequest = new AuthorizationRequest() { Username = "DAD7443" };

            var result = privateObject.Invoke("DetermineUserType", new object[] { authRequest });

            Assert.IsTrue(authRequest.UserType != AuthorizationRequest.LpaUserType.Unknown);
        }

        /// <summary>
        /// The method should throw an exception when a null AuthorizationRequest is passed in.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void LookupFullName_NullParameter()
        {
            var controller = new IntegrationController();

            var privateObject = new PrivateObject(controller);

            var result = privateObject.Invoke("LookupFullName", new object[] { null });
        }

        /// <summary>
        /// When a valid username is used, the first and last name from AD should be read and copied to the object.
        /// </summary>
        [TestMethod]
        public void LookupFullName_ValidParameter()
        {
            var testValue = "TEST";

            var controller = new IntegrationController();

            var privateObject = new PrivateObject(controller);

            // By setting the first and last name to a known value, we can simply check to see if it changed.
            // For example, the first name being blank in Active Directory may not seem useful, but it might be expected.
            // I'm just checking to make sure an assignment to the properties occurred.
            var authRequest = new AuthorizationRequest() { Username = "DAD7443", FirstName = testValue, LastName = testValue };

            var args = new object[] { authRequest };

            var result = privateObject.Invoke("LookupFullName", args);

            Assert.IsTrue(authRequest.LastName != testValue && authRequest.FirstName != testValue);
        }
    }
}
