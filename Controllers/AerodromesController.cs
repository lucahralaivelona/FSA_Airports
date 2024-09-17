using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FSAproject.Models;

namespace FSAproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AerodromesController : ControllerBase
    {
        private readonly FsaContext _context;

        public AerodromesController(FsaContext context)
        {
            _context = context;
        }

        // GET: api/Aerodromes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aerodrome>>> GetAerodromes()
        {
          if (_context.Aerodromes == null)
          {
              return NotFound();
          }
            return await _context.Aerodromes.ToListAsync();
        }

        // GET: api/Aerodromes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aerodrome>> GetAerodrome(string id)
        {
          if (_context.Aerodromes == null)
          {
              return NotFound();
          }
            var aerodrome = await _context.Aerodromes.FindAsync(id);

            if (aerodrome == null)
            {
                return NotFound();
            }

            return aerodrome;
        }
        [HttpGet("ByGestionnaire/{idGestionnaire}")]
        public async Task<ActionResult<IEnumerable<Aerodrome>>> GetAerodromesByGestionnaire(int idGestionnaire)
        {
            var aerodromes = await _context.Aerodromes
                .Where(a => a.IdGestionnaireAerodrome == idGestionnaire)
                .ToListAsync();

            if (aerodromes == null || aerodromes.Count == 0)
            {
                return NotFound();
            }

            return aerodromes;
        }

        // PUT: api/Aerodromes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAerodrome(string id, Aerodrome aerodrome)
        {
            if (id != aerodrome.CodeIata)
            {
                return BadRequest();
            }

            _context.Entry(aerodrome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AerodromeExists(id))
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

        // POST: api/Aerodromes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aerodrome>> PostAerodrome(Aerodrome aerodrome)
        {
          if (_context.Aerodromes == null)
          {
              return Problem("Entity set 'FsaContext.Aerodromes'  is null.");
          }
            _context.Aerodromes.Add(aerodrome);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AerodromeExists(aerodrome.CodeIata))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAerodrome", new { id = aerodrome.CodeIata }, aerodrome);
        }

        // DELETE: api/Aerodromes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAerodrome(string id)
        {
            if (_context.Aerodromes == null)
            {
                return NotFound();
            }
            var aerodrome = await _context.Aerodromes.FindAsync(id);
            if (aerodrome == null)
            {
                return NotFound();
            }

            _context.Aerodromes.Remove(aerodrome);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AerodromeExists(string id)
        {
            return (_context.Aerodromes?.Any(e => e.CodeIata == id)).GetValueOrDefault();
        }
    }
}
