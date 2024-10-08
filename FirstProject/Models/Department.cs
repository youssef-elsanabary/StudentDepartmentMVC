using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required, Length(3, 10)]
        public string DepartmentName { get; set; }
        public int? Capacity { get; set; }
        public virtual HashSet<Student> Students { get; set; } = new HashSet<Student> { };
        public virtual HashSet<Courses> Courses { get; set; } = new HashSet<Courses> { };

    }
}
