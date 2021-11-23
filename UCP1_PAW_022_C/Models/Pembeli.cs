using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_022_C.Models
{
    public partial class Pembeli
    {
        public Pembeli()
        {
            Transaksiis = new HashSet<Transaksii>();
        }

        public int IdPembeli { get; set; }
        public string NamaPembeli { get; set; }
        public int? IdTransaksi { get; set; }

        public virtual ICollection<Transaksii> Transaksiis { get; set; }
    }
}
