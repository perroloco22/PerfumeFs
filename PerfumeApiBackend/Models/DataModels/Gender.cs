using System.ComponentModel.DataAnnotations;

namespace PerfumeApiBackend.Models.DataModels
{
    public class Gender : BaseEntity
    {
        [Required]
        public TypeGender? Type { get; set; }

        public ICollection<Perfume> Perfumes { get; set; } 

    }
}
