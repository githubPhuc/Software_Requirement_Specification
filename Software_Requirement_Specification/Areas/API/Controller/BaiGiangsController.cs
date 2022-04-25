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
    public class BaiGiangsController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public BaiGiangsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/BaiGiangs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<BaiGiang>>> GetBaiGiang()
        //{
        //    return await _context.BaiGiang.ToListAsync();
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaiGiang>>> LocBaiGiang(int monhoc)
        {
            var result = await _context.BaiGiang.ToListAsync();
            if (monhoc != 0)
            {
                result = await _context.BaiGiang.Where(b => b.MonHocId == monhoc).ToListAsync();
            }
            return result;
        }

        // GET: api/BaiGiangs/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<BaiGiang>> GetBaiGiang(int id)
        //{
        //    var baiGiang = await _context.BaiGiang.FindAsync(id);

        //    if (baiGiang == null)
        //    {
        //        return NotFound();
        //    }

        //    return baiGiang;
        //}

        // PUT: api/BaiGiangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaiGiang(int id, [FromBody] BaiGiang baiGiang)
        {
            if (id != baiGiang.Id)
            {
                return BadRequest();
            }

            _context.Entry(baiGiang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaiGiangExists(id))
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

        // POST: api/BaiGiangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaiGiang>> PostBaiGiang([FromBody] BaiGiang baiGiang)
        {
            _context.BaiGiang.Add(baiGiang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaiGiang", new { id = baiGiang.Id }, baiGiang);
        }

        // DELETE: api/BaiGiangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaiGiang(int id)
        {
            var baiGiang = await _context.BaiGiang.FindAsync(id);
            if (baiGiang == null)
            {
                return NotFound();
            }

            _context.BaiGiang.Remove(baiGiang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaiGiangExists(int id)
        {
            return _context.BaiGiang.Any(e => e.Id == id);
        }
    }
}
