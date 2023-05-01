using Microsoft.AspNetCore.Mvc;

namespace KidsCryptoClient.Controllers
{
    public class LearnController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
