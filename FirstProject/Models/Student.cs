using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProject.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required,Length(3,30)]
        public string StudentName { get; set; }
        [Range(10,30)]
        public int StudentAge { get; set; }
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        [Remote("CheckEmailExist","student",AdditionalFields ="Name,Age")]
        public string StudentEmail { get; set; }
        [Required,MinLength(3)]
        public string Password { get; set; }
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        [ForeignKey("Department")]
        public int DeptNo { get; set; }
        public  virtual Department? Department { get; set; }
        public virtual HashSet<StudentCourse> Course { get; set; } = new HashSet<StudentCourse> { };

    }
}
