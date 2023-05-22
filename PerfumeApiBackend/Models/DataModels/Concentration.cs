using System.ComponentModel.DataAnnotations;

namespace PerfumeApiBackend.Models.DataModels
{
    public class Concentration : BaseEntity
    {
        [Required]
        public TypeConcentration Type { get; set; }

        public ICollection<Perfume> Perfumes { get; set; }
                
    }
}
