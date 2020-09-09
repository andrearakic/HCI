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

    public class Tip : INotifyPropertyChanged
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
        private string ime { get; set; }
        private string opis { get; set; }
        private string slika { get; set; }
        private ObservableCollection<Dogadjaj> dogadjajiTipa = new ObservableCollection<Dogadjaj>();


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

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
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

        public string Slika
        {
            get
            {
                return slika;
            }
            set
            {
                if (slika != value)
                {
                    slika = value;
                    OnPropertyChanged("Slika");
                }
            }
        }

        public ObservableCollection<Dogadjaj> DogadjajiTipa
        {
            get
            {
                return dogadjajiTipa;
            }
            set
            {
                if (dogadjajiTipa != value)
                {
                    dogadjajiTipa = value;
                    OnPropertyChanged("DogadjajiTipa");
                }
            }
        }


        public Tip(string oznaka, string ime, string opis, string slika)
        {
            this.oznaka = oznaka;
            this.ime = ime;
            this.opis = opis;
            this.slika = slika;
        }

        public Tip()
        {

        }
    }
}
