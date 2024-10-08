using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProject.Models
{
    public class StudentCourse
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public int? Degree { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Courses? Course { get; set; }
    }
}
