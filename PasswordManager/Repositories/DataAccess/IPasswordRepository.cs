using PasswordManager.Entities;

namespace PasswordManager.Repositories.DataAccess
{
    public interface IPasswordRepository
    {
        PasswordData? GetPasswordDataById(int id);
        List<PasswordData> GetAllPasswords();
        void Add(PasswordData data);
        void Update(PasswordData data);
        void Delete(PasswordData data);
    }
}