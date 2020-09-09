using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Threading;


namespace HCIprojekat
{
    /// <summary>
    /// Interaction logic for dogadjajDodaj.xaml
    /// </summary>
    public partial class dogadjajDodaj : Page
    {

        public static ObservableCollection<Etiketa> listaE = new ObservableCollection<Etiketa>();
        public static List<String> listaT = new List<string>();
        public static ObservableCollection<Etiketa> izabraneEtikete = new ObservableCollection<Etiketa>();
        private Dogadjaj d = new Dogadjaj();
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



        public dogadjajDodaj()
        {
            //WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();

            d = new Dogadjaj();
            izabraneEtikete = new ObservableCollection<Etiketa>();
            d.ListaEtiketa = Etikete.listaEtiketa;
            listaE = Etikete.listaEtiketa;
            this.DataContext = d;


            listaT.Clear();
            for (int i = 0; i < Tipovi.listaTipova.Count; i++)
            {
                listaT.Add(Tipovi.listaTipova[i].Oznaka);
            }
            izaberiTip.ItemsSource = listaT;

            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            ikonica.Source = new BitmapImage(new Uri(dlg.FileName));
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }

        private void Button_Click_Dodaj(object sender, RoutedEventArgs e)
        {
            if (ikonica.Source == null)
            {
                for (int i = 0; i < Tipovi.listaTipova.Count; i++)
                {
                    if (Tipovi.listaTipova[i].Oznaka.Equals(izaberiTip.Text))
                    {
                        ImageSourceConverter imgConv = new ImageSourceConverter();
                        string path = Tipovi.listaTipova[i].Slika;
                        ImageSource imageSource = (ImageSource)imgConv.ConvertFromString(path);
                        ikonica.Source = imageSource;
                    }
                }
            }
            if (validate())
            {
                
                Dogadjaj dogadjaj = new Dogadjaj(oznaka.Text, ime.Text, opis.Text, izaberiTip.Text, posecenost.Text, ikonica.Source.ToString(), (bool)humanitarno.IsChecked, troskovi.Text, drzava.Text, grad.Text, istorija_datuma.Text, datum_odrzavanja.Text, izabraneEtikete);

                Dogadjaji.listaDogadjaja.Add(dogadjaj);

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
                izaberiEtikete.SelectedItems.Clear();

                foreach (Tip t in Tipovi.listaTipova)
                {
                    t.DogadjajiTipa.Clear();
                    foreach (Dogadjaj s in Dogadjaji.listaDogadjaja)
                    {
                        if (s.Tip.Equals(t.Oznaka))
                        {
                            t.DogadjajiTipa.Add(s);
                            foreach (Ikonica mi in MainWindow.mapaIkonica)
                            {
                                if (mi.Do.Oznaka.Equals(s.Oznaka))
                                {
                                    t.DogadjajiTipa.Remove(s);
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                System.Windows.MessageBox.Show("Popunite obavezna polja na ispravan nacin.");
            }
        }

        private bool validate()
        {
            bool validation = true;
//
            if (oznaka.Text == "")
            {
                greskaOznaka.Content = "Unesite oznaku!";
                oznaka.BorderBrush = Brushes.Red;

                validation = false;
            }
            else
            {
                foreach (Dogadjaj id in Dogadjaji.listaDogadjaja)
                {
                    if (id.Oznaka.Equals(oznaka.Text))
                    {
                        greskaOznaka.Content = "Vec postoji!";
                        validation = false;
                        break;
                    }
                    else
                    {
                        greskaOznaka.Content = "";
                    }
                }
                oznaka.BorderBrush = Brushes.Black;
            }
//
            if (ime.Text == "")
            {
                greskaIme.Content = "Unesite ime!";
                ime.BorderBrush = Brushes.Red;

                validation = false;
            }
            else
            {
                greskaIme.Content = "";
                ime.BorderBrush = Brushes.Black;
            }


            
                        if (izaberiTip.Text == "")
                        {
                            greskaTip.Content = "Izaberite tip!";
                            izaberiTip.BorderBrush = Brushes.Red;

                            validation = false;
                        }
                        else
                        {
                            greskaTip.Content = "";
                            izaberiTip.BorderBrush = Brushes.Black;
                        }
            


            if (ikonica.Source == null)
            {
                greskaIkonica.Content = "Dodajte sliku!";
                validation = false;
            }
            else
            {
                greskaIkonica.Content = "";
            }
                     
            
            
            /*if (datum_odrzavanja.Text == "")
            {
                greskaDatum.Content = "Unesite datum!";
                datum_odrzavanja.BorderBrush = Brushes.Red;

                validation = false;
            }
            else
            {
                greskaDatum.Content = "";
                datum_odrzavanja.BorderBrush = Brushes.Black;
            }
            */
            return validation;
        }
        //
        private void IzaberiEtikete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void IzaberiTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void IzaberiEtikete_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            izabraneEtikete.Clear();
            foreach (Etiketa et in izaberiEtikete.SelectedItems)
                {
                    izabraneEtikete.Add(et);
                }
        }

    }
}

