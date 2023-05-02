using System.ComponentModel.DataAnnotations;

namespace PerfumeApiBackend.Models.DataModels
{
    public class UserCategory : BaseEntity
    {
        [Required]
        public string? Category  { get; set; }

        [Required]
        public  ICollection<User> Users { get; set; } = new List<User>();

    }
}
