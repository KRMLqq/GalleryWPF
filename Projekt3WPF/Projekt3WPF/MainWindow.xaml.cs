using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt3WPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Galeria galeria;
        public ObservableCollection<Podkategoria> pd1;
        private int counter = 0;
        private int strona = 1;
        public MainWindow()
        {
            InitializeComponent();
            galeria = new Galeria();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;

            galeria.utworzGalerie(menuItem.Header.ToString());
            wyswietlGalerie();
        }

        private Podkategoria zwrocPodkategorie(string name)
        {
            Podkategoria pd = new Podkategoria();
            foreach(Podkategoria p in pd1)
            {
                if(p.nazwa == name)
                {
                    pd = p;
                }
            }
            return pd;
        }

        


        private void wyswietlGalerie()
        {
            counter = galeria.podkategorie.Count;
            pd1 = new ObservableCollection<Podkategoria>();
            grid.Children.Clear();
            grid.Children.Add(back);
            grid.Children.Add(next);
            for (int i = (strona - 1) * 3; i < strona * 3; i++)
            {
                if (i < counter)
                {
                    pd1.Add(galeria.podkategorie[i]);
                }
            }
            for(int i = 0; i < pd1.Count; i++)
            {
                StackPanel stack = new StackPanel();
                stack.Name = pd1[i].nazwa;
                stack.MouseLeftButtonDown += (object sender, MouseButtonEventArgs e) =>
                {

                    Podkategoria podkategoria = zwrocPodkategorie(stack.Name);

                    Window1 window = new Window1(podkategoria);
                    window.ShowDialog();
                    
                };

                Label lb = new Label
                {
                    Content = pd1[i].nazwa,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };

                Image img = new Image
                {
                    Source = new BitmapImage(new Uri(pd1[i].url)),
                    Width = 250,
                    Height = 250
                };
                stack.Children.Add(lb);
                stack.Children.Add(img);

                grid.Children.Add(stack);
                
                switch (i)
                {
                    case 0:
                    {
                            Grid.SetColumn(stack, 0);
                            Grid.SetRow(stack, 0);
                            break;    
                    }
                    case 1:
                    {
                            Grid.SetColumn(stack, 1);
                            Grid.SetRow(stack, 0);
                            break;
                    }
                    case 2:
                    {
                            Grid.SetColumn(stack, 0);
                            Grid.SetRow(stack, 1);
                            break;
                    }
                    case 3:
                    {
                            Grid.SetColumn(stack, 1);
                            Grid.SetRow(stack, 1);
                            break;
                    }
                }
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (strona - 1 >= 1)
            {
                strona--;
            }
            wyswietlGalerie();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (galeria.podkategorie.Count > strona * 3)
            {
                strona++;
            }

            wyswietlGalerie();
        }
    }
}
