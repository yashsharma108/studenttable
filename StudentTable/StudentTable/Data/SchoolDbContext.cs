using Microsoft.EntityFrameworkCore;
using StudentTable.Model;

namespace StudentTable.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<StudentCourses> StudentCourses { get;set; }
        public DbSet<Students> Students { get; set; }
    }
}
