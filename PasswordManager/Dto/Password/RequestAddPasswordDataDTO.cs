
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Dto.Password
{
    public class RequestAddPasswordDataDTO
    {
        /// <summary>
        /// Application's name
        /// </summary>
        [Required]
        public string App { get; set; } = string.Empty;
        
        /// <summary>
        /// Which category this app is. 
        /// Ex: Games, Finances.
        /// </summary>
        [Required]
        public string Category { get; set; } = string.Empty;
        
        /// <summary>
        /// Username or Email of the Password
        /// </summary>
        [Required]
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// The password before being encrypted to add to the database
        /// </summary>
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}