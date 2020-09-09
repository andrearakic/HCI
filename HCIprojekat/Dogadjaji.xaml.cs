using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace HCIprojekat
{
    /// <summary>
    /// Interaction logic for Dogadjaji.xaml
    /// </summary>
    public partial class Dogadjaji: Window, INotifyPropertyChanged
    {
        public static ObservableCollection<Dogadjaj> listaDogadjaja = new ObservableCollection<Dogadjaj>();
        public static ObservableCollection<Dogadjaj> listaDogadjajaFiltracija = new ObservableCollection<Dogadjaj>();
        public static ObservableCollection<Dogadjaj> listaDogadjajaPretraga = new ObservableCollection<Dogadjaj>();



        public static List<String> listaT = new List<string>();
        public static ObservableCollection<Etiketa> listaE = new ObservableCollection<Etiketa>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private ICollectionView _View;
        public ICollectionView View
        {
            get
            {
                return _View;
            }
            set
            {
                _View = value;
                OnPropertyChanged("View");
            }
        }

        public Dogadjaji()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            InitializeComponent();

            listaD.ItemsSource = listaDogadjaja;
            Dogadjaj d = new Dogadjaj();
            d.ListaEtiketa = Etikete.listaEtiketa;
            listaE = Etikete.listaEtiketa;
            this.DataContext = d;
            View = CollectionViewSource.GetDefaultView(listaD);

            listaT.Clear();
            for (int i = 0; i < Tipovi.listaTipova.Count; i++)
            {
                listaT.Add(Tipovi.listaTipova[i].Oznaka);
            }
            izaberiTip.ItemsSource = listaT;


        }

        private void ListaD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //dogadjajDodaj dd = new dogadjajDodaj();
            listaD.ItemsSource = listaDogadjaja;
            // dd.Show();
            DogadjajFrame.Content = new dogadjajDodaj();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dogadjaj dogadjaj = listaD.SelectedItem as Dogadjaj;
            
            if (dogadjaj != null)
            {
                // dogadjajIzmeni di = new dogadjajIzmeni(dogadjaj);
                // di.Show();
                DogadjajFrame.Content = new dogadjajIzmeni(dogadjaj);
            }
            else
            {
                MessageBox.Show("Morate selektovati dogadjaj koji zelite da izmenite.");
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Dogadjaj dogadjaj = listaD.SelectedItem as Dogadjaj;
            if (dogadjaj != null)
            {
                listaDogadjaja.Remove(dogadjaj);
             
            }
            else
                MessageBox.Show("Morate selektovati dogadjaj koji zelite da obrisete.");
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            listaDogadjajaPretraga.Clear();
            int br = 0;
            ObservableCollection<Etiketa> izabraneEtikete = new ObservableCollection<Etiketa>();
            foreach (Etiketa et in izaberiEtikete.SelectedItems)
            {
                izabraneEtikete.Add(et);
            }
            foreach (Dogadjaj s in listaDogadjaja)
            {
                if ((oznaka.Text.Equals(s.Oznaka) || oznaka.Text.Equals("")) &&
                    (ime.Text.Equals(s.Ime) || ime.Text.Equals("")) &&
                    (opis.Text.Equals(s.Opis) || opis.Text.Equals("")) &&
                    (troskovi.Text.Equals(s.Troskovi) || troskovi.Text.Equals("")) &&
                    (drzava.Text.Equals(s.Drzava) || drzava.Text.Equals("")) &&
                    (grad.Text.Equals(s.Grad) || grad.Text.Equals("")) &&
                    (izaberiTip.Text.Equals(s.Tip) || izaberiTip.Text.Equals("")) &&
                    (datum_odrzavanja.Text.Equals(s.Datum_odrzavanja) || datum_odrzavanja.Text.Equals("")) &&
                    (ikonica.Source == null || ikonica.Source.ToString().Equals(s.Ikona)) &&
                    (humanitarno.IsChecked.Equals(s.Humanitarno) || (humanitarno.IsChecked == false) &&
                    (posecenost.Text.Equals(s.Posecenost) || posecenost.Text.Equals("")) &&
                    (istorija_datuma.Text.Equals(s.Istorija_datuma) || istorija_datuma.Text.Equals(""))
                    ))
                {
                    br = 0;
                    if (izabraneEtikete.Count == 0)
                    {
                        listaDogadjajaPretraga.Add(s);
                    }
                    else if (izabraneEtikete.Count == s.ListaEtiketa.Count)
                    {
                        for (int i = 0; i < izabraneEtikete.Count; i++)
                        {
                            for (int j = 0; j < izabraneEtikete.Count; j++)
                            {
                                if (izabraneEtikete[i].Oznaka.Equals(s.ListaEtiketa[j].Oznaka))
                                {
                                    br++;
                                }
                            }
                        }
                        if (br == izabraneEtikete.Count)
                        {
                            listaDogadjajaPretraga.Add(s);
                        }
                    }
                }
            }
            listaD.ItemsSource = listaDogadjajaPretraga;
        }

        private void TextPretrage_TextChanged(object sender, TextChangedEventArgs e)
        {
            listaDogadjajaFiltracija.Clear();
            if (izaberiPretragu.Text.Equals("Oznaka"))
            {
                foreach (Dogadjaj s in listaDogadjaja)
                {
                    if (s.Oznaka.StartsWith(textPretrage.Text))
                    {
                        listaDogadjajaFiltracija.Add(s);
                    }
                }
                listaD.ItemsSource = listaDogadjajaFiltracija;
            }
            else if (izaberiPretragu.Text.Equals("Ime"))
            {
                foreach (Dogadjaj s in listaDogadjaja)
                {
                    if (s.Ime.StartsWith(textPretrage.Text))
                    {
                        listaDogadjajaFiltracija.Add(s);
                    }
                }
                listaD.ItemsSource = listaDogadjajaFiltracija;
            }
            else if (izaberiPretragu.Text.Equals("Tip"))
            {
                foreach (Dogadjaj s in listaDogadjaja)
                {
                    if (s.Tip.StartsWith(textPretrage.Text))
                    {
                        listaDogadjajaFiltracija.Add(s);
                    }
                }
                listaD.ItemsSource = listaDogadjajaFiltracija;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            listaD.ItemsSource = listaDogadjaja;

            oznaka.Text = "";
            ime.Text = "";
            opis.Text = "";
            izaberiTip.Text = "";
            posecenost.Text = "";
            ikonica.Source = null;
            humanitarno.IsChecked = false;
            troskovi.Text = "";
            drzava.Text = "";
            grad.Text = "";
            istorija_datuma.Text = "";
            datum_odrzavanja.Text = "";


        }

        private void IzaberiTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void IzaberiEtikete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            ikonica.Source = new BitmapImage(new Uri(dlg.FileName));
        }
    }
}
