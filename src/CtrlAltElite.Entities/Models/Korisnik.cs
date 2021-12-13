using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CtrlAltElite.Entities.Models
{
    public class Korisnik
    {
        [Key]
        public int IdKorisnik { get; set; }
        public string ImeKorisnik { get; set; }
        public string PrezimeKorisnik { get; set; }
        public string UserName { get; set; }
        public string EmailKorisnik { get; set; }
        public string PwdKorisnik { get; set; }
        public string AdresaKorisnik { get; set; }
        public int IdRole { get; set; }
        public Role Rola { get; set; }
        public Vidljivost Vidljivost { get; set; }
        public List<Prica> Price { get; set; }
        public List<Narudzba> Narudzbe { get; set; }
        public Microsoft.AspNetCore.Identity.IdentityUser User { get; set; }
    }
}
