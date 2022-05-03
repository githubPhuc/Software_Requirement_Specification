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
    public class MonHocsController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public MonHocsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        //GET: api/MonHocs
       [HttpGet]
       [Route("Xemmonhoc")]
        public async Task<ActionResult<IEnumerable<MonHoc>>> GetMonHoc()
        {
            return await _context.MonHoc.ToListAsync();
        }
        [HttpGet]
        [Route("xemtailieumonhoc/{id}")]
        public ActionResult xemTaiLieumonHoc(int id)
        {
            var data = (from a in _context.NguoiDung
                        join b in _context.MonHoc on a.Id equals b.nguoiDungId
                        join c in _context.TaiLieu on b.Id equals c.monhocId
                        where b.Id == id && a.VaiTro.idQuyen == 1
                        select new
                        {
                            b.Id,
                            b.TenMonHoc,
                            sotailieuchoduyet = (_context.TaiLieu.Where(x => x.PheDuyet == false)).Count(),
                            a.Ten,
                            c.TinhTrang,
                            c.NgayGuiPheDuyet
                        }) ;
            return Ok(data);
        }
        [HttpGet]
        [Route("timkiemmonhoc/{data}")]
        public async Task<ActionResult<IEnumerable<MonHoc>>> SearchMonHoc(string data)//Tên môn học
        {
            var monHoc = await _context.MonHoc.Where(m => m.TenMonHoc.Contains(data)).ToListAsync();

            if (monHoc == null)
            {
                return NotFound();
            }

            return monHoc;
        }
        [HttpGet]
        [Route("timkiemmonhoctheolop/{data}")]
        public async Task<ActionResult<IEnumerable<MonHoc>>> SearchMonHoctheolop(string data)//Tên môn học
        {
            var monHoc = await _context.MonHoc.Where(m => m.lopHocId.TenLop.Contains(data)).ToListAsync();

            if (monHoc == null)
            {
                return NotFound();
            }

            return monHoc;
        }
        [HttpGet]
        [Route("Xemchitietmonhoc/{id}")]
        public ActionResult xemChiTietMonHoc(int id)
        {
            var data = (from d in _context.NguoiDung
                        join a in _context.MonHoc on d.Id equals a.nguoiDungId
                        where a.Id == id
                        select new
                        {
                            a.Id,
                            d.Ten,
                            a.TenMonHoc,
                            a.MoTa
                        }).ToList();
            return Ok(data);

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
        public async Task<IActionResult> PutMonHoc(int id, [FromBody] MonHoc monHoc)
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
