using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.BL.Models
{
    public enum RoleModel
    {
        [Display(Name = "Banani korisnik")]
        BananiKorisnik = 1,
        [Display(Name = "Registrirani korisnik")]
        RegistriraniKorisnik = 2,
        Admin = 3
    }
}
