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
    public class GestionnaireAerodromesController : ControllerBase
    {
        private readonly FsaContext _context;

        public GestionnaireAerodromesController(FsaContext context)
        {
            _context = context;
        }

        // GET: api/GestionnaireAerodromes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GestionnaireAerodrome>>> GetGestionnaireAerodromes()
        {
          if (_context.GestionnaireAerodromes == null)
          {
              return NotFound();
          }
            return await _context.GestionnaireAerodromes.ToListAsync();
        }

        // GET: api/GestionnaireAerodromes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GestionnaireAerodrome>> GetGestionnaireAerodrome(int id)
        {
          if (_context.GestionnaireAerodromes == null)
          {
              return NotFound();
          }
            var gestionnaireAerodrome = await _context.GestionnaireAerodromes.FindAsync(id);

            if (gestionnaireAerodrome == null)
            {
                return NotFound();
            }

            return gestionnaireAerodrome;
        }

        // PUT: api/GestionnaireAerodromes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGestionnaireAerodrome(int id, GestionnaireAerodrome gestionnaireAerodrome)
        {
            if (id != gestionnaireAerodrome.IdGestionnaireAerodrome)
            {
                return BadRequest();
            }

            _context.Entry(gestionnaireAerodrome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GestionnaireAerodromeExists(id))
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

        // POST: api/GestionnaireAerodromes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GestionnaireAerodrome>> PostGestionnaireAerodrome(GestionnaireAerodrome gestionnaireAerodrome)
        {
          if (_context.GestionnaireAerodromes == null)
          {
              return Problem("Entity set 'FsaContext.GestionnaireAerodromes'  is null.");
          }
            _context.GestionnaireAerodromes.Add(gestionnaireAerodrome);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGestionnaireAerodrome", new { id = gestionnaireAerodrome.IdGestionnaireAerodrome }, gestionnaireAerodrome);
        }

        // DELETE: api/GestionnaireAerodromes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGestionnaireAerodrome(int id)
        {
            if (_context.GestionnaireAerodromes == null)
            {
                return NotFound();
            }
            var gestionnaireAerodrome = await _context.GestionnaireAerodromes.FindAsync(id);
            if (gestionnaireAerodrome == null)
            {
                return NotFound();
            }

            _context.GestionnaireAerodromes.Remove(gestionnaireAerodrome);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GestionnaireAerodromeExists(int id)
        {
            return (_context.GestionnaireAerodromes?.Any(e => e.IdGestionnaireAerodrome == id)).GetValueOrDefault();
        }
    }
}
