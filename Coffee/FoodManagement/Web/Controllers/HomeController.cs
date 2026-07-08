using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("About")] 
        public IActionResult About()
        {
            return View();
        }
        [Route("Service")]
        public IActionResult Service()
        {
            return View();
        }
        [Route("Article")]
        public IActionResult Article()
        {
            return View();
        }
    }
}