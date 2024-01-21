using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Entities
{
    public class TaskDbContext : DbContext
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
                    Date = new DateTime(2024,1,21),
                    IsDone = false,
                },
                new Task()
                {
                    Id = 2,
                    Name = "Pouczyć się",
                    Description = "Napisać jakiś kawałek kodu na studia",
                    Date = new DateTime(2024,2,12),
                    IsDone = true,
                }
                );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
