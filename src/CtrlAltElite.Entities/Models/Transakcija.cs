using System;
using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Entities.Models
{
    public class Transakcija
    {
        [Key]
        public int IdTransakcija { get; set; }
        public int IdNarudzba { get; set; }
        public double KonacnaCijena { get; set; }
        public DateTime Datum { get; set; }
        public string ImeKupca { get; set; }
        public string PrezimeKupca { get; set; }
        public string AdresaKupca { get; set; }
        public Narudzba Narudzba { get; set; }

    }
}
