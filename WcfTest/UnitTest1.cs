using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfService;
using Newtonsoft.Json;

namespace WCFServiceTest
{

    [TestClass]
    public class UnitTest1
    {
        WCFService wCFService = new WCFService();
        int value = 4;
        /// <summary>
        /// Тест на кратность
        /// </summary>
        [TestMethod]
        public void TestKratnost()
        {
            var rezNK = wCFService.Kratnost(value);
            Assert.IsTrue(rezNK);
        }
        /// <summary>
        /// Тест на возведение в степень
        /// </summary>
        [TestMethod]
        public void TestVozvedenieVStepen()
        {
            bool error = false;
            var rez = wCFService.VozvedenieVStepen(value);
            if (Math.Sqrt(rez) != value)
                error = true;
            Assert.IsFalse(error);
        }
        /// <summary>
        /// Тест на формат JSON
        /// </summary>
        [TestMethod]
        public void TestGetData()
        {
            bool error = false;
            try
            {
                var rez = wCFService.GetData(value);
                JsonConvert.DeserializeObject(rez);
            }
            catch (Exception ex)
            {
                error = true;
            }
            Assert.IsFalse(error);
        }
    }
}
