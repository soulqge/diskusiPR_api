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
    public class MataPelajaransController : ControllerBase
    {
        private readonly diskusiPrContext _context;

        public MataPelajaransController(diskusiPrContext context)
        {
            _context = context;
        }

        // GET: api/MataPelajarans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MataPelajaran>>> GetMataPelajarans()
        {
          if (_context.MataPelajarans == null)
          {
              return NotFound();
          }
            return await _context.MataPelajarans.ToListAsync();
        }

        // GET: api/MataPelajarans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MataPelajaran>> GetMataPelajaran(int id)
        {
          if (_context.MataPelajarans == null)
          {
              return NotFound();
          }
            var mataPelajaran = await _context.MataPelajarans.FindAsync(id);

            if (mataPelajaran == null)
            {
                return NotFound();
            }

            return mataPelajaran;
        }

        // PUT: api/MataPelajarans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMataPelajaran(int id, MataPelajaran mataPelajaran)
        {
            if (id != mataPelajaran.IdMataPelajaran)
            {
                return BadRequest();
            }

            _context.Entry(mataPelajaran).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MataPelajaranExists(id))
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

        // POST: api/MataPelajarans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MataPelajaran>> PostMataPelajaran(MataPelajaran mataPelajaran)
        {
          if (_context.MataPelajarans == null)
          {
              return Problem("Entity set 'diskusiPrContext.MataPelajarans'  is null.");
          }
            _context.MataPelajarans.Add(mataPelajaran);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMataPelajaran", new { id = mataPelajaran.IdMataPelajaran }, mataPelajaran);
        }

        // DELETE: api/MataPelajarans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMataPelajaran(int id)
        {
            if (_context.MataPelajarans == null)
            {
                return NotFound();
            }
            var mataPelajaran = await _context.MataPelajarans.FindAsync(id);
            if (mataPelajaran == null)
            {
                return NotFound();
            }

            _context.MataPelajarans.Remove(mataPelajaran);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MataPelajaranExists(int id)
        {
            return (_context.MataPelajarans?.Any(e => e.IdMataPelajaran == id)).GetValueOrDefault();
        }
    }
}
