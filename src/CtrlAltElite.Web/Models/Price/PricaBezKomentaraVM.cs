using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CtrlAltElite.Web.Models.Price
{
    public class PricaBezKomentaraVM
    {
        public string ImeKorisnika { get; set; }
        public string IdKoriknika { get; set; }
        public int IdPrice { get; set; }
        public string UserName { get; set; }
        public string Sadrzaj { get; set; }
        public string Vrijeme { get; set; }
        public string UrlSlike { get; set; }
        public bool IsAdmin { get; set; }
        public int BrojKomentara { get; set; }
    }
}
