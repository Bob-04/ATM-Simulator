using KMA.MOOP.ATM.DBModels;
using Microsoft.EntityFrameworkCore;

namespace KMA.MOOP.ATM.EntityFrameworkWrapper
{
    public sealed class DatabaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Account { get; set; }

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;UserId=root;Password=8746alexfry;database=bank_schema;");
        }

        // To set indexes.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasIndex(cl => cl.IdentificationCode).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(cl => cl.Phone).IsUnique();
            modelBuilder.Entity<Account>().HasIndex(ac => ac.Number).IsUnique();
        }
    }
}
