using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Student> students { get; set; }  //DbSet = Table

        public DbSet<StudentProfile> studentProfiles { get; set; }

        public DbSet<Courses> courses { get; set; } 
    }
}
