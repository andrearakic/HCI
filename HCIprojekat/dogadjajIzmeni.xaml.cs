using System;
using System.Collections.Generic;
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
    /// Interaction logic for dogadjajIzmeni.xaml
    /// </summary>
    public partial class dogadjajIzmeni : Page
    { 

        public static List<String> listaT = new List<string>();
        Dogadjaj dogadjaj = new Dogadjaj();



        public dogadjajIzmeni(Dogadjaj d)
        {
            //WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.DataContext = d;
            InitializeComponent();
            
            dogadjaj = d;

            listaT.Clear();
            for (int i = 0; i < Tipovi.listaTipova.Count; i++)
            {
                listaT.Add(Tipovi.listaTipova[i].Oznaka);
            }
            izaberiTip.ItemsSource = listaT;
            izaberiTip.Text = d.Tip;
            
            izaberiEtikete.ItemsSource = Etikete.listaEtiketa;
            izaberiEtikete.SelectedItems.Clear();
            for (int i = 0; i < Etikete.listaEtiketa.Count; i++)
            {
                for (int j = 0; j < d.ListaEtiketa.Count; j++)
                {
                    if (Etikete.listaEtiketa[i].Oznaka == d.ListaEtiketa[j].Oznaka)
                    {
                        izaberiEtikete.SelectedItems.Add(Etikete.listaEtiketa[i]);
                    }
                }
            }

            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            ikonica.Source = new BitmapImage(new Uri(dlg.FileName));
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }

        private void Button_Click_Dodaj(object sender, RoutedEventArgs e)
        {

            if (validate())
            {               
                oznaka.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                ime.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                opis.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                izaberiTip.GetBindingExpression(ComboBox.TextProperty).UpdateSource();
                posecenost.GetBindingExpression(ComboBox.TextProperty).UpdateSource();
                ikonica.GetBindingExpression(Image.SourceProperty).UpdateSource();
                troskovi.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                drzava.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                grad.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                istorija_datuma.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                datum_odrzavanja.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
                humanitarno.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                
                izaberiEtikete.SelectedItems.Clear();
                foreach (Etiketa et in izaberiEtikete.SelectedItems)
                {
                    dogadjaj.ListaEtiketa.Add(et);
                }
                
                
                
               // this.Close();
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
                greskaOznaka.Content = "";
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


            /*
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
            */


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
            
        }

    }
}

