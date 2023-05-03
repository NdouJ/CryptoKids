using KidscryptoLib.Models;
using KidsCryptoClient.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace KidsCryptoClient.Controllers
{
    public class LearnController : Controller
    {
        private readonly ILogger<LearnController> _logger;
        private IEnumerable<KidsCryptoClient.Models.CryptoFact> facts;

        public LearnController(ILoggerFactory loggerFactory)
        {
            Log.Logger = new LoggerConfiguration()
              .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
              .CreateLogger();

            _logger = loggerFactory.CreateLogger<LearnController>();//dpi

        }

        public async Task<IActionResult> Index()
        {
            facts  = await CryptoFactService.GetCryptoFacts();


            //try
            //{
            //    facts = await CryptoFactService.GetCryptoFacts();

            //}
            //catch (HttpRequestException ex)
            //{
            //    // Serilog
            //    Log.Error(ex, "An error occurred while sending the HTTP request to Crypto Facts API.");
            //}
            //catch (JsonException ex)
            //{

            //    Log.Error(ex, "An error occurred while deserializing the JSON response.");
            //}

            Models.CryptoFact[] cryptoFacts = facts.ToArray();

            return View("NewFact", cryptoFacts[1]);
        }

        public object NewFact(){

            Models.CryptoFact [] cryptoFacts = facts.ToArray();


        return View("NewFact", cryptoFacts[1]);
        }


        ~LearnController()
        {
            Log.CloseAndFlush();
        }
    }
}
