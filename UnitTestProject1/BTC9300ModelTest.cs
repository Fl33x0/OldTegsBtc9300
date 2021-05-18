using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BTC9300Training;
using System.IO.Ports;
using Moq;
using BTC9300Training.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class BTC9300ModelTest
    {
        [TestMethod]
        public void ConvertTemperatureValue_byteArr_double0to1000()
        {
            IModBusCommunicator _testModBusCommunicator = Mock.Of<IModBusCommunicator>();

            BTC9300Model _btc = new BTC9300Model(_testModBusCommunicator);
            byte[] _byteArr = { 1, 3, 2, 78, 254, 12, 100 };
            double _expected = 22.3;

            double _actual = _btc.ConvertTemperatureValue(_byteArr);

            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void GetTemperature_()
        {
            byte[] _testArr = { 1, 3, 2, 78, 253, 76, 101 };
            var _modBus = Mock.Of<IModBusCommunicator>(m => m.GetAnswer() == _testArr);

            var _btc = new BTC9300Model(_modBus);
            _btc.GetTemperature("");

            double _expected = 22.2;
            Assert.AreEqual(_expected, _btc.Temperature);
        }        
    }
}
