using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using WOW.WoodmenIllustrationService.Controllers;

namespace WoodmenIllustrationService.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Woodmen Illustration Service", result.ViewBag.Title);
        }
    }
}
