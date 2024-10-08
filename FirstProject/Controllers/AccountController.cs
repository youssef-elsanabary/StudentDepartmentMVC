using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FirstProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((model.UserName=="youssef" &&  model.Password=="123456")||(model.UserName=="omnia" && model.Password == "123456"))
                {
                    Claim c1 = new Claim(ClaimTypes.Name, model.UserName);
                    Claim c2 = new Claim (ClaimTypes.Email,$"{model.UserName}@iti.com");
                    Claim c3 = new Claim(ClaimTypes.Role, "student");

                    ClaimsIdentity ci1 = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    ci1.AddClaim(c1);
                    ci1.AddClaim(c2);
                    ci1.AddClaim(c3);

                    ClaimsPrincipal cp = new ClaimsPrincipal(ci1 );
                    await HttpContext.SignInAsync(cp);
                    return RedirectToAction("index","home");
                }
                else
                {
                    ModelState.AddModelError("","you need to sign up");
                    return View(model);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        public IActionResult Register()
        {
            return View(); 
        }
    }
}
