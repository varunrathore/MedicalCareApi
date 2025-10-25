﻿using System.ComponentModel.DataAnnotations;

namespace MedicalCareApi.Models
{
    public class RegisterRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string Role { get; set; } = "User";
    }
}
