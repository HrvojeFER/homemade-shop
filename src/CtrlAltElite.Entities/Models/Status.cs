using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Entities.Models
{
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }
        public string Vrijednost { get; set; }
        public List<Narudzba> Narudzbe { get; set; }
        public List<Prica> Price { get; set; }
    }
}
