using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Entities.Models
{
    public class Predmet
    {
        [Key]
        public int IdPredmet { get; set; }
        public string NazivPredmet { get; set; }
        public decimal BaznaCijena { get; set; }
        public string Opis { get; set; }
        public string SlikaUrl { get; set; }
        public decimal Visina { get; set; }
        public decimal Duzina { get; set; }
        public decimal Sirina { get; set; }
        public List<Ponuda> Ponude { get; set; }
    }
}


