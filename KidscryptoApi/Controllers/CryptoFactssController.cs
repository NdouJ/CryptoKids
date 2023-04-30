using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KidscryptoApi.Models;

namespace KidscryptoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoFactssController : ControllerBase
    {
        private readonly CryptoKidsContext _context;

        public CryptoFactssController(CryptoKidsContext context)
        {
            _context = context;
        }

        // GET: api/CryptoFactss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CryptoFact>>> GetCryptoFacts()
        {
          if (_context.CryptoFacts == null)
          {
              return NotFound();
          }
            return await _context.CryptoFacts.ToListAsync();
        }

        // GET: api/CryptoFactss/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CryptoFact>> GetCryptoFact(int id)
        {
          if (_context.CryptoFacts == null)
          {
              return NotFound();
          }
            var cryptoFact = await _context.CryptoFacts.FindAsync(id);

            if (cryptoFact == null)
            {
                return NotFound();
            }

            return cryptoFact;
        }

        // PUT: api/CryptoFactss/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCryptoFact(int id, CryptoFact cryptoFact)
        {
            if (id != cryptoFact.IdCryptoFact)
            {
                return BadRequest();
            }

            _context.Entry(cryptoFact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CryptoFactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CryptoFactss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CryptoFact>> PostCryptoFact(CryptoFact cryptoFact)
        {
          if (_context.CryptoFacts == null)
          {
              return Problem("Entity set 'CryptoKidsContext.CryptoFacts'  is null.");
          }
            _context.CryptoFacts.Add(cryptoFact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCryptoFact", new { id = cryptoFact.IdCryptoFact }, cryptoFact);
        }

        // DELETE: api/CryptoFactss/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCryptoFact(int id)
        {
            if (_context.CryptoFacts == null)
            {
                return NotFound();
            }
            var cryptoFact = await _context.CryptoFacts.FindAsync(id);
            if (cryptoFact == null)
            {
                return NotFound();
            }

            _context.CryptoFacts.Remove(cryptoFact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CryptoFactExists(int id)
        {
            return (_context.CryptoFacts?.Any(e => e.IdCryptoFact == id)).GetValueOrDefault();
        }
    }
}
