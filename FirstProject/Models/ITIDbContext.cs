using Microsoft.EntityFrameworkCore;

namespace FirstProject.Models
{
    public class ITIDbContext : DbContext 
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=YOUSSEF\\SQLEXPRESS;Initial Catalog = itiMVC ;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(a =>
            {
                a.HasKey(s => new { s.StudentId, s.CourseId });
            });
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
