using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Input;
using System.IO.Ports;

namespace BTC9300Training 
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private BTC9300Model _btc = new BTC9300Model(new ModBusCommunicator(new Services.SerialPortProvider()));

        public BTC9300Model Btc
        {
            get
            {
                return _btc;
            }
            private set
            {
                _btc = value;
                OnPropertyChanged("");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      _btc.GetStreamOfTemperatureValue();
                  }));
            }
        }

        public MainWindowViewModel() { }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
