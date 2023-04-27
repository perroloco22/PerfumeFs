using System.ComponentModel.DataAnnotations;

namespace PerfumeApiBackend.Models.DataModels
{
    public class Stock : BaseEntity
    {
        [Required]
        public int Amount { get; set; }

        [Required]
        public int IdPerfume { get; set; }
        
        [Required]
        public int IdPerfumery { get; set; }
        
        [Required]
        public ICollection<Perfume> Perfumes { get; set; } = new List<Perfume>();

        [Required]
        public ICollection<Perfumery> Perfumerys { get; set;} = new List<Perfumery>();
    }
}
