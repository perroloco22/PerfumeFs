using System.ComponentModel.DataAnnotations;

namespace PerfumeApiBackend.Models.DataModels
{
    public class Brand : BaseEntity
    {
        [Required]
        public string? Name { get; set; }

        public ICollection<Perfume> Perfumes { get; set; } 
    }
}
