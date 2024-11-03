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
    public class JawabansController : ControllerBase
    {
        private readonly diskusiPrContext _context;

        public JawabansController(diskusiPrContext context)
        {
            _context = context;
        }

        // GET: api/Jawabans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jawaban>>> GetJawabans()
        {
          if (_context.Jawabans == null)
          {
              return NotFound();
          }
            return await _context.Jawabans.ToListAsync();
        }

        // GET: api/Jawabans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jawaban>> GetJawaban(int id)
        {
          if (_context.Jawabans == null)
          {
              return NotFound();
          }
            var jawaban = await _context.Jawabans.FindAsync(id);

            if (jawaban == null)
            {
                return NotFound();
            }

            return jawaban;
        }

        // PUT: api/Jawabans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJawaban(int id, Jawaban jawaban)
        {
            if (id != jawaban.IdJawaban)
            {
                return BadRequest();
            }

            _context.Entry(jawaban).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JawabanExists(id))
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

        // POST: api/Jawabans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jawaban>> PostJawaban(Jawaban jawaban)
        {
          if (_context.Jawabans == null)
          {
              return Problem("Entity set 'diskusiPrContext.Jawabans'  is null.");
          }
            _context.Jawabans.Add(jawaban);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJawaban", new { id = jawaban.IdJawaban }, jawaban);
        }

        // DELETE: api/Jawabans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJawaban(int id)
        {
            if (_context.Jawabans == null)
            {
                return NotFound();
            }
            var jawaban = await _context.Jawabans.FindAsync(id);
            if (jawaban == null)
            {
                return NotFound();
            }

            _context.Jawabans.Remove(jawaban);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JawabanExists(int id)
        {
            return (_context.Jawabans?.Any(e => e.IdJawaban == id)).GetValueOrDefault();
        }
    }
}
