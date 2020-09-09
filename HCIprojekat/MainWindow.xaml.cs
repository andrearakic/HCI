using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.IO;

namespace HCIprojekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataIO serializerE = new DataIO();
        private DataIO serializerT = new DataIO();
        private DataIO serializerS = new DataIO();
        private DataIO serializerI = new DataIO();

        public Point start;
        private bool promena = false;

        public static ObservableCollection<Ikonica> mapaIkonica = new ObservableCollection<Ikonica>();
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Tipovi.listaTipova = serializerT.DeSerializeObject<ObservableCollection<Tip>>("tipovi.xml");
            if (Tipovi.listaTipova == null)
            {
                Tipovi.listaTipova = new ObservableCollection<Tip>();
            }

            Etikete.listaEtiketa = serializerE.DeSerializeObject<ObservableCollection<Etiketa>>("etikete.xml");
            if (Etikete.listaEtiketa == null)
            {
                Etikete.listaEtiketa = new ObservableCollection<Etiketa>();
            }

            Dogadjaji.listaDogadjaja = serializerS.DeSerializeObject<ObservableCollection<Dogadjaj>>("dogadjaji.xml");
            if (Dogadjaji.listaDogadjaja == null)
            {
                Dogadjaji.listaDogadjaja = new ObservableCollection<Dogadjaj>();
            }

            mapaIkonica = serializerI.DeSerializeObject<ObservableCollection<Ikonica>>("ikonice.xml");
            if (mapaIkonica == null)
            {
                mapaIkonica = new ObservableCollection<Ikonica>();
            }

            DataContext = this;



            InitializeComponent();



            stablo.ItemsSource = Tipovi.listaTipova;

            refreshStablo();

            if (mapaIkonica.Count != 0)
            {
                foreach (Ikonica ik in mapaIkonica)
                {
                    Image Pikonica = new Image();
                    Pikonica.Height = 20;
                    Pikonica.Width = 20;
                    Pikonica.Name = ik.Do.Oznaka;
                    Pikonica.Source = new BitmapImage(new Uri(ik.Do.Ikona, UriKind.Absolute));
                    canvasMapa.Children.Add(Pikonica);
                    Pikonica.ToolTip = "Oznaka: " + ik.Do.Oznaka + "\nIme: " + ik.Do.Ime + "\nTip: " + ik.Do.Tip;



                    Canvas.SetLeft(Pikonica, ik.X);
                    Canvas.SetTop(Pikonica, ik.Y);

                }
            }

            
        }

        public void refreshStablo()
        {
            foreach (Tip t in Tipovi.listaTipova)
            {
                t.DogadjajiTipa.Clear();
                foreach (Dogadjaj d in Dogadjaji.listaDogadjaja)
                {
                    if (d.Tip.Equals(t.Oznaka))
                    {
                        t.DogadjajiTipa.Add(d);
                        foreach (Ikonica mi in mapaIkonica)
                        {
                            if (mi.Do.Oznaka.Equals(d.Oznaka))
                            {
                                t.DogadjajiTipa.Remove(d);
                            }
                        }
                    }
                }
            }


        }
            public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
            serializerT.SerializeObject<ObservableCollection<Tip>>(Tipovi.listaTipova, "tipovi.xml");
            serializerE.SerializeObject<ObservableCollection<Etiketa>>(Etikete.listaEtiketa, "etikete.xml");
            serializerS.SerializeObject<ObservableCollection<Dogadjaj>>(Dogadjaji.listaDogadjaja, "dogadjaj.xml");
            serializerI.SerializeObject<ObservableCollection<Ikonica>>(mapaIkonica, "ikonice.xml");

            }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Click_D(object sender, RoutedEventArgs e)
        {
            Dogadjaji d = new Dogadjaji();
            d.Show();
        }

        private void Click_E(object sender, RoutedEventArgs e)
        {
            Etikete et = new Etikete();
            et.Show();
        }

        private void Click_T(object sender, RoutedEventArgs e)
        {
            Tipovi t = new Tipovi();
            t.Show();
        }


        private void Stablo_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(null);
            promena = false;
        }

        private void Stablo_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = start - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                TreeView treeview = sender as TreeView;
                TreeViewItem treeViewItem = FindAncestor<TreeViewItem>((DependencyObject)e.OriginalSource);

                if (treeview.SelectedItem is Dogadjaj)
                {

                    Dogadjaj d = (Dogadjaj)treeview.SelectedItem;

                    if (treeViewItem != null && d != null)        //inicijalizacija drag n dropa
                    {
                        DataObject dragData = new DataObject("myFormat", d);
                        DragDrop.DoDragDrop(treeViewItem, dragData, DragDropEffects.Move);
                    }
                }
            }
        }
        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void canvasMapa_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Dogadjaj sp = e.Data.GetData("myFormat") as Dogadjaj;

                foreach (Tip t in Tipovi.listaTipova)
                {
                    foreach (Dogadjaj dog in t.DogadjajiTipa)
                    {
                        if (dog.Equals(sp))
                        {
                            t.DogadjajiTipa.Remove(dog);
                            break;
                        }
                    }
                }

                Image ikonica = new Image();
                ikonica.Height = 20;
                ikonica.Width = 20;
                ikonica.Name = sp.Oznaka;
                ImageSourceConverter imgConv = new ImageSourceConverter();
                string path = sp.Ikona;
                ImageSource imageSource = (ImageSource)imgConv.ConvertFromString(path);
                ikonica.Source = imageSource;
                ikonica.ToolTip = "Oznaka: " + sp.Oznaka + "\nIme: " + sp.Ime + "\nTip: " + sp.Tip;
                if (!promena)
                {
                    this.canvasMapa.Children.Add(ikonica);

                    Point p = e.GetPosition(this.canvasMapa);

                    Ikonica saCanvasa = new Ikonica(e.GetPosition(this.canvasMapa).X, e.GetPosition(this.canvasMapa).Y, sp);

                    if (CanDrop(e.GetPosition(this.canvasMapa).X, e.GetPosition(this.canvasMapa).Y, saCanvasa))
                    {
                        Canvas.SetLeft(ikonica, p.X);
                        Canvas.SetTop(ikonica, p.Y);

                        Ikonica icon = new Ikonica(p.X, p.Y, sp);
                        mapaIkonica.Add(icon);
                    }
                    else
                    {

                        foreach (Tip t in Tipovi.listaTipova)
                        {

                            if (t.Oznaka.Equals(sp.Tip))
                            {
                                t.DogadjajiTipa.Add(sp);
                            }
                        }

                        this.canvasMapa.Children.Remove(ikonica);
                        MessageBox.Show("Izaberite drugu lokaciju.");
                    }
                }
                else
                {
                    Point p = e.GetPosition(this.canvasMapa);
                    for (int i = 0; i < mapaIkonica.Count; i++)
                    {
                        if (mapaIkonica[i].Do.Oznaka.Equals(sp.Oznaka))
                        {

                            Ikonica saCanvasa = mapaIkonica[i];
                            canvasMapa.Children.RemoveAt(i);
                            canvasMapa.Children.Insert(i, ikonica);

                            int flagg = 0;
                            if (!CanDrop(e.GetPosition(this.canvasMapa).X, e.GetPosition(this.canvasMapa).Y, saCanvasa))
                            {
                                p.X = saCanvasa.X;
                                p.Y = saCanvasa.Y;
                                flagg = 1;

                            }

                            Canvas.SetLeft(ikonica, p.X);
                            Canvas.SetTop(ikonica, p.Y);

                            mapaIkonica[i].X = p.X;
                            mapaIkonica[i].Y = p.Y;


                            if (flagg == 1)
                            {
                                MessageBox.Show("Izaberite drugu lokaciju.");
                            }

                            break;
                        }
                    }
                }
            }

        }

        private void canvasMapa_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(this.canvasMapa);
            promena = true;

            int i = 0;

            Dogadjaj pomS = razdaljina(start);

            if (pomS != null)
            {
                for (i = 0; i < mapaIkonica.Count; i++)
                {
                    Image img = (Image)canvasMapa.Children[i];
                    canvasMapa.Children.RemoveAt(i);
                    canvasMapa.Children.Insert(i, img);
                    if (pomS.Equals(mapaIkonica[i].Do))
                    {
                        canvasMapa.Children.RemoveAt(i);
                        canvasMapa.Children.Insert(i, img);
                        break;
                    }
                }
            }
        }

        private void canvasMapa_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(this.canvasMapa);
            Dogadjaj d = razdaljina(start);


            if (d != null)
            {
                if (System.Windows.Forms.MessageBox.Show("Potvrdom ce se odabrani dogadjaj ukloniti sa mape. ", "potvrda", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
                {
                    for (int i = 0; i < mapaIkonica.Count; i++)
                    {
                        if (mapaIkonica[i].Do.Equals(d))
                        {

                            Ikonica tempS = mapaIkonica[i];
                            canvasMapa.Children.RemoveAt(i);

                            foreach (Tip t in Tipovi.listaTipova)  //vrati ga u stablo
                            {
                                if (t.Oznaka.Equals(d.Tip))
                                {
                                    t.DogadjajiTipa.Add(d);
                                }
                            }

                            mapaIkonica.RemoveAt(i);
                            break;
                        }
                    }
                }
            }

        }

        private bool CanDrop(double x, double y, Ikonica ikonica)
        {

            foreach (Ikonica ic in mapaIkonica)
            {
                if (ic != ikonica)
                {
                    if (Math.Abs(ic.X - x) < 15 && Math.Abs(ic.Y - y) < 20)
                    {

                        return false;
                    }
                }
            }

            return true;
        }

        public Dogadjaj razdaljina(Point p)
        {
            foreach (Ikonica icon in mapaIkonica)
            {
                if ((p.X > icon.X - 1 && p.X < icon.X + 30) && (p.Y > icon.Y - 1 && p.Y < icon.Y + 30))
                {
                    return icon.Do;
                }
            }

            return null;
        }

        private void canvasMapa_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(canvasMapa);
            Vector diff = start - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Dogadjaj d = razdaljina(start);

                if (d != null)
                {
                    DataObject dragData = new DataObject("myFormat", d);
                    DragDrop.DoDragDrop((DependencyObject)e.OriginalSource, dragData, DragDropEffects.Move);
                }
            }

        }

        private void TextPretrage_TextChanged(object sender, TextChangedEventArgs e)
        {

            
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }


        

        private void MenuItem_Style_Click(object sender, RoutedEventArgs e)
        {
            // Uncheck each item
            foreach (MenuItem item in menuItemLanguages.Items)
            {
                item.IsChecked = false;
            }

            MenuItem mi = sender as MenuItem;
            mi.IsChecked = true;
            App.Instance.SwitchLanguage(mi.Tag.ToString());
        }

        
        private void MenuItem_StyleClick(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            string stylefile = Path.Combine(App.Directory, "Styles", mi.Name + ".xaml");
            App.Instance.LoadStyleDictionaryFromFile(stylefile);
        }
    }
}
