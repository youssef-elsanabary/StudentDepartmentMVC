using FirstProject.Models;
using FirstProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentController : Controller
    {
        ITIDbContext db = new ITIDbContext();
        IStudentService studentService;
        IDepartmentService departmentService;
        public StudentController(IStudentService _studentService,IDepartmentService _departmentService)
        {
            studentService = _studentService;
            departmentService = _departmentService;
        }
        //StudentService studentService = new StudentService();
        //action raed all Data => Index
        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Student> model = studentService.GetAll();
            return View(model);
        }
        //action read only one
        public IActionResult Details(int? id) 
        {
            if (id == null)
            {
                return BadRequest();
            }
            else { 
                var model = studentService.GetById(id.Value);
                if (model == null) { 
                    return NotFound();
                }
                return View(model);
            } 
        }
        public IActionResult AddStudent() {
            var dept = departmentService.GetAll();
            SelectList deptList = new SelectList(dept, "DepartmentId", "DepartmentName");
            ViewBag.Department = deptList;
            return View(); }
        //Add Student by model binder
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                studentService.Add(student);
                return RedirectToAction("Index");
            }
            else
            {
                var dept = departmentService.GetAll();
                SelectList deptList = new SelectList(dept, "DepartmentId", "DepartmentName");
                ViewBag.Department = deptList;
                return View();
            }
        }
        public IActionResult CheckEmailExist(string Email,string name ,int age)
        {
            var res = db.Students.FirstOrDefault(a=>a.StudentEmail == Email);
            if (res != null)
            {
                return Json($"email already exist you can use {name}{age}@iti.com");
            }
            return Json(true);
        }
        //Edit student
        public IActionResult Edit(int? id) 
        {
            if(id == null) {return BadRequest();}
            var std = db.Students.SingleOrDefault(s => s.StudentId == id);
            if (std == null) { return NotFound(); }
            var dept = departmentService.GetAll();
            SelectList deptsl = new SelectList(dept, "DepartmentId", "DepartmentName");
            ViewBag.Department = deptsl;
            return View(std);
        }
        [HttpPost]
        public IActionResult Edit(Student std)
        {
            studentService.Update(std);
            return RedirectToAction("Index");
        }
        //delete student
        public IActionResult Delete(int? id) {
            if (id == null) { return BadRequest(); }
            var std = studentService.GetById(id.Value);
            if (std == null) { return NotFound(); }
            return View(std);
        }
        //[ActionName("Delete"),HttpPost]
        public IActionResult ConfirmationDelete(int? id)
        {
            studentService.Delete(id.Value);
            return RedirectToAction("Index");
        }
}
}
