using System.ComponentModel.DataAnnotations;

namespace PerfumeApiBackend.Models.DataModels
{
    public class Volume : BaseEntity
    {
        [Required]
        public TypeVolume? Type { get; set; }

        public ICollection<Perfume> Perfumes{ get; set;}
    }
}
