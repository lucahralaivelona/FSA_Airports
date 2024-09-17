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
    public class CompagniesController : ControllerBase
    {
        private readonly FsaContext _context;

        public CompagniesController(FsaContext context)
        {
            _context = context;
        }

        // GET: api/Compagnies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compagnie>>> GetCompagnies()
        {
          if (_context.Compagnies == null)
          {
              return NotFound();
          }
            return await _context.Compagnies.ToListAsync();
        }

        // GET: api/Compagnies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compagnie>> GetCompagnie(int id)
        {
          if (_context.Compagnies == null)
          {
              return NotFound();
          }
            var compagnie = await _context.Compagnies.FindAsync(id);

            if (compagnie == null)
            {
                return NotFound();
            }

            return compagnie;
        }

        // PUT: api/Compagnies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompagnie(int id, Compagnie compagnie)
        {
            if (id != compagnie.IdCompagnie)
            {
                return BadRequest();
            }

            _context.Entry(compagnie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompagnieExists(id))
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

        // POST: api/Compagnies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Compagnie>> PostCompagnie(Compagnie compagnie)
        {
          if (_context.Compagnies == null)
          {
              return Problem("Entity set 'FsaContext.Compagnies'  is null.");
          }
            _context.Compagnies.Add(compagnie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompagnie", new { id = compagnie.IdCompagnie }, compagnie);
        }

        // DELETE: api/Compagnies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompagnie(int id)
        {
            if (_context.Compagnies == null)
            {
                return NotFound();
            }
            var compagnie = await _context.Compagnies.FindAsync(id);
            if (compagnie == null)
            {
                return NotFound();
            }
            _context.Aircraft.RemoveRange(compagnie.Aircraft);
            _context.Compagnies.Remove(compagnie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompagnieExists(int id)
        {
            return (_context.Compagnies?.Any(e => e.IdCompagnie == id)).GetValueOrDefault();
        }
    }
}
