using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Entities.Models
{
    public class Prica
    {
        [Key]
        public int IdPrica { get; set; }
        public int IdKorisnik { get; set; }
        public int? RoditeljIdPrica { get; set; }
        public int IdStatus { get; set; }
        public string Sadrzaj { get; set; }
        public string UrlSlike { get; set; }
        public DateTime VrijemeObjave { get; set; }
        public Status Status { get; set; }
        public Korisnik Korisnik { get; set; }
        public Prica Roditelj { get; set; }
        public List<Prica> Djeca { get; set; }
    }
}
