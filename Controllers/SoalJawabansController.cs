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
    public class SoalJawabansController : ControllerBase
    {
        private readonly diskusiPrContext _context;

        public SoalJawabansController(diskusiPrContext context)
        {
            _context = context;
        }

        // GET: api/SoalJawabans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoalJawaban>>> GetSoalJawabans()
        {
          if (_context.SoalJawabans == null)
          {
              return NotFound();
          }
            return await _context.SoalJawabans.ToListAsync();
        }

        // GET: api/SoalJawabans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoalJawaban>> GetSoalJawaban(int id)
        {
          if (_context.SoalJawabans == null)
          {
              return NotFound();
          }
            var soalJawaban = await _context.SoalJawabans.FindAsync(id);

            if (soalJawaban == null)
            {
                return NotFound();
            }

            return soalJawaban;
        }

        // PUT: api/SoalJawabans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoalJawaban(int id, SoalJawaban soalJawaban)
        {
            if (id != soalJawaban.IdSoalJawaban)
            {
                return BadRequest();
            }

            _context.Entry(soalJawaban).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoalJawabanExists(id))
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

        // POST: api/SoalJawabans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoalJawaban>> PostSoalJawaban(SoalJawaban soalJawaban)
        {
          if (_context.SoalJawabans == null)
          {
              return Problem("Entity set 'diskusiPrContext.SoalJawabans'  is null.");
          }
            _context.SoalJawabans.Add(soalJawaban);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoalJawaban", new { id = soalJawaban.IdSoalJawaban }, soalJawaban);
        }

        // DELETE: api/SoalJawabans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoalJawaban(int id)
        {
            if (_context.SoalJawabans == null)
            {
                return NotFound();
            }
            var soalJawaban = await _context.SoalJawabans.FindAsync(id);
            if (soalJawaban == null)
            {
                return NotFound();
            }

            _context.SoalJawabans.Remove(soalJawaban);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoalJawabanExists(int id)
        {
            return (_context.SoalJawabans?.Any(e => e.IdSoalJawaban == id)).GetValueOrDefault();
        }
    }
}
