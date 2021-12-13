using System;
using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Entities.Models
{
    public class Narudzba
    {
        [Key]
        public int IdNarudzba { get; set; }
        public int? IdPonuda { get; set; }
        public int? IdPosebnaPonuda { get; set; }
        public int IdStatus { get; set; }
        public int IdKorisnik { get; set; }
        public decimal KonacnaCijena { get; set; }
        public DateTime Datum { get; set; }
        public string ImePrimatelja { get; set; }
        public string PrezimePrimatelja { get; set; }
        public string AdresaPrimatelja { get; set; }
        public Ponuda Ponuda { get; set; }
        public PosebnaPonuda PosebnaPonuda { get; set; }
        public Status Status { get; set; }
        public Transakcija Tansakcija { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
