using System.Collections.Generic;

namespace CtrlAltElite.Web.Models
{
    public class PricaAdminVM
    {
        public string ImeKorisnika { get; set; }
        public string IdKoriknika { get; set; }
        public int IdPrice { get; set; }
        public string UserName { get; set; }

        public string Sadrzaj { get; set; }
        public string Vrijeme { get; set; }
        public string UrlSlike { get; set; }
        public bool MozeSeKomentirati { get; set; }
        public bool IsAdmin { get; set; }

        public List<PricaAdminVM> Komentari { get; set; }
    }
}
