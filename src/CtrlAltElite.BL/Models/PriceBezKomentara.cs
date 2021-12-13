using System;
using System.Collections.Generic;
using System.Text;

namespace CtrlAltElite.BL.Models
{
    public class PriceBezKomentara
    {
        public string Sadrzaj { get; set; }
        public string UrlSlike { get; set; }
        public int IdPrice { get; set; }
        public string IdKorisnika { get; set; }
        public string ImeKorisnika { get; set; }
        public DateTime VrijemeObjave { get; set; }
        public int BrojKomentara { get; set; }
    }
}
