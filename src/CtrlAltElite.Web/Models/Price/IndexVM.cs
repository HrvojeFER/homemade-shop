using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CtrlAltElite.Web.Models.Price
{
    public class IndexVM
    {
        public bool IsAdmin { get; set; }
        public bool IsRegistered { get; set; }
        public List<PricaBezKomentaraVM> Price { get; set; }
    }
}
