using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIprojekat
{
    [Serializable]
    public class Ikonica : INotifyPropertyChanged
    {

        private double x;   //koordinate
        private double y;
        private Dogadjaj d;

        public event PropertyChangedEventHandler PropertyChanged;

        public Ikonica(double x, double y, Dogadjaj d)
        {
            this.x = x;
            this.y = y;
            this.d = d;
        }

        public Ikonica()
        {
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public double X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged("X");
                }
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                if (value != y)
                {
                    y = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        public Dogadjaj Do
        {
            get { return this.d; }
            set
            {
                if (this.d != value)
                {
                    d = value;
                    OnPropertyChanged("Do");
                }
            }
        }
    }
}
