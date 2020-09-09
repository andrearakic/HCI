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
    /// Interaction logic for tipIzmeni.xaml
    /// </summary>
    public partial class tipIzmeni : Page
    {
        public tipIzmeni(Tip t)
        {
           // WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            InitializeComponent();
            this.DataContext = t;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            ikonicaTipa.Source = new BitmapImage(new Uri(dlg.FileName));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                oznakaTipa.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                imeTipa.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                opisTipa.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                ikonicaTipa.GetBindingExpression(Image.SourceProperty).UpdateSource();
               
               // this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Popunite sva obavezna polja!");

            }
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
                greskaOznaka.Content = "";
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
        
        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
           // this.Close();

        }
    }
}

