using Microsoft.EntityFrameworkCore;
using SaphyreStudentDirectory.Domain.Models;

namespace SaphyreStudentDirectory.DAL.Repositories
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
