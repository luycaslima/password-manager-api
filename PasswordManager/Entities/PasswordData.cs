using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PasswordManager.Entities
{
    public class PasswordData
    {
        public int Id { get; set; }

        /// <summary>
        /// Application's name
        /// </summary>
        public string App { get; set; } = string.Empty;
        
        /// <summary>
        /// Which category this app is. 
        /// Ex: Games, Finances.
        /// </summary>
        public string Category { get; set; } = string.Empty;
            
        /// <summary>
        /// Username or Email of the Password
        /// </summary>
        [JsonPropertyName("userName")]
        public string Username { get; set; } = string.Empty;
        
        /// <summary>
        /// Encrypted Password
        /// </summary>
        [JsonPropertyName("encryptedPassword")]
        public string EncryptedPassword { get; set; } = string.Empty;
    }
}