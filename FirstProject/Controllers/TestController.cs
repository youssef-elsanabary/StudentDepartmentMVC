using FirstProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace FirstProject.Controllers
{
    public class TestController : Controller
    {
        public int add(int x , int y) {  return x + y; }
        [Authorize]
        public string display()
       {
            return "welcome mvc";
       }
        public IActionResult show(int id) 
       {
            if (id == 1) {
                return Content("ahmed");
            }
            if (id == 2)
            {
                List<Student> student = [
                    new Student() {StudentId = 1 , StudentName = "youssef" ,StudentAge = 24},
                    new Student() {StudentId = 2 , StudentName = "omnia" ,StudentAge = 24},
                    new Student() {StudentId = 3 , StudentName = "mohamed" ,StudentAge = 28},
                    new Student() {StudentId = 4 , StudentName = "omar" ,StudentAge = 26}

                 ];
                return Json(student);
            }
            if (id == 3)
            {
                return NotFound();
            }
            if (id == 4)
            {
                return File("~/ShowFile.txt","text/plain","names");
            }
            if (id == 5)
            {
                return Redirect("http://www.google.com");
            }
            if (id == 6)
            {
                return RedirectPermanent("http://www.google.com");
            }
            if (id == 7)
            {
                return RedirectToAction("add", "test", new {x=50,y=60});
            }
            return View();
       }
        public IActionResult ReadArray()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> ReadArray(string[] arr ,IFormFile stdImg)
        {
            string filename=stdImg.FileName;
            using (FileStream fs = new FileStream($"wwwroot/images/{filename}", FileMode.Create))
            {
                await fs.CopyToAsync(fs);
            }
            string s = "";
            foreach (string str in arr) {
                s += str;
            }
            ViewBag.name = s;
            ViewBag.img = filename;
            return View("show2");
        }
        public IActionResult ReadDic(Dictionary<string, int> arr)
        {
            return View();
        }
        //Add Data To cookies
        public IActionResult AddData(int id, string name)
        {
            Response.Cookies.Append("Id",id.ToString());
            Response.Cookies.Append("Name", name);
            return Content($"{id} : {name}");
        }
        //Recive Data from cookies
        public IActionResult ReadData()
        { 
            int id = int.Parse(Request.Cookies["Id"]);
            string name = Request.Cookies["Name"];
            return Content($"{id} : {name}");
        }
        //Add Data To Session
        public IActionResult AddDataSession(int id, string name)
        {
            HttpContext.Session.SetInt32("Id", id);
            HttpContext.Session.SetString("Name", name);
            return Content($"{id} : {name}");
        }
        //Recive Data from Session
        public IActionResult ReadDataSession()
        {
            int? id = HttpContext.Session.GetInt32("Id");
            string? name = HttpContext.Session.GetString("Name");
            return Content($"{id} : {name}");
        }
    }
}
