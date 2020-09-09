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
    public partial class Tipovi : Window, INotifyPropertyChanged
    {
       
        public static ObservableCollection<Tip> listaTipova = new ObservableCollection<Tip>();
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

        public Tipovi()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            listaT.ItemsSource = listaTipova;
            this.DataContext = this;
            View = CollectionViewSource.GetDefaultView(listaT);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // tipDodaj td = new tipDodaj();
            // td.Show();
            TipFrame.Content = new tipDodaj();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tip tip = listaT.SelectedItem as Tip;
            if (tip != null)
            {
                //tipIzmeni ti = new tipIzmeni(tip);
                //ti.Show();
                TipFrame.Content = new tipIzmeni(tip);

            }
            else
            {
                MessageBox.Show("Selektujte tip koji zelite da izmenite.");
            }
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Tip tip = listaT.SelectedItem as Tip;
            if (tip != null)
            {
                listaTipova.Remove(tip);
                
            }
            else
                MessageBox.Show("Selektujte tip koji zelite da obrisete.");
        }

        private void ListaT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
