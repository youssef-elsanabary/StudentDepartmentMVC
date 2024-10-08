using FirstProject.Models;

namespace FirstProject.Services
{
    public interface IDepartmentService
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Add(Department department);
        public void Update(Department department);
        public void Delete(int id);
    }
}
