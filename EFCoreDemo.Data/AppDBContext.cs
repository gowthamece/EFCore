using EFCoreDemo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreDemo.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; } // The User class is from Domain project
        public DbSet<Skill> Skills { get; set; }// The Skill class is from Domain project
        public DbSet<Rating> Ratings { get; set; }// The Rating class is from Domain project
        public DbSet<UserSkill> UserSkills { get; set; } //Joining Entity 

        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
            .AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information)
             .AddConsole();
        }); 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFactory)
                .UseSqlServer("Data Source=[Provide user SQL server Name]; Initial Catalog = EFCoreDemoDB; Integrated Security=SSPI"); // 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<UserSkill>().HasKey(s => new { s.SkillId, s.UserId });
        }

    }
}
