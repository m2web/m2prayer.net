using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using m2prayer.Services;


namespace m2prayer.Tests.Services
{
    [TestClass]
    public class Esv_Api
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
