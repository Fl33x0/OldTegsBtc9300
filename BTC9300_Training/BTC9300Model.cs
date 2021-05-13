using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using System.Threading;
using System.IO;
using System.IO.Ports;

namespace BTC9300Training
{
    class BTC9300Model : INotifyPropertyChanged
    {
        private double _temperature;

        ModBusCommunicator _modBusCommunicator;
        
        public double Temperature
        {
            get
            {
                return _temperature;
            }

            private set
            {
                {
                    if (value != this._temperature)
                    {
                        _temperature = value;
                        OnPropertyChanged();
                    }
                }
            }
        }
        public void GetTemperature(object sender)
        {            
            byte[] queryToDevice = { 0x01, 0x03, 0x00, 0x80, 0x00, 0x01, 0x85, 0xE2 };

            _modBusCommunicator.CreateQuery(queryToDevice);

            byte[] answerFromDevice = _modBusCommunicator.GetAnswer();

            int _x = (answerFromDevice[3] << 8) + answerFromDevice[4];

            Temperature = (double)(-19999 + _x * (45536 + 19999) / 65535) / 10;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static SerialPort _serialPort = new SerialPort();

        public void ThreadedTemperature()
        {
            

            _serialPort.PortName = "COM8";
            _serialPort.BaudRate = 38400;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.Open();

            _modBusCommunicator = new ModBusCommunicator(_serialPort);
            
            var timer = new Timer(new TimerCallback(GetTemperature));

            timer.Change(0, 100);
        }
    }
}
