namespace CtrlAltElite.BL
{
    //Interface for mapping database objects to models.
    public interface IMapper
    {
        Models.KorisnikVM ToKorsnikVM(Entities.Models.Korisnik korisnik);
        Models.NarudzbaVM ToNarudzbaVM(Entities.Models.Narudzba narudzba);
        Models.TransakcijaVM ToTransakcijaVM(Entities.Models.Transakcija transakcija);
    }
}
