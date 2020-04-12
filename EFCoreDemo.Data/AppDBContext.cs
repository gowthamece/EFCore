using EFCoreDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Data
{
    public class AppDBContext: DbContext
    {
            public DbSet<User> Users { get; set; } // The user class is from Domain project
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=[Provide user SQL server Name]; Initial Catalog = EFCoreDemoDB; Integrated Security=SSPI"); // 
        }

    }
}
