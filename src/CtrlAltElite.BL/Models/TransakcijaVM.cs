using System;

namespace CtrlAltElite.BL.Models
{
    public class TransakcijaVM
    {
        public string ImeKupca { get; set; }
        public string PrezimeKupca { get; set; }
        public string AdresaKupca { get; set; }
        public decimal Cijena { get; set; }
        public DateTime Datum { get; set; }
    }
}
