
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Dto.Password
{
    public class RequestAddPasswordDataDTO
    {

        [Required]
        public string App { get; set; } = string.Empty;
        
        [Required]
        public string Category { get; set; } = string.Empty;
        
        [Required]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}