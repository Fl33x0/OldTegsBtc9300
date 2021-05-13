using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Threading;

namespace BTC9300Training 
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private BTC9300Model _btc = new BTC9300Model();

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

        public MainWindowViewModel()
        {
            _btc.GetTemperature();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void ThreadedTemperature()
        {
            var timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }

        public void timerTick(object sender, EventArgs e)
        {
            _btc.GetTemperature();
        }
    }
}
