using m2prayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace m2prayer.Tests.IntegrationTests.Services
{
    [TestClass]
    public class EsvApiTests
    {
        private IEsvApi _esvApi;

        [TestInitialize]
        public void Init()
        {
            _esvApi = new EsvApi();
        }

        [TestMethod]
        public void TestGetVerse()
        {
            StringAssert.Contains(_esvApi.GetVerse("John 1:1"), "In the beginning was the Word");
        }

        [TestMethod]
        public void TestGetDailyVerse()
        {
            Assert.IsNotNull(_esvApi.GetDailyVerse());
        }
    }
}
