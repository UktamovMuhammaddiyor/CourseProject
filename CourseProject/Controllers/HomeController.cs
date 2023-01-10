using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToRoute(new 
            {
                controller = "Review",
                action = "List"
            });
        }
    }
}
