using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imammaturidi.org.Controllers
{
    [AllowAnonymous]
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LastArticles()
        {
            //
            return View();
        }
    }
}
