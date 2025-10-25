using System.ComponentModel.DataAnnotations;

namespace MedicalCareApi.Models
{
    public class User
    {
        // This will be the Primary Key in the database
        public int Id { get; set; }

        // Mapped to a column for the username
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        // Store the hashed password (NEVER plain text!)
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = "Patient";
        public DateTime CreatedAt { get; set; }
    }
}
