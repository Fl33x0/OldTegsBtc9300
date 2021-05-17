using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC9300Training.Services
{
    public class SerialPortProvider : ISerialPortProvider
    {
        SerialPort _serialPort;
        string ISerialPortProvider.PortName { get => _serialPort.PortName; set => _serialPort.PortName = value; }

        int ISerialPortProvider.BaudRate { get => _serialPort.BaudRate; set => _serialPort.BaudRate = value; }

        Parity ISerialPortProvider.Parity { get => _serialPort.Parity; set => _serialPort.Parity = value; }

        int ISerialPortProvider.DataBits { get => _serialPort.DataBits; set => _serialPort.DataBits = value; }

        StopBits ISerialPortProvider.StopBits { get => _serialPort.StopBits; set => _serialPort.StopBits = value; }

        void ISerialPortProvider.Open()
        {
            _serialPort.Open();
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            return _serialPort.Read(buffer, offset, count);
        }

        public void Write(byte[] query, int offset, int queryLength)
        {
            _serialPort.Write(query, offset, queryLength);
        }

        public SerialPortProvider()
        {
            _serialPort = new SerialPort();
        }
    }
}
