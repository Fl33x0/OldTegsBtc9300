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
    public class BTC9300Model : INotifyPropertyChanged
    {
        private double _temperature;

        private Services.IModBusCommunicator _modBusCommunicator;


        public Services.IModBusCommunicator ModBusCommunicator
        {
            get
            {
                return _modBusCommunicator;
            }
            set
            {
                _modBusCommunicator = value;
            }
        }

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
            byte[] queryToDevice = _modBusCommunicator.CreateByteArrForQuery(0x01, 0x03, 0x00, 0x80, 0x00, 0x01, 0x85, 0xE2);

            _modBusCommunicator.CreateQuery(queryToDevice);

            byte[] answerFromDevice = _modBusCommunicator.GetAnswer();

            ConvertTemperatureValue(answerFromDevice);
        }

        public double ConvertTemperatureValue(byte[] answerFromDevice)
        {
            int _x = (answerFromDevice[3] << 8) + answerFromDevice[4];

            return Temperature = (double)(-19999 + (_x * (45536 + 19999) / 65535)) / 10;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GetStreamOfTemperatureValue()
        {          
            var timer = new Timer(new TimerCallback(GetTemperature));

            timer.Change(0, 100);
        }

        public BTC9300Model(Services.IModBusCommunicator modBusCommunicator)
        {
            _modBusCommunicator = modBusCommunicator;
        }
    }
}
