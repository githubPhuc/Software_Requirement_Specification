using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Data;
using Software_Requirement_Specification.Models;

namespace Software_Requirement_Specification.Areas.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiLieuxController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public TaiLieuxController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/TaiLieux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiLieu>>> GetTaiLieu()
        {
            return await _context.TaiLieu.ToListAsync();
        }

        // GET: api/TaiLieux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiLieu>> GetTaiLieu(int id)
        {
            var taiLieu = await _context.TaiLieu.FindAsync(id);

            if (taiLieu == null)
            {
                return NotFound();
            }

            return taiLieu;
        }

        // PUT: api/TaiLieux/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaiLieu(int id, TaiLieu taiLieu)
        {
            if (id != taiLieu.Id)
            {
                return BadRequest();
            }

            _context.Entry(taiLieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiLieuExists(id))
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

        // POST: api/TaiLieux
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaiLieu>> PostTaiLieu(TaiLieu taiLieu)
        {
            _context.TaiLieu.Add(taiLieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaiLieu", new { id = taiLieu.Id }, taiLieu);
        }

        // DELETE: api/TaiLieux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaiLieu(int id)
        {
            var taiLieu = await _context.TaiLieu.FindAsync(id);
            if (taiLieu == null)
            {
                return NotFound();
            }

            _context.TaiLieu.Remove(taiLieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaiLieuExists(int id)
        {
            return _context.TaiLieu.Any(e => e.Id == id);
        }
    }
}
