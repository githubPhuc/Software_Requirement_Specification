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
    public class cauhoidapansController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public cauhoidapansController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/cauhoidapans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cauhoidapan>>> Getcauhoidapan()
        {
            return await _context.cauhoidapan.ToListAsync();
        }
        [HttpGet]
        [Route("searchTheobaithi/{id}")]
        public async Task<ActionResult<IEnumerable<cauhoidapan>>> searchTheoBaiThi(int id)
        {

            if (id != null)
            {
                var ss = await _context.cauhoidapan.Where(a => a.deThi.Id == id).ToListAsync();
                return ss;
            }
            else
            {
                return NotFound();
            }

        }

        // GET: api/cauhoidapans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<cauhoidapan>> Getcauhoidapan(int id)
        {
            var cauhoidapan = await _context.cauhoidapan.FindAsync(id);

            if (cauhoidapan == null)
            {
                return NotFound();
            }

            return cauhoidapan;
        }

        // PUT: api/cauhoidapans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcauhoidapan(int id, cauhoidapan cauhoidapan)
        {
            if (id != cauhoidapan.id)
            {
                return BadRequest();
            }

            _context.Entry(cauhoidapan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cauhoidapanExists(id))
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

        // POST: api/cauhoidapans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<cauhoidapan>> Postcauhoidapan(cauhoidapan cauhoidapan)
        {
            _context.cauhoidapan.Add(cauhoidapan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcauhoidapan", new { id = cauhoidapan.id }, cauhoidapan);
        }

        // DELETE: api/cauhoidapans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecauhoidapan(int id)
        {
            var cauhoidapan = await _context.cauhoidapan.FindAsync(id);
            if (cauhoidapan == null)
            {
                return NotFound();
            }

            _context.cauhoidapan.Remove(cauhoidapan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool cauhoidapanExists(int id)
        {
            return _context.cauhoidapan.Any(e => e.id == id);
        }
    }
}
