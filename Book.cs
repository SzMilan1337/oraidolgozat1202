using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace oraidolgozat1202
{
    internal class Book
    {
            
        Random rnd = new Random();

        private long ISBN;
        private List<Author> szerzok;
        private string cim;
        private int kiadas;
        private string nyelv;
        private int keszlet;
        private int ar;

        public Book(long ISBN, List<Author> szerzok, string cim, int kiadas, string nyelv, int keszlet, int ar)
        {

            if (ISBN.ToString().Length != 10)
                throw new ArgumentException("ISBN egy 10 jegyű számsorozat");
            if (szerzok.Count < 1 || szerzok.Count > 3)
                throw new ArgumentException("A szerzők listájának 1 és 3 között kell lennie");
            if (cim.Length < 3 || cim.Length > 64)
                throw new ArgumentException("A cím hosszának 3 és 64 karakter között kell lennie");
            if (kiadas < 2007 || kiadas > DateTime.Now.Year)
                throw new ArgumentException("A kiadási év nev lehet kissebb mint 2007 és nagyobb mint 2024");
            if (nyelv != "angol" && nyelv != "német" && nyelv != "magyar")
                throw new ArgumentException("Csak angol, magyar vagy német lehet a nyelv");
            if (keszlet < 0)
                throw new ArgumentException("A készlet nem lehet negatív szám");
            if (ar < 1000 || ar > 10000 || ar % 100 != 0)
                throw new ArgumentException("Az ár 1000 és 10000 közötti, kerek 100as szám");


            this.ISBN = ISBN;
            this.szerzok = szerzok;
            this.cim = cim;
            this.kiadas = kiadas;
            this.nyelv = nyelv;
            this.keszlet = keszlet;
            this.ar = ar;
        }
        public Book(string szerzo, string cim)
        {
            ISBN = rnd.Next(1000000, 9999999) * 100;
            this.cim = cim;
            this.szerzok = new List<Author>() { new Author(szerzo) };
            this.kiadas = 2024;
            this.nyelv = "magyar";
            this.keszlet = 0;
            this.ar = 4500;
        }

        public override string ToString()
        {
            string szerzo = "";
            foreach (var item in szerzok)
            {
                szerzo += item.getNev() + " ";
            }

            return $"Könyv ISBN száma: {this.ISBN}\n" +
                $"Címe: {this.cim}\n" +
                $"{(this.szerzok.Count > 1 ? "Szerzők: " : "Szerző: ")}{szerzo.Trim()}\n" +
                $"Kiadás éve: {this.kiadas}\n" +
                $"Nyelve: {this.nyelv}\n" +
                $"Készleten: {(this.keszlet > 0 ? $"{this.keszlet}db" : "beszerzés alatt")} \n" +
                $"Ára: {this.ar}";
        }
    }
}
