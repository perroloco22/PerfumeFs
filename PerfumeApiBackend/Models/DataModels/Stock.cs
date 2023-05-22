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
        public Perfume Perfume { get; set; } 

        [Required]
        public Perfumery Perfumery { get; set;}
    }
}
