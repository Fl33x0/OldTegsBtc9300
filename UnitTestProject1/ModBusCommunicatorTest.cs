using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO.Ports;
using Moq;
using BTC9300Training;
using BTC9300Training.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class ModBusCommunicatorTest
    {              

        [TestMethod]
        public void CreateQuery_WithClosedPort_InvalidOperationException()
        {
            ISerialPortProvider _port = Mock.Of<ISerialPortProvider>();
            var _testModBusCommunicator = new ModBusCommunicator(_port);         

            byte[] _expected = { 0x01, 0x03, 0x00, 0x80, 0x00, 0x01, 0x85, 0xE2 };            
            byte[] _actual = _testModBusCommunicator.CreateByteArrForQuery(0x01, 0x03, 0x00, 0x80, 0x00, 0x01, 0x85, 0xE2);

            CollectionAssert.AreEqual(_expected, _actual);
        }
    }
}
