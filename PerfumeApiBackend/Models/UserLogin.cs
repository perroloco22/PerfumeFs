﻿using System.ComponentModel.DataAnnotations;

namespace PerfumeApiBackend.Models
{
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
