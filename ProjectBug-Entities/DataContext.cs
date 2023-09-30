using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Data;
using System.Reflection;
using System.Security;
using ProjectBug_Entities.Seeders;

namespace ProjectBug_Entities
{
    public class DataContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Bug> Bugs { get; set; }

        private DataContext()
        {
        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var keys = builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in keys)
            {
                if (relationship.DeleteBehavior == DeleteBehavior.Cascade)
                {
                    relationship.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }

        public void FixDatabase()
        {
            if (Database.GetPendingMigrations().Any())
            {
                var pendingMigrations = Database.GetPendingMigrations();
                foreach (var migration in pendingMigrations)
                {
                    Console.WriteLine($"Pending Migration: {migration}");
                }

                try
                {
                    Database.Migrate();
                    Console.WriteLine($"Migrations are completed.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error running migrations");
                    Console.WriteLine(ex.Message, ex);
                }
            }
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            this.SeedUser();
            this.SeedProject();
        }        
    }
}