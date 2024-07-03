using Microsoft.AspNetCore.Mvc;

namespace imammaturidi.org.Controllers
{
    public class TopicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
