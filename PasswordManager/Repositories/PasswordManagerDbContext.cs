using Microsoft.EntityFrameworkCore;
using PasswordManager.Entities;

namespace PasswordManager.Repositories
{
    public class PasswordManagerDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<PasswordData> Passwords {get; set;}
    }
}