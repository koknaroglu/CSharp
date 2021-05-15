using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BKAracKiralama.Models
{
    public class Müsteri
    {
        public int ID { get; set; }
        public string TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string eMail { get; set; }
        public string Adres { get; set; }

        public ICollection<Kiralama> Kiralamalar { get; set; }
    }
}