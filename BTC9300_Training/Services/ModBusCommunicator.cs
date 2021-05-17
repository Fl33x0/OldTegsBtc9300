using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using BTC9300Training.Services;

namespace BTC9300Training
{
    public class ModBusCommunicator : IModBusCommunicator
    {
        private ISerialPortProvider _serialPort;

        ISerialPortProvider IModBusCommunicator.SerialPort { get => _serialPort; set => _serialPort = value; }

        public void CreateQuery(byte[] query)
        {            
            _serialPort.Write(query, 0, query.Length);
            Thread.Sleep(50);
        }

        public byte[] GetAnswer()
        {
            byte[] _buffer = new byte[7];

            _serialPort.Read(_buffer, 0, 7);

            return _buffer;            
        }

        public byte[] CreateByteArrForQuery(byte a1, byte a0, byte q1, byte q0, byte n1, byte n0, byte d1, byte d0)
        {
            byte[] _byteArray = { a1, a0, q1, q0, n1, n0, d1, d0 };
            return _byteArray;
        }

        public void SetBTC9300DefaultParameters()
        {
            _serialPort.PortName = "COM8";
            _serialPort.BaudRate = 38400;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.Open();
        }
        
        public ModBusCommunicator(ISerialPortProvider serialPort)
        {
            _serialPort = serialPort;
            SetBTC9300DefaultParameters();
        }
    }
}
