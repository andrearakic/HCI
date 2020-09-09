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
    public class Dogadjaj : INotifyPropertyChanged
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
        private string tip { get; set; }
        private string posecenost { get; set; }
        private string ikona { get; set; }
        private Boolean humanitarno { get; set; }
        private string troskovi { get; set; }
        private string drzava { get; set; }
        private string grad { get; set; }
        private string istorija_datuma { get; set; }
        private string datum_odrzavanja { get; set; }
        private ObservableCollection<Etiketa> listaEtiketa { get; set; }

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

        public string Tip
        {
            get
            {
                return tip;
            }
            set
            {
                if (value != tip)
                {
                    tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }


        public string Posecenost
        {
            get
            {
                return posecenost;
            }
            set
            {
                if (value != posecenost)
                {
                    posecenost = value;
                    OnPropertyChanged("Posecenost");
                }
            }
        }

        public bool Humanitarno
        {
            get
            {
                return humanitarno;
            }
            set
            {
                if (value != humanitarno)
                {
                    humanitarno = value;
                    OnPropertyChanged("Humanitarno");
                }
            }
        }

        public string Troskovi
        {
            get
            {
                return troskovi;
            }
            set
            {
                if (value != troskovi)
                {
                    troskovi = value;
                    OnPropertyChanged("Troskovi");
                }
            }
        }
        public string Drzava
        {
            get
            {
                return drzava;
            }
            set
            {
                if (value != drzava)
                {
                    drzava = value;
                    OnPropertyChanged("Drzava");
                }
            }
        }

        public string Grad
        {
            get
            {
                return grad;
            }
            set
            {
                if (value != grad)
                {
                    grad = value;
                    OnPropertyChanged("Grad");
                }
            }
        }
        public string Istorija_datuma
        {
            get
            {
                return istorija_datuma;
            }
            set
            {
                if (value != istorija_datuma)
                {
                    istorija_datuma = value;
                    OnPropertyChanged("Istorija_datuma");
                }
            }
        }

        public string Datum_odrzavanja
        {
            get
            {
                return datum_odrzavanja;
            }
            set
            {
                if (value != datum_odrzavanja)
                {
                    datum_odrzavanja = value;
                    OnPropertyChanged("Datum_odrzavanja");
                }
            }
        }

        public ObservableCollection<Etiketa> ListaEtiketa
        {
            get
            {
                return listaEtiketa;
            }
            set
            {
                if (value != listaEtiketa)
                {
                    listaEtiketa = value;
                    OnPropertyChanged("ListaEtiketa");
                }
            }
        }

        public string Ikona
        {
            get
            {
                return ikona;
            }
            set
            {
                if (value != ikona)
                {
                    ikona = value;
                    OnPropertyChanged("Ikona");
                }
            }
        }

        public Dogadjaj(string oznaka, string ime, string opis, string tip, string posecenost, string ikona, bool humanitarno, string troskovi, string drzava, string grad, string istorija_datuma, string datum_odrzavanja ,ObservableCollection<Etiketa> listaEtiketa)
        {
            this.oznaka = oznaka;
            this.ime = ime;
            this.opis = opis;
            this.tip = tip;
            this.posecenost = posecenost;
            this.ikona = ikona;
            this.humanitarno = humanitarno;
            this.troskovi = troskovi;
            this.drzava = drzava;
            this.grad = grad;
            this.istorija_datuma = istorija_datuma;
            this.datum_odrzavanja = datum_odrzavanja;
            this.listaEtiketa = listaEtiketa;
        }

        

        public Dogadjaj()
        {
        }
    }
}
