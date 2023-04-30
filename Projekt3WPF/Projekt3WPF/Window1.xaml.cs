using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Projekt3WPF
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Podkategoria p;
        public ObservableCollection<Zdjecie> zdjecia;
        public int strona = 0;
        public Window1()
        {
            InitializeComponent();
        }
        
        public Window1(Podkategoria p1)
        {
            InitializeComponent();
            p = p1;
            uzupelnijKolekcjeZdjec();
            wczytaj();
        }

        public void uzupelnijKolekcjeZdjec()
        {
            zdjecia = new ObservableCollection<Zdjecie>();
            var dir2 = Directory.GetFiles(p.dirUrl);
            List<string> dir_photo = new List<string>();
            foreach (var dir3 in dir2)
            {
                if (System.IO.Path.GetExtension(dir3) == ".txt")
                    continue;
                else
                    dir_photo.Add(dir3);
            }

            foreach (var dir4 in dir_photo)
            {
                var zdjname = System.IO.Path.GetFileNameWithoutExtension(dir4);
                var opis_path = p.dirUrl + "\\" + zdjname + ".txt";
                var opis_tekst = File.ReadAllText(opis_path);
                Zdjecie zdjecie = new Zdjecie { nazwa = zdjname, opis = opis_tekst, url = dir4 };
                zdjecia.Add(zdjecie);
            }
        }

        public void wczytaj()
        {
            tytul.Content = zdjecia[strona].nazwa;
            zdj.Source = new BitmapImage(new Uri(zdjecia[strona].url));
            opis.Text = zdjecia[strona].nazwa;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (strona == 0)
                strona = zdjecia.Count - 1;
            else
                strona--;
            wczytaj();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (strona == zdjecia.Count-1)
                strona = 0;
            else
                strona++;
            wczytaj();
        }
    }
}
