using FirstProject.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FirstProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
            builder.Services.AddSingleton<IStudentService, StudentService>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(a=> a.LoginPath = "/account/login");
            builder.Services.AddSession( a=> {
            
            
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Student}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
