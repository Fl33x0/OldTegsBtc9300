using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BTC9300Training
{
    class BTC9300Model : INotifyPropertyChanged
    {
        private double _temperature;

        ModBusCommunicator _modBusCommunicator = new ModBusCommunicator();
        public double Temperature
        {
            get
            {
                return this._temperature;
            }

            private set
            {
                {
                    if (value != this._temperature)
                    {
                        this._temperature = value;
                        OnPropertyChanged("Temperature");
                    }
                }
            }
        }
        public void GetTemperature()
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
    }
}
