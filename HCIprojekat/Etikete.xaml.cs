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
    /// Interaction logic for Tipovi.xaml
    /// </summary>
    public partial class Etikete : Window, INotifyPropertyChanged
    {
        public static ObservableCollection<Etiketa> listaEtiketa = new ObservableCollection<Etiketa>();

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


        public Etikete()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            listaE.ItemsSource = listaEtiketa;
            this.DataContext = this;
            View = CollectionViewSource.GetDefaultView(listaE);
        }

        private void ListaE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //etiketaDodaj ed = new etiketaDodaj();
            //ed.Show();
            EtiketaFrame.Content = new etiketaDodaj();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Etiketa et = listaE.SelectedItem as Etiketa;
            if (et != null)
            {
                //etiketaIzmeni ei = new etiketaIzmeni(et);
                //ei.Show();
                EtiketaFrame.Content = new etiketaIzmeni(et);

            }
            else
            {
                MessageBox.Show("Morate selektovati etiketu koju zelite da izmenite.");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Etiketa et = listaE.SelectedItem as Etiketa;
            if (et != null)
            {
                listaEtiketa.Remove(et);
            }
            else
                MessageBox.Show("Morate selektovati etiketu koju zelite da obrisete.");
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
