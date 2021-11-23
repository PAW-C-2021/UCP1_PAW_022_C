using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_022_C.Models
{
    public partial class Transaksii
    {
        public int IdTransaksi { get; set; }
        public string JmlTransaksi { get; set; }
        public string UangBayar { get; set; }
        public string UangKembali { get; set; }
        public int? IdBarang { get; set; }
        public int? IdPembeli { get; set; }
        public int? IdKasir { get; set; }

        public virtual Barang IdBarangNavigation { get; set; }
        public virtual Kasir IdKasirNavigation { get; set; }
        public virtual Pembeli IdPembeliNavigation { get; set; }
    }
}
