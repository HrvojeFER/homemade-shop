using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Entities.Models
{
    public class Ponuda
    {
        [Key]
        public int IdPonuda { get; set; }
        public int IdPredmet { get; set; }
        public int IdStil { get; set; }
        public int IdSalveta { get; set; }
        public decimal Cijena { get; set; }
        public Predmet Predmet { get; set; }
        public StilUkrasavanja Stil { get; set; }
        public StilSalveta Salveta { get; set; }
        public List<Narudzba> Narudzbe { get; set; }
    }
}
