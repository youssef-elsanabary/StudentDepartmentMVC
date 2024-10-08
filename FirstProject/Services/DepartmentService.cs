using FirstProject.Models;

namespace FirstProject.Services
{
    public class DepartmentService:IDepartmentService
    {
        ITIDbContext db = new ITIDbContext();


        public List<Department> GetAll()
        {
            var allDept = db.Departments.ToList();
            return allDept; 
        }
        public Department GetById(int id) 
        {
            var dept = db.Departments.SingleOrDefault(a=>a.DepartmentId == id);
            return dept;
        }
        public void Add(Department department) 
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public void Update(Department department) 
        {
            db.Departments.Update(department);
            db.SaveChanges();
        }
        public void Delete(int id) 
        {
            var deletedDept = db.Departments.FirstOrDefault(a=>a.DepartmentId == id);
            db.Remove(deletedDept);
            db.SaveChanges();
        }
    }
}
