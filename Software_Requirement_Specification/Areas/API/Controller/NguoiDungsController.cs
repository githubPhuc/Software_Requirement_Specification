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
    public class NguoiDungsController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public NguoiDungsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/NguoiDungs
        [HttpGet]
        [Route("xemnguoidung")]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> xemNguoiDung()
        {
            return await _context.NguoiDung.ToListAsync();
        }

        [HttpGet]
        [Route("xemvaitronguoidung/{id}")]
        public IActionResult xemVaiTro(int id)
        {
            var vaitro = (from a in _context.NguoiDung
                          join b in _context.VaiTro on a.VaitroId equals b.Id
                          where a.Id == id
                          select new
                          {
                              a.Id,
                              a.Ten,
                              a.Email,
                              b.TenVaiTro
                          }).ToList();

            return Ok(vaitro);
        }
        [HttpGet("{id}")]
        [Route("locnguoidung/{id}")]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> LocNguoiDung(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var result = await _context.NguoiDung.Where(v => v.VaitroId == id).ToListAsync();
            if (result != null)
                return result;
            else
                return NotFound();
        }
        [HttpGet]
        [Route("timkiemmonday/{id}")]
        public ActionResult timKiemMonGiangDay(int id)// Người dùng tìm kiếm môn học 
        {
            var data = (from a in _context.MonHoc
                        join b in _context.NguoiDung on a.nguoiDungId equals b.Id
                        join c in _context.PhanQuyen on b.TaiKhoan.Id equals c.Id
                        where c.TenQuyen == "Giáo Viên" && b.Id == id
                        select new
                        {
                            a.Id,
                            a.TenMonHoc,
                            b.Ten,
                            a.MoTa

                        }).ToList();
            return Ok(data);
        }
        // GET: api/NguoiDungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NguoiDung>> xemChiTiet(int id)
        {
            var nguoiDung = await _context.NguoiDung.FindAsync(id);

            if (nguoiDung == null)
            {
                return NotFound();
            }

            return nguoiDung;
        }

        // PUT: api/NguoiDungs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> chinhSuaNguoiDung(int id, [FromBody] NguoiDung nguoiDung)
        {
            if (id != nguoiDung.Id)
            {
                return BadRequest();
            }

            _context.Entry(nguoiDung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDungExists(id))
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

        // POST: api/NguoiDungs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NguoiDung>> themNguoiDung([FromBody] NguoiDung nguoiDung)
        {
            _context.NguoiDung.Add(nguoiDung);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNguoiDung", new { id = nguoiDung.Id }, nguoiDung);
        }

        // DELETE: api/NguoiDungs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> xoaNguoiDung(int id)
        {
            var nguoiDung = await _context.NguoiDung.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            _context.NguoiDung.Remove(nguoiDung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NguoiDungExists(int id)
        {
            return _context.NguoiDung.Any(e => e.Id == id);
        }
    }
}
