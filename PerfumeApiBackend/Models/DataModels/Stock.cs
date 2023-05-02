using System.ComponentModel.DataAnnotations;

namespace PerfumeApiBackend.Models.DataModels
{
    public class Stock : BaseEntity
    {
        [Required]
        public int Amount { get; set; }

        [Required]
        public int PerfumeID { get; set; }
        
        [Required]
        public int PerfumeryID { get; set; }
        
        [Required]
        public ICollection<Perfume> Perfumes { get; set; } = new List<Perfume>();

        [Required]
        public ICollection<Perfumery> Perfumerys { get; set;} = new List<Perfumery>();
    }
}
