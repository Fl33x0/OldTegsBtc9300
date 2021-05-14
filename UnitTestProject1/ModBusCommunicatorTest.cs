using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BTC9300Training;
using System.IO.Ports;

namespace UnitTestProject1
{
    [TestClass]
    public class ModBusCommunicatorTest
    {
        static SerialPort _serialPort = new SerialPort();

        ModBusCommunicator _testModbusCommunicator = new ModBusCommunicator(_serialPort);

        [TestMethod]
        public void CreateQuery_WithClosedPort_InvalidOperationException()
        {
            byte[] initialQuery = { 0x01, 0x03, 0x00, 0x80, 0x00, 0x01, 0x85, 0xE2 };

            Action<byte[]> createQueryAction = _testModbusCommunicator.CreateQuery;

            Assert.ThrowsException<InvalidOperationException>(()
                => _testModbusCommunicator.CreateQuery(initialQuery), "Порт закрыт.");
        }
    }
}
