using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BTC9300Training;

namespace UnitTestProject1
{
    [TestClass]
    public class ModBusCommunicatorTest
    {
        [TestMethod]
        public void CreateQueryWithValidArray()
        {
            //TODO: ПРИДУМАТЬ, ЧТО ПРОВЕРЯТЬ ПРИ УСПЕШНОЙ ПЕРЕДАЧЕ И СЧИТЫВАНИИ С ПОРТА

            //byte[] initialQuery = { 0x01, 0x03, 0x00, 0x80, 0x00, 0x01, 0x85, 0xE2 };

            //ModBusCommunicator testModBusCommunicator = new ModBusCommunicator();

            //testModBusCommunicator.CreateQuery(initialQuery);

            //Assert.AreEqual(initialQuery, testModBusCommunicator.GetAnswer());
        }

        [TestMethod]
        //[ExpectedException(typeof(InvalidOperationException), "Порт закрыт.")]
        public void CreateQueryWithPortClosed()
        {
            byte[] initialQuery = { 0x01, 0x03, 0x00, 0x80, 0x00, 0x01, 0x85, 0xE2 };

            //ModBusCommunicator testModbusCommunicator = new ModBusCommunicator();

            Action<byte[]> createQueryAction = testModbusCommunicator.CreateQuery;

            Assert.ThrowsException<InvalidOperationException>(() 
                => testModbusCommunicator.CreateQuery(initialQuery));
        }
    }
}
