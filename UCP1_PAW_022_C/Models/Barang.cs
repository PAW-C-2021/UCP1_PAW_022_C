using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_022_C.Models
{
    public partial class Barang
    {
        public Barang()
        {
            Transaksiis = new HashSet<Transaksii>();
        }

        public int IdBarang { get; set; }
        public string NamaBarang { get; set; }
        public string HargaBarang { get; set; }
        public string JumlahBarang { get; set; }

        public virtual ICollection<Transaksii> Transaksiis { get; set; }
    }
}
