using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        [Required,Length(3,10)] 
        public string CourseName { get; set; }
        public int? Duration { get; set; }
        public virtual HashSet<Department> Departments { get; set; } = new HashSet<Department> { };
        public virtual HashSet<StudentCourse> Std { get; set; } = new HashSet<StudentCourse> { };

    }
}
