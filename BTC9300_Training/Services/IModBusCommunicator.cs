using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace BTC9300Training.Services
{
    public interface IModBusCommunicator
    {
        ISerialPortProvider SerialPort { get; set; }
        void CreateQuery(byte[] query);

        byte[] GetAnswer();

        byte[] CreateByteArrForQuery(byte a1, byte a0, byte q1, byte q0, byte n1, byte n0, byte d1, byte d0);
    }
}
