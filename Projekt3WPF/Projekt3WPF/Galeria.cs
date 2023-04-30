using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt3WPF
{
    public class Galeria
    {
        public string kategoria { get; set; }
        public ObservableCollection<Podkategoria> podkategorie { get; set; }
        public void utworzGalerie(string nazwa)
        {
            string sciezka = Environment.CurrentDirectory + "\\img\\" + nazwa;
            var dir = Directory.GetDirectories(sciezka);
            ObservableCollection<Podkategoria> pd = new ObservableCollection<Podkategoria>();
        
            for (int i = 0; i < dir.Length; i++)
            {
                string name = new DirectoryInfo(dir[i]).Name;
                string path = Environment.CurrentDirectory + "\\img\\" + nazwa + "\\" + name;
                
                Podkategoria podkategoria = new Podkategoria { nazwa = name, url = path + ".jpg", dirUrl = path};
                pd.Add(podkategoria);

            }
            kategoria = nazwa;
            podkategorie = pd;
            
        }

        
    }
}
