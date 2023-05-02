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
        public int? BrandID { get; set; } 

        [Required]
        public int? VolumeID { get; set; }

        [Required]
        public int? GenderID { get; set; }

        [Required]
        public int? ConcentrationID { get; set; }
                
        [Required]
        public virtual Brand Brand { get; set; } = new Brand();

        [Required]
        public virtual Volume Volume { get; set; } = new Volume();

        [Required]
        public virtual Gender Gender { get; set; } = new Gender();

        [Required]
        public virtual Concentration Concentration { get; set; } = new Concentration();

        [Required]
        public virtual Stock Stock { get; set; } = new Stock();

        //[ForeignKey("IdPerfumery")]
        //[InverseProperty("Perfumes")]
        //public virtual Perfumery Perfumery { get; set; }

    }
}
