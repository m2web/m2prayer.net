using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using m2prayer.Controllers;
using m2prayer.Services;
using Moq;

namespace m2prayer.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var mockVerseService = new Mock<IJmVersesService>();
            HomeController controller = new HomeController(mockVerseService.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
