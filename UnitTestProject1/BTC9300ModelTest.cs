using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BTC9300Training;
using System.IO.Ports;

namespace UnitTestProject1
{
    [TestClass]
    public class BTC9300ModelTest
    {
        BTC9300Model _btc = new BTC9300Model();

        static SerialPort _serialPort = new SerialPort();



        [TestMethod]
        public void GetTemperature_ValidQuery_0To1000()
        {
            _serialPort.PortName = "COM8";
            _serialPort.BaudRate = 38400;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.Open();

            double _expectedMinValue = 0;
            double _expectedMaxValue = 1000;

            _btc.ModBusCommunicator = new ModBusCommunicator(_serialPort);

            _btc.GetTemperature("");
            bool _expected = true;
            bool _returned;

            if (_btc.Temperature < _expectedMaxValue & _btc.Temperature > _expectedMinValue)
            {
                _returned = true;
            }
            else
            {
                _returned = false;
            }

            Assert.AreEqual(_expected, _returned);
        }
    }
}
