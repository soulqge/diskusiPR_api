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
    public class SubMataPelajaransController : ControllerBase
    {
        private readonly diskusiPrContext _context;

        public SubMataPelajaransController(diskusiPrContext context)
        {
            _context = context;
        }

        // GET: api/SubMataPelajarans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubMataPelajaran>>> GetSubMataPelajarans()
        {
          if (_context.SubMataPelajarans == null)
          {
              return NotFound();
          }
            return await _context.SubMataPelajarans.ToListAsync();
        }

        // GET: api/SubMataPelajarans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubMataPelajaran>> GetSubMataPelajaran(int id)
        {
          if (_context.SubMataPelajarans == null)
          {
              return NotFound();
          }
            var subMataPelajaran = await _context.SubMataPelajarans.FindAsync(id);

            if (subMataPelajaran == null)
            {
                return NotFound();
            }

            return subMataPelajaran;
        }

        // PUT: api/SubMataPelajarans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubMataPelajaran(int id, SubMataPelajaran subMataPelajaran)
        {
            if (id != subMataPelajaran.IdSubMapel)
            {
                return BadRequest();
            }

            _context.Entry(subMataPelajaran).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubMataPelajaranExists(id))
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

        // POST: api/SubMataPelajarans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubMataPelajaran>> PostSubMataPelajaran(SubMataPelajaran subMataPelajaran)
        {
          if (_context.SubMataPelajarans == null)
          {
              return Problem("Entity set 'diskusiPrContext.SubMataPelajarans'  is null.");
          }
            _context.SubMataPelajarans.Add(subMataPelajaran);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubMataPelajaran", new { id = subMataPelajaran.IdSubMapel }, subMataPelajaran);
        }

        // DELETE: api/SubMataPelajarans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubMataPelajaran(int id)
        {
            if (_context.SubMataPelajarans == null)
            {
                return NotFound();
            }
            var subMataPelajaran = await _context.SubMataPelajarans.FindAsync(id);
            if (subMataPelajaran == null)
            {
                return NotFound();
            }

            _context.SubMataPelajarans.Remove(subMataPelajaran);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubMataPelajaranExists(int id)
        {
            return (_context.SubMataPelajarans?.Any(e => e.IdSubMapel == id)).GetValueOrDefault();
        }
    }
}
