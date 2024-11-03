using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using diskusiPR.Models;

namespace diskusiPR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoalsController : ControllerBase
    {
        private readonly diskusiPrContext _context;

        public SoalsController(diskusiPrContext context)
        {
            _context = context;
        }

        // GET: api/Soals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Soal>>> GetSoals()
        {
          if (_context.Soals == null)
          {
              return NotFound();
          }
            return await _context.Soals.ToListAsync();
        }

        // GET: api/Soals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Soal>> GetSoal(int id)
        {
          if (_context.Soals == null)
          {
              return NotFound();
          }
            var soal = await _context.Soals.FindAsync(id);

            if (soal == null)
            {
                return NotFound();
            }

            return soal;
        }

        // PUT: api/Soals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoal(int id, Soal soal)
        {
            if (id != soal.IdSoal)
            {
                return BadRequest();
            }

            _context.Entry(soal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoalExists(id))
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

        // POST: api/Soals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Soal>> PostSoal(Soal soal)
        {
          if (_context.Soals == null)
          {
              return Problem("Entity set 'diskusiPrContext.Soals'  is null.");
          }
            _context.Soals.Add(soal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoal", new { id = soal.IdSoal }, soal);
        }

        // DELETE: api/Soals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoal(int id)
        {
            if (_context.Soals == null)
            {
                return NotFound();
            }
            var soal = await _context.Soals.FindAsync(id);
            if (soal == null)
            {
                return NotFound();
            }

            _context.Soals.Remove(soal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoalExists(int id)
        {
            return (_context.Soals?.Any(e => e.IdSoal == id)).GetValueOrDefault();
        }
    }
}
