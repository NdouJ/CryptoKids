using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KidscryptoApi.Models;
using KidscryptoAp.Data;

namespace KidscryptoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CryptoFactsController : ControllerBase
    {

        private readonly ApiContext _context;
        public CryptoFactsController(ApiContext context)
        {

            _context = context;
        }

        [HttpGet]
        public JsonResult GetCryptoFact(){

     
            int count = _context.factories.Count();

            int randomIndex = new Random().Next(0, count);

   
            object? randomCryptoFact = _context.factories.Skip(randomIndex).FirstOrDefault();

            object? randumCryptoFact = null;
            return new JsonResult(Ok(randumCryptoFact));

        }

        [HttpGet()]
        public JsonResult GetAll(){
        
        var result = _context.factories.ToList();

        return new JsonResult(Ok(result));      
        }

    }
}
