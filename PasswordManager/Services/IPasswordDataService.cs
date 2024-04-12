
using PasswordManager.Dto.Password;
using PasswordManager.Entities;

namespace PasswordManager.Services
{
    public interface IPasswordDataService
    {
        int AddPassword(RequestAddPasswordDataDTO request);

        List<PasswordData> GetListOfAllPasswords();
        PasswordData? GetEncryptedPasswordData(int id);
        DecryptedPasswordData? GetDecryptedPasswordData(int id);
    }
}