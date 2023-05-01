using KidsCryptoClient.Models;
using KidsCryptoClient.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace KidsCryptoClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }





        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<CryptoNews> cryptoNews=null;

            try
            {
                cryptoNews = await NewsService.GetNewsAsync();
            }
            catch (Exception)
            {

                throw;
            }
           
               


            return View("Index", cryptoNews);
        }

       


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}