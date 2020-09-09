using System;
using System.Collections.Generic;
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
    /// Interaction logic for etiketaIzmeni.xaml
    /// </summary>
    public partial class etiketaIzmeni : Page
    {

        public etiketaIzmeni(Etiketa et)
        {
           // WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            InitializeComponent();
            this.DataContext = et;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            pokazivac.Fill = new SolidColorBrush(Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                oznakaEtikete.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                pokazivac.GetBindingExpression(Shape.FillProperty).UpdateSource();
                opisEtikete.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
               
               // this.Close();
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
                greskaOznaka.Content = "";
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

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }
    }
}
