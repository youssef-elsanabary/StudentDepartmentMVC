using FirstProject.Models;
using FirstProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FirstProject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DepartmentController : Controller
    {
        ITIDbContext db = new ITIDbContext();
        IDepartmentService departmentService ;
        public DepartmentController(IDepartmentService _departmentService)
        {
            departmentService = _departmentService;
        }
        //Show All Department
        [Authorize]
        public IActionResult Index()
        {
             List<Department> departments =departmentService.GetAll();
            return View(departments);
        }
        //Add Department
        public IActionResult AddDepartment(int id) 
        {

            return View();
        }
        //Show Department Data
        public IActionResult Details(int id)
        {
            var dept_details = departmentService.GetById(id);
            return View(dept_details);
        }
        //Manage Courses
        public IActionResult ManageCourses(int id)
        {
            var allcourses = db.Courses.ToList();
            var coursesInDept = db.Departments.Include(a => a.Courses).FirstOrDefault(d => d.DepartmentId == id);
            var coursesNotInDept = allcourses.Except(coursesInDept.Courses);
            
            ViewBag.allcourses = allcourses;
            ViewBag.coursesInDept = coursesInDept.Courses;
            ViewBag.coursesNotInDept = coursesNotInDept;
            return View();
        }
        [HttpPost]
        public IActionResult ManageCourses(int id, List<int> removeFromDept, List<int> addInDept)
        {
            var Dept = db.Departments.Include(a => a.Courses).FirstOrDefault(d => d.DepartmentId == id);
            foreach (int item in removeFromDept)
            {
                var crs = db.Courses.SingleOrDefault(a=>a.CourseId == item);
                Dept.Courses.Remove(crs);
            }
            foreach (int item in addInDept)
            {
                var crs = db.Courses.SingleOrDefault(a => a.CourseId == item);
                Dept.Courses.Add(crs);
            }
            db.SaveChanges();
            return RedirectToAction("Details", "Department",new{ id=id});
        }
        //Add Courses Degree
        public IActionResult AddDegree(int deptId, int crsId)
        {
            var dept = db.Departments.Include(a => a.Courses).SingleOrDefault(d => d.DepartmentId == deptId);
            var crs = db.Courses.SingleOrDefault(c => c.CourseId == crsId);
            ViewBag.crs = crs;
            return View(dept);
        }
        [HttpPost]
        public IActionResult AddDegree(int deptId,int crsId ,Dictionary<int,int> deg)
        {
            foreach (var item in deg)
            {
                var crsDegree =db.StudentCourse.FirstOrDefault(c => c.CourseId == crsId && c.StudentId == item.Value);
                if(crsDegree == null)
                {
                    db.StudentCourse.Add(new StudentCourse() { CourseId = crsId, StudentId = item.Key, Degree = item.Value });
                }
                else
                {
                    crsDegree.Degree = item.Value;
                }
            }
            db.SaveChanges();
            return Content("Added");
        }
    }
}
