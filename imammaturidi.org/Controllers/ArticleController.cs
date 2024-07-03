using Microsoft.AspNetCore.Mvc;

namespace imammaturidi.org.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
