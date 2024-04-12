
namespace PasswordManager.Dto.Password
{
    public class RequestAddPasswordDataDTO
    {
        public string App { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        
        public string Username { get; set; } = string.Empty;
        
        public string Password { get; set; } = string.Empty;
    }
}