using System;
using System.Collections.Generic;

namespace CtrlAltElite.BL.Models
{
    public class PricaVM
    {
        public string Sadrzaj { get; set; }
        public string UrlSlike { get; set; }
        public int IdPrice { get; set; }
        public string IdKorisnika { get; set; }
        public string ImeKorisnika { get; set; }
        public DateTime VrijemeObjave { get; set; }
        public List<PricaVM> Komentari { get; set; }
    }
}
