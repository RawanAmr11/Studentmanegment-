using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
