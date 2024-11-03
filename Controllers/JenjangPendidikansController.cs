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
    public class JenjangPendidikansController : ControllerBase
    {
        private readonly diskusiPrContext _context;

        public JenjangPendidikansController(diskusiPrContext context)
        {
            _context = context;
        }

        // GET: api/JenjangPendidikans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JenjangPendidikan>>> GetJenjangPendidikans()
        {
          if (_context.JenjangPendidikans == null)
          {
              return NotFound();
          }
            return await _context.JenjangPendidikans.ToListAsync();
        }

        // GET: api/JenjangPendidikans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JenjangPendidikan>> GetJenjangPendidikan(int id)
        {
          if (_context.JenjangPendidikans == null)
          {
              return NotFound();
          }
            var jenjangPendidikan = await _context.JenjangPendidikans.FindAsync(id);

            if (jenjangPendidikan == null)
            {
                return NotFound();
            }

            return jenjangPendidikan;
        }

        // PUT: api/JenjangPendidikans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJenjangPendidikan(int id, JenjangPendidikan jenjangPendidikan)
        {
            if (id != jenjangPendidikan.IdJenjangPendidikan)
            {
                return BadRequest();
            }

            _context.Entry(jenjangPendidikan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JenjangPendidikanExists(id))
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

        // POST: api/JenjangPendidikans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JenjangPendidikan>> PostJenjangPendidikan(JenjangPendidikan jenjangPendidikan)
        {
          if (_context.JenjangPendidikans == null)
          {
              return Problem("Entity set 'diskusiPrContext.JenjangPendidikans'  is null.");
          }
            _context.JenjangPendidikans.Add(jenjangPendidikan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJenjangPendidikan", new { id = jenjangPendidikan.IdJenjangPendidikan }, jenjangPendidikan);
        }

        // DELETE: api/JenjangPendidikans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJenjangPendidikan(int id)
        {
            if (_context.JenjangPendidikans == null)
            {
                return NotFound();
            }
            var jenjangPendidikan = await _context.JenjangPendidikans.FindAsync(id);
            if (jenjangPendidikan == null)
            {
                return NotFound();
            }

            _context.JenjangPendidikans.Remove(jenjangPendidikan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JenjangPendidikanExists(int id)
        {
            return (_context.JenjangPendidikans?.Any(e => e.IdJenjangPendidikan == id)).GetValueOrDefault();
        }
    }
}
