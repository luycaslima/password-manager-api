using System.Text.Json.Serialization;

namespace PasswordManager.Entities
{
    public class DecryptedPasswordData
    {
         public int Id { get; set; }

        public string App { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        
        [JsonPropertyName("userName")]
        public string Username { get; set; } = string.Empty;
        
        [JsonPropertyName("decryptedPassword")]
        public string DecryptedPassword { get; set; } = string.Empty;
    
    }
}