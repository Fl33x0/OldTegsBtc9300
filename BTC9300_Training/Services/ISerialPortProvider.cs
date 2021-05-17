using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC9300Training.Services
{
    public interface ISerialPortProvider
    {
        string PortName { get; set; }

        int BaudRate { get; set; }

        System.IO.Ports.Parity Parity { get; set; }

        int DataBits { get; set; }

        System.IO.Ports.StopBits StopBits { get; set; }

        void Write(byte[] query, int offset, int queryLength);

        int Read(byte[] buffer, int offset, int count);

        void Open();
    }
}
