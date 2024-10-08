using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace RazorPageApp.Pages.test
{
    public class DisplayModel :PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        public void OnGet(string name)
        {
            Name = name;
        }
        public void OnPost() {}

    }
}
