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
            bool _expected = true;

            _btc.ConvertTemperatureValue(_byteArr);
            bool _actual = false;

            if (_btc.Temperature >= 0 & _btc.Temperature <= 1000)
            {
                _actual = true;
            }

            Assert.AreEqual(_expected, _actual);
        }
    }
}
