using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PasswordManager.Entities
{
    public class DecryptedPasswordData
    {
        public int Id { get; set; }

        [Required]
        public string App { get; set; } = string.Empty;
        
        [Required]
        public string Category { get; set; } = string.Empty;
        
        [Required]
        [JsonPropertyName("userName")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("decryptedPassword")]
        public string DecryptedPassword { get; set; } = string.Empty;
    
    }
}