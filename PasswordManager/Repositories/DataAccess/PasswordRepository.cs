
using Microsoft.EntityFrameworkCore;
using PasswordManager.Entities;

namespace PasswordManager.Repositories.DataAccess
{
    public class PasswordRepository(PasswordManagerDbContext dbContext) : IPasswordRepository
    {
        private readonly PasswordManagerDbContext _dbContext = dbContext;

        public void Add(PasswordData data)
        {
            _dbContext.Passwords.Add(data);
            _dbContext.SaveChanges();
        }

        public void Delete(PasswordData data)
        {
            _dbContext.Remove(data);
            _dbContext.SaveChanges();
        }

        public PasswordData? GetPasswordDataById(int id)
        {
            return _dbContext.Passwords.FirstOrDefault(passwordData => passwordData.Id == id);
        }

        public void Update(PasswordData data)
        {
            _dbContext.Update(data);
            _dbContext.SaveChanges();
        }

        public List<PasswordData> GetAllPasswords(){
            return [.. _dbContext.Passwords];
        }
    }
}