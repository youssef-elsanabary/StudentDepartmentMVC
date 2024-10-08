using FirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Services
{
    public class StudentService : IStudentService
    {
        ITIDbContext db = new ITIDbContext();

        public List<Student> GetAll()
        {
            var allStudent = db.Students.Include(a => a.Department).ToList();
            return allStudent;
        }
        public Student GetById(int id) 
        {
            var std = db.Students.Include(a => a.Department).FirstOrDefault(a=>a.StudentId==id);
            return std;
        }
        public void Add(Student student) 
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public void Update(Student student)
        { 
            db.Students.Update(student);
            db.SaveChanges();
        }
        public void Delete(int id) 
        {
            var deletedStd = db.Students.FirstOrDefault(a=>a.StudentId == id);
            db.Students.Remove(deletedStd);
            db.SaveChanges();
        }
    }
}
