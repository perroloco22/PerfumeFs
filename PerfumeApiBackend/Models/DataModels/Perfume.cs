using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfumeApiBackend.Models.DataModels
{
    

    public class Perfume : BaseEntity
    {
        
        [Required, StringLength(50)]
        public string? Name{ get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string? Description { get; set; } = string.Empty;

        [Required]
        public int? Cost { get; set; }
        
        [Required, StringLength(50)]
        public string IdBrand { get; set; } = string.Empty;

        [Required]
        public int? IdVolume { get; set; }

        [Required]
        public int? IdGender { get; set; }

        [Required]
        public int? IdConcentration { get; set; }
                
        [Required]
        public Brand Brand { get; set; } = new Brand();

        [Required]
        public Volume Volume { get; set; } = new Volume();

        [Required]
        public Gender Gender { get; set; } = new Gender();

        [Required]
        public Concentration Concentration { get; set; } = new Concentration();

        [Required]
        public Stock Stock { get; set; } = new Stock();

        //[ForeignKey("IdPerfumery")]
        //[InverseProperty("Perfumes")]
        //public virtual Perfumery Perfumery { get; set; }

    }
}
