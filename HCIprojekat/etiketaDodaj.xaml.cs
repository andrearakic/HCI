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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace HCIprojekat
{
    /// <summary>
    /// Interaction logic for etiketaDodaj.xaml
    /// </summary>
    public partial class etiketaDodaj : Page
    {
        ColorDialog cd = new ColorDialog();

        public etiketaDodaj()
        {
            InitializeComponent();
            //WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cd.ShowDialog();
            pokazivac.Fill = new SolidColorBrush(Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B));
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }

        private void Button_Click_DodajEtiketu(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                Etiketa etiketa = new Etiketa(oznakaEtikete.Text, pokazivac.Fill.ToString(), opisEtikete.Text);
                Etikete.listaEtiketa.Add(etiketa);
                
                oznakaEtikete.Text = "";
                pokazivac.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                opisEtikete.Text = "";
                
            }
            else
            {
                System.Windows.MessageBox.Show("Popunite sva polja!");
            }
        }

        private bool validate()
        {
            bool validation = true;

            if (oznakaEtikete.Text == "")
            {
                greskaOznaka.Content = "Unesite oznaku!";

                validation = false;
            }
            else
            {
                foreach (Etiketa et in Etikete.listaEtiketa)
                {
                    if (et.Oznaka.Equals(oznakaEtikete.Text))
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

            if (pokazivac.Fill.Equals(new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))))
            {
                greskaBoja.Content = "Unesite boju!";

                validation = false;
            }
            else
            {
                greskaBoja.Content = "";
            }

            return validation;
        }

        

        
    }
}
