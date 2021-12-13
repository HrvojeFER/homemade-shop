using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Entities.Models
{
    public class StilSalveta
    {
        [Key]
        public int IdSalveta { get; set; }
        public string NazivSalveta { get; set; }
        public string Opis { get; set; }
        public double FaktorMnozenja { get; set; }
        public List<Ponuda> Ponude { get; set; }
    }
}
