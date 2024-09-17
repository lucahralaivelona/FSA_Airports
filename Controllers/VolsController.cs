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
    public class VolsController : ControllerBase
    {
        private readonly FsaContext _context;

        public VolsController(FsaContext context)
        {
            _context = context;
        }

        // GET: api/Vols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols()
        {
          if (_context.Vols == null)
          {
              return NotFound();
          }
            return await _context.Vols.ToListAsync();
        }

        // GET: api/Vols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vol>> GetVol(int id)
        {
          if (_context.Vols == null)
          {
              return NotFound();
          }
            var vol = await _context.Vols.FindAsync(id);

            if (vol == null)
            {
                return NotFound();
            }

            return vol;
        }

        // PUT: api/Vols/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.idVol)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
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

        // POST: api/Vols
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
          if (_context.Vols == null)
          {
              return Problem("Entity set 'FsaContext.Vols'  is null.");
          }
            _context.Vols.Add(vol);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VolExists(vol.idVol))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVol", new { id = vol.idVol }, vol);
        }
        // GET: api/Vols/ByLocation/{location}
        [HttpGet("ByLocation/{location}")]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVolsByLocation(string location)
        {
            if (_context.Vols == null)
            {
                return NotFound();
            }

            // Recherchez les vols par emplacement
            var volsByLocation = await _context.Vols
                .Where(v => v.Local == location) // Utilisez la propriété Local pour la recherche
                .ToListAsync();

            if (volsByLocation.Count == 0)
            {
                return NotFound($"Aucun vol trouvé pour l'emplacement spécifié : {location}");
            }

            return volsByLocation;
        }

        // DELETE: api/Vols/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVol(int id)
        {
            if (_context.Vols == null)
            {
                return NotFound();
            }
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VolExists(int id)
        {
            return (_context.Vols?.Any(e => e.idVol == id)).GetValueOrDefault();
        }
    }
}
