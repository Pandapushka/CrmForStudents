using CrmForStudents.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrmForStudents.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
