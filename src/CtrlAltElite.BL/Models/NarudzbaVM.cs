using System;

namespace CtrlAltElite.BL.Models
{
    public class NarudzbaVM 
    {
        public int IdNarudzba { get; set; }
        public bool IsSpecial { get; set; }

        public string Opis { get; set; }
        public string URLSlike { get; set; }

        public string ImePrimatelja { get; set; }
        public string PrezimePrimatelja { get; set; }
        public string AdresaPrimatelja { get; set; }

        public string Status { get; set; }
        public decimal KonacnaCijena { get; set; }
        public DateTime Datum { get; set; }
    }
}
