using FirstProject.Models;

namespace FirstProject.Services
{
    public interface IStudentService
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Add(Student student);
        public void Update(Student student);
        public void Delete(int id);
    }
}
