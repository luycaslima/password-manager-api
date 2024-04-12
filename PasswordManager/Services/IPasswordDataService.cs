
using PasswordManager.Dto.Password;
using PasswordManager.Entities;

namespace PasswordManager.Services
{
    public interface IPasswordDataService
    {
        int AddPassword(RequestAddPasswordDataDTO request);

        List<PasswordData> GetListOfAllPasswords();
        PasswordData? GetEncryptedPasswordData(int id);
        PasswordData? UpdatePasswordData(int id ,RequestAddPasswordDataDTO request);
        bool DeletePasswordDataEntry(int id);
        DecryptedPasswordData? GetDecryptedPasswordData(int id);
    }
}