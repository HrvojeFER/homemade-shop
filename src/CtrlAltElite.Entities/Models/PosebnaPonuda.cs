using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Entities.Models
{
    public class PosebnaPonuda
    {
        [Key]
        public int IdPosebnaPonuda { get; set; }
        public int IdNarudzba { get; set; }
        public string Opis { get; set; }
        public Narudzba Narudzba { get; set; }
    }
}
