using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Data;
using Software_Requirement_Specification.Models;

namespace Software_Requirement_Specification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TepsController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public TepsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/Teps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tep>>> GetTep()
        {
            return await _context.Tep.ToListAsync();
        }

        // GET: api/Teps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tep>> GetTep(int id)
        {
            var tep = await _context.Tep.FindAsync(id);

            if (tep == null)
            {
                return NotFound();
            }

            return tep;
        }

        // PUT: api/Teps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTep(int id, Tep tep)
        {
            if (id != tep.Id)
            {
                return BadRequest();
            }

            _context.Entry(tep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TepExists(id))
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

        // POST: api/Teps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tep>> PostTep(Tep tep)
        {
            _context.Tep.Add(tep);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTep", new { id = tep.Id }, tep);
        }

        // DELETE: api/Teps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTep(int id)
        {
            var tep = await _context.Tep.FindAsync(id);
            if (tep == null)
            {
                return NotFound();
            }

            _context.Tep.Remove(tep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TepExists(int id)
        {
            return _context.Tep.Any(e => e.Id == id);
        }
    }
}
