using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Entities
{
    public class TaskListDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        private string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=TaskListDb;Trusted_Connection=True";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Task>()
                .HasData(new Task()
                {
                    Id = 1,
                    Name = "Zrobić pranie",
                    Description = "Trzeba coś tam zrobić",
                },
                new Task()
                {
                    Id = 2,
                    Name = "Pouczyć się",
                    Description = "Napisać jakiś kawałek kodu na studia",
                }
                );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
