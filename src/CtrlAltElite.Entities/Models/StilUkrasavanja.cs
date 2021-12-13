using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Entities.Models
{
    public class StilUkrasavanja
    {
        [Key]
        public int IdStil { get; set; }
        public string NazivStil { get; set; }
        public string Opis { get; set; }
        public float FaktorMnozenja { get; set; }
        public List<Ponuda> Ponude { get; set; }
    }
}
