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
    /// Interaction logic for tipDodaj.xaml
    /// </summary>
    public partial class tipDodaj : Page
    {
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

        public tipDodaj()
        {
           // WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            InitializeComponent();
          
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
           // this.Close();

        }

        private void Button_Click_DodajTip(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                Tip tip = new Tip(oznakaTipa.Text, imeTipa.Text, opisTipa.Text, ikonicaTipa.Source.ToString());
                Tipovi.listaTipova.Add(tip);

                oznakaTipa.Text = "";
                imeTipa.Text = "";
                opisTipa.Text = "";
                ikonicaTipa.Source = null;
                
            }
            else
            {
                System.Windows.MessageBox.Show("Popunite obavezna polja na ispravan nacin.");

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            ikonicaTipa.Source = new BitmapImage(new Uri(dlg.FileName));

        }

        private bool validate()
        {
            bool validation = true;

            if (oznakaTipa.Text == "")
            {
                greskaOznaka.Content = "Unesite oznaku!";

                validation = false;
            }
            else
            {
                foreach (Tip et in Tipovi.listaTipova)
                {
                    if (et.Oznaka.Equals(oznakaTipa.Text))
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
            }

            if (imeTipa.Text == "")
            {
                greskaIme.Content = "Unesite ime!";

                validation = false;
            }
            else
            {
                greskaIme.Content = "";
            }

            if (ikonicaTipa.Source == null)
            {
                greskaSlika.Content = "Dodajte sliku!";
                validation = false;
            }
            else
            {
                greskaSlika.Content = "";
            }


            return validation;
        }
    }
}

