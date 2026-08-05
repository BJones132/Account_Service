using Account_Service.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Account_Service.Data
{
    public class AccountDb : DbContext
    {
        public AccountDb(DbContextOptions<AccountDb> options) :
            base(options) { }

        public DbSet<Account> Accounts => Set<Account>();
    }
}
