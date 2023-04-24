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
        /*
        public int ID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? DeleteBy { get; set; }
        public DateTime? DeleteAt { get; set; }
        */

        [Required, StringLength(50)]
        public string? Name { get; set; } = string.Empty;
        
        [Required, StringLength(50)]
        public string? Address { get; set; } = string.Empty;
     
        public int PerfumeID { get; set; }

        [InverseProperty(nameof(Perfume.Perfumery))]
        public virtual ICollection<Perfume> Perfumes { get; set; }

        
    }
}
