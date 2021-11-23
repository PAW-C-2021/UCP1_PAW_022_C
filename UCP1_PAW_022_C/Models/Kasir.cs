using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_022_C.Models
{
    public partial class Kasir
    {
        public Kasir()
        {
            Transaksiis = new HashSet<Transaksii>();
        }

        public int IdKasir { get; set; }
        public string NamaKasir { get; set; }

        public virtual ICollection<Transaksii> Transaksiis { get; set; }
    }
}
