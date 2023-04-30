using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt3WPF
{
    public class Obiekty
    {
        public static Galeria galeria;
        
        public static void utworzGalerie(string nazwa)
        {
            string sciezka = Environment.CurrentDirectory + "\\img\\" + nazwa;
            var dir = Directory.GetDirectories(sciezka);
            ObservableCollection<Podkategoria> pd = new ObservableCollection<Podkategoria>();
            ObservableCollection<Zdjecie> zdj = new ObservableCollection<Zdjecie>();
            for(int i = 0; i<dir.Length; i++)
            {
                string name = new DirectoryInfo(dir[i]).Name;
                string path = Environment.CurrentDirectory+"\\img\\"+nazwa+"\\"+name;
                var dir2 = Directory.GetFiles(path);
                List<string> dir_photo = new List<string>();
                foreach (var dir3 in dir2)
                {
                    if (Path.GetExtension(dir3) == ".txt")
                        continue;
                    else
                        dir_photo.Add(dir3);
                }

                foreach(var dir4 in dir_photo)
                {
                    var zdjname = Path.GetFileNameWithoutExtension(dir4);
                    var opis_path = path + "\\" + zdjname + ".txt";
                    var opis_tekst = File.ReadAllText(opis_path);
                    Zdjecie zdjecie = new Zdjecie { nazwa = zdjname, opis = opis_tekst, url = dir4 };
                    zdj.Add(zdjecie);
                }

                Podkategoria podkategoria = new Podkategoria { nazwa = name, url = path+".jpg" };
                pd.Add(podkategoria);
                zdj.Clear();
            }
            galeria = new Galeria { kategoria = nazwa, podkategorie = pd };
        }

       
    }
}
