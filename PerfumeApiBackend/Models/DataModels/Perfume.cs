using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfumeApiBackend.Models.DataModels
{
    

    public class Perfume : BaseEntity
    {
        
        [Required, StringLength(50)]
        public string? Name{ get; set; } = string.Empty;

        [StringLength(200)]
        public string? Description { get; set; } = string.Empty;

        public int? Cost { get; set; }
        
        public int? BrandID { get; set; } 

        public int? VolumeID { get; set; }

        public int? GenderID { get; set; }

        public int? ConcentrationID { get; set; }
                
        public Brand? Brand { get; set; } 

        public Volume? Volume { get; set; } 

        public Gender? Gender { get; set; } 

        public Concentration? Concentration { get; set; } 

        public ICollection<Stock>? Stocks { get; set; } 

        //[ForeignKey("IdPerfumery")]
        //[InverseProperty("Perfumes")]
        //public virtual Perfumery Perfumery { get; set; }

    }
}
