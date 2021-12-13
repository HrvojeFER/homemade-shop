using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Entities.Models
{
    public class Role
    {
        [Key]
        public int IdRola { get; set; }
        public string Rola { get; set; }
        public List<Korisnik> Korisnici { get; set; }
    }   
}
