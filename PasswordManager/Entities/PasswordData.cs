using System.Text.Json.Serialization;

namespace PasswordManager.Entities
{
    public class PasswordData
    {
        public int Id { get; set; }

        public string App { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        
        [JsonPropertyName("userName")]
        public string Username { get; set; } = string.Empty;
        
        [JsonPropertyName("encryptedPassword")]
        public string EncryptedPassword { get; set; } = string.Empty;
    }
}