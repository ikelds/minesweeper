using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp22
{
    class Mines : INotifyPropertyChanged
    {
        private int mines;

        public int MinesProp
        {
            get  { return mines; }
            set
            {
                mines = value;
                OnPropertyChanged("MinesProp");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]String prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
