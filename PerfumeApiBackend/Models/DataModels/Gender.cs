using System.ComponentModel.DataAnnotations;

namespace PerfumeApiBackend.Models.DataModels
{
    public class Gender : BaseEntity
    {
        [Required]
        public string? Type { get; set; }

        [Required]
        public ICollection<Perfume> Perfumes { get; set; } = new List<Perfume>();

    }
}
