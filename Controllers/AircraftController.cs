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
    public class AircraftController : ControllerBase
    {
        private readonly FsaContext _context;

        public AircraftController(FsaContext context)
        {
            _context = context;
        }

        // GET: api/Aircraft
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aircraft>>> GetAircraft()
        {
          if (_context.Aircraft == null)
          {
              return NotFound();
          }
            return await _context.Aircraft.ToListAsync();
        }

        // GET: api/Aircraft/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aircraft>> GetAircraft(string id)
        {
          if (_context.Aircraft == null)
          {
              return NotFound();
          }
            var aircraft = await _context.Aircraft.FindAsync(id);

            if (aircraft == null)
            {
                return NotFound();
            }

            return aircraft;
        }

        // PUT: api/Aircraft/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraft(string id, Aircraft aircraft)
        {
            if (id != aircraft.Immatriculation)
            {
                return BadRequest();
            }

            _context.Entry(aircraft).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftExists(id))
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

        // POST: api/Aircraft
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aircraft>> PostAircraft(Aircraft aircraft)
        {
          if (_context.Aircraft == null)
          {
              return Problem("Entity set 'FsaContext.Aircraft'  is null.");
          }
            _context.Aircraft.Add(aircraft);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AircraftExists(aircraft.Immatriculation))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAircraft", new { id = aircraft.Immatriculation }, aircraft);
        }

        // DELETE: api/Aircraft/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraft(string id)
        {
            if (_context.Aircraft == null)
            {
                return NotFound();
            }
            var aircraft = await _context.Aircraft.FindAsync(id);
            if (aircraft == null)
            {
                return NotFound();
            }

            _context.Aircraft.Remove(aircraft);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AircraftExists(string id)
        {
            return (_context.Aircraft?.Any(e => e.Immatriculation == id)).GetValueOrDefault();
        }
    }
}
