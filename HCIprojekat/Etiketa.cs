using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIprojekat
{
    [Serializable]
    public class Etiketa : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string oznaka { get; set; }
        private string opis { get; set; }
        private String boja;

        public string Oznaka
        {
            get
            {
                return oznaka;
            }
            set
            {
                if (value != oznaka)
                {
                    oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public String Boja
        {
            get
            {
                return boja;
            }
            set
            {
                if (value != boja)
                {

                    boja = value;
                    OnPropertyChanged("Boja");
                }
            }
        }

        public string Opis
        {
            get
            {
                return opis;
            }
            set
            {
                if (value != opis)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public Etiketa(String oznaka, String boja, String opis)
        {
            this.oznaka = oznaka;
            this.boja = boja;
            this.opis = opis;
        }

        public Etiketa()
        {

        }
    }

}
