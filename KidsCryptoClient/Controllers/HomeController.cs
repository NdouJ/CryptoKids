using KidsCryptoClient.Models;
using KidsCryptoClient.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Diagnostics;

namespace KidsCryptoClient.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILoggerFactory loggerFactory)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            _logger = loggerFactory.CreateLogger<HomeController>(); //dpi
        }





        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<CryptoNews> cryptoNews = new List<CryptoNews>();    

            try
            {
                cryptoNews = await NewsService.GetNewsAsync();
            }
            catch (HttpRequestException ex)
            {
                // Serilog
                Log.Error(ex, "An error occurred while sending the HTTP request to Crypto News.");
            }
            catch (JsonException ex)
            {
               
                Log.Error(ex, "An error occurred while deserializing the JSON response.");
            }




            return View("Index", cryptoNews??Enumerable.Empty<CryptoNews>());
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

        ~HomeController()
        {
            Log.CloseAndFlush();
        }
    }
}