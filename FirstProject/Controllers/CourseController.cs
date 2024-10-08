using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
