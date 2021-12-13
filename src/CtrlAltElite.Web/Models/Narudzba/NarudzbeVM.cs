using System.Collections.Generic;

namespace CtrlAltElite.Web.Models.Narudzba
{
    public class NarudzbeVM
    {
        public List<BL.Models.NarudzbaVM> Narudzbe { get; set; }
        public bool IsRegisterd { get; set; }
        public bool IsAdmin { get; set; }
    }
}
