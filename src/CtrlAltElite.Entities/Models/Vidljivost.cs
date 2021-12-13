using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Entities.Models
{
    public class Vidljivost
    {
        [Key]
        public int IdVidljivost { get; set; }
        public int IdKorisnik { get; set; }
        public bool VidljivostImeKorisnik { get; set; }
        public bool VidljivostPrezimeKorisnik { get; set; }
        public bool VidljivostEmailKorisnik { get; set; }
        public bool VidljivostAdresaKorisnik { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
