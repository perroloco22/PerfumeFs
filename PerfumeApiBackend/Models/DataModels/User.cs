using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfumeApiBackend.Models.DataModels
{
       public class User : BaseEntity
    {
        [Required, StringLength(50)]
        public string? Name { get; set; }

        [Required, StringLength(50)]
        public string? LastName { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public int? UserCategoryID { get; set; }

        [Required]
        //[ForeignKey("UserCategoryID")]
        public virtual UserCategory UserCategory { get; set; } = new UserCategory();
        
    }
}
