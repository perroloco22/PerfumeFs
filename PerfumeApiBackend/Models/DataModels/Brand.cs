using System.ComponentModel.DataAnnotations;

namespace PerfumeApiBackend.Models.DataModels
{
    public class Brand : BaseEntity
    {
        public string? Name { get; set; }

        [Required]
        public ICollection<Perfume> Perfumes { get; set; } = new List<Perfume>();
    }
}
