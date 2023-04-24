using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfumeApiBackend.Models.DataModels
{
    

    public class Perfume : BaseEntity
    {
        /*
        public int ID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? DeleteBy { get; set; }
        public DateTime? DeleteAt { get; set; }
        */

        [Required, StringLength(50)]
        public string? Name{ get; set; } = string.Empty;
        [Required, StringLength(200)]
        public string? Description { get; set; } = string.Empty;
        [Required, StringLength(50)]
        public string? Notes { get; set; } = string.Empty;
        [Required, StringLength(50)]
        public string Brand { get; set; } = string.Empty;
        [Required]
        public int? Volume { get; set; }
        [Required]
        public int? Gender { get; set; }
        [Required]
        public int? Price { get; set; }

        public int? PerfumeryID { get; set; }

        [ForeignKey("PerfumeryID")]
        [InverseProperty("Perfumes")]
        public virtual Perfumery Perfumery { get; set; }

    }
}
