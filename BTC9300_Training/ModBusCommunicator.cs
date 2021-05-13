using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace BTC9300Training
{
    public class ModBusCommunicator
    {
        private SerialPort _serialPort;


        public ModBusCommunicator()
        {
            _serialPort = new SerialPort();    
            
            _serialPort.PortName = "COM8";
            _serialPort.BaudRate = 38400;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;

            //_serialPort.Open();
        }

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
    }
}
