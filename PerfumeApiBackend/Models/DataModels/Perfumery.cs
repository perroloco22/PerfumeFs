using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfumeApiBackend.Models.DataModels
{
    public class Perfumery : BaseEntity
    {
        public Perfumery()
        {
            Perfumes = new HashSet<Perfume>();
        }

        [Required, StringLength(50)]
        public string? Name { get; set; } = string.Empty;
        
        [Required, StringLength(50)]
        public string? Address { get; set; } = string.Empty;
     
        public int PerfumeID { get; set; }

        [InverseProperty(nameof(Perfume.Perfumery))]
        public virtual ICollection<Perfume> Perfumes { get; set; }

        
    }
}
