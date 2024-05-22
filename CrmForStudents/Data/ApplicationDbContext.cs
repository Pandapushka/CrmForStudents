using CrmForStudents.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrmForStudents.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .HasOne(u => u.Student)
                .WithMany(n => n.Services)
                .HasForeignKey(u => u.StudentId);

            //modelBuilder.Entity<Service>()
            //    .HasOne<Student>()
            //    .WithMany(x => x.Services)
            //    .HasForeignKey(x => x.StudentId);
        }

        
    }
}
