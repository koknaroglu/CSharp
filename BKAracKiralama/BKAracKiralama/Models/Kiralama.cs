using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BKAracKiralama.Models
{
    public class Kiralama
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime AlışGünü { get; set; }
        public DateTime GeriTeslimGünü { get; set; }
        public int AracID { get; set; }
        public int MüsteriID { get; set; }
        

        public Arac Arac { get; set; }
        public Müsteri Müsteri { get; set; }
        
    }
}