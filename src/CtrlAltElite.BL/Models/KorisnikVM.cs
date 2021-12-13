namespace CtrlAltElite.BL.Models
{
    public class KorisnikVM
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public RoleModel Rola { get; set; }
    }
}
