using System;
using System.Collections.Generic;


namespace BKAracKiralama.Models
{
    public class Arac
    {
        public int ID { get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Yıl { get; set; }
        public string Renk { get; set; }
        public decimal GünlükÜcret { get; set; }
        public string Cins { get; set; }
        public ICollection<Kiralama> Kiralamalar { get; set; }

    }
}
