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
    public class MonHocsController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public MonHocsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }
        //[Route("")]
        [HttpGet]
        public string TimKiemMonHoc(string ten)
        {
            //if (idtk == null)
            //{
            //    return NotFound();
            //}
            //var monHoc = (from a in _context.VaiTro
            //              join b in _context.MonHoc on a.MaNguoiDung equals b.maNguoiDung
            //              where a.IdTaiKhoan == idtk
            //              join c in _context.LopHoc on b.idLopHoc equals c.Id
            //              select new
            //              {
            //                  STT = b.Id,
            //                  TenMonHoc = b.TenMonHoc,
            //                  Lop = c.TenLop,
            //                  vaitro = a.TenVaiTro,

            //              }).ToList();

            //return (IActionResult)monHoc;
            return "tìm kiếm môn học"+ten;

        }

        // GET: api/MonHocs
        [HttpGet]

        public async Task<ActionResult<IEnumerable<MonHoc>>> GetMonHoc()
        {
            return await _context.MonHoc.ToListAsync();
        }

        // GET: api/MonHocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonHoc>> GetMonHoc(int id)
        {
            var monHoc = await _context.MonHoc.FindAsync(id);

            if (monHoc == null)
            {
                return NotFound();
            }

            return monHoc;
        }

        // PUT: api/MonHocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonHoc( int id, [FromBody] MonHoc monHoc)
        {
            if (id != monHoc.Id)
            {
                return BadRequest();
            }

            _context.Entry(monHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonHocExists(id))
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

        // POST: api/MonHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Api/MonHocs")]
        public async Task<ActionResult<MonHoc>> PostMonHoc([FromBody] MonHoc monHoc)
        {
            _context.MonHoc.Add(monHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonHoc", new { id = monHoc.Id }, monHoc);
        }

        // DELETE: api/MonHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonHoc(int id)
        {
            var monHoc = await _context.MonHoc.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }

            _context.MonHoc.Remove(monHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonHocExists(int id)
        {
            return _context.MonHoc.Any(e => e.Id == id);
        }
    }
}
