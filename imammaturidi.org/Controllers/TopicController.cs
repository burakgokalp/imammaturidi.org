using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imammaturidi.org.Controllers
{
    [AllowAnonymous]
    public class TopicController : Controller
    {
        public IActionResult Index()
        {
            // List all topics with its article count
            return View();
        }
    }
}
