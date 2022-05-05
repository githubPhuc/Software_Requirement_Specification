using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BaiGiangsController(Software_Requirement_SpecificationContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/BaiGiangs
        [HttpGet]
        [Route("xembaigiang")]
        public async Task<ActionResult<IEnumerable<BaiGiang>>> GetBaiGiang()
        {
            return await _context.BaiGiang.ToListAsync();
        }
        [HttpGet]
        [Route("locbaigiang/{monhoc}")]
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
        [HttpGet("{id}")]
        [Route("xemchitiet/{id}")]
        public async Task<ActionResult<BaiGiang>> GetBaiGiang(int id)
        {
            var baiGiang = await _context.BaiGiang.FindAsync(id);

            if (baiGiang == null)
            {
                return NotFound();
            }

            return baiGiang;
        }

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
        [Route("thembaigiang")]
        public async Task<ActionResult> PostBaiGiang( string tenbaigiang, int idmh, IFormFile formFile)
        {
            BaiGiang baiGiang = new BaiGiang();
            ThongBao thongBao = new ThongBao();
            Tep tep = new Tep();
            if (ModelState.IsValid)
            {
                baiGiang.MonHocId = idmh;
                _context.BaiGiang.Add(baiGiang);
                await _context.SaveChangesAsync();
                _context.Tep.Add(tep);
                await _context.SaveChangesAsync();
                if (formFile != null)
                {
                    var extens = Path.GetExtension(formFile.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "file");
                    var filePath = Path.Combine(uploadPath, formFile.FileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        formFile.CopyTo(fs);
                        fs.Flush();
                    }
                    tep.TheLoai = extens;
                    tep.TenTep = formFile.FileName;
                    tep.KichThuoc = Convert.ToInt32(formFile.Length);
                    tep.NgaySuaCuoi = DateTime.Now;
                    _context.Tep.Update(tep);
                    await _context.SaveChangesAsync();
                }
                baiGiang.idTep = tep.Id;
                baiGiang.PheDuyet = false;
                baiGiang.tenBaiGiang = tenbaigiang;
                _context.Update(baiGiang);
                thongBao.idQuyen = 2;
                thongBao.ChuDe = "Thông báo người dùng";
                thongBao.NoiDung = "Giáo viên đả thêm mới bài giảng "+ baiGiang.tenBaiGiang;
                thongBao.ThoiGian = DateTime.Now;
                _context.ThongBao.Add(thongBao);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetBaiGiang", new { id = baiGiang.Id }, baiGiang);
        }

        // DELETE: api/BaiGiangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaiGiang(int id)
        {
            var baiGiang = await _context.BaiGiang.FindAsync(id);
            if (baiGiang != null)
            {
                int idbg = baiGiang.idTep;
                var tep = await _context.Tep.FindAsync(idbg);
                if (tep == null)
                {
                    return NotFound();
                }
                var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "file", tep.TenTep);
                FileInfo file = new FileInfo(fileToDelete);
                file.Delete();
                string name = baiGiang.tenBaiGiang;
                _context.Tep.Remove(tep);
                _context.BaiGiang.Remove(baiGiang);
                ThongBao thongBao = new ThongBao();
                thongBao.idQuyen = 2;
                thongBao.LoaiThongBao = "Thông báo người dùng";
                thongBao.ChuDe = "Thông báo học sinh";
                thongBao.NoiDung = "Bài giảng " + name + " đả được xóa";
                thongBao.ThoiGian = DateTime.Now;
                _context.Add(thongBao);
                
                await _context.SaveChangesAsync();
                return Content("Xóa thành công");
            }
            else
            {
                return Content("không có bài giảng");
            }

            
        }

        private bool BaiGiangExists(int id)
        {
            return _context.BaiGiang.Any(e => e.Id == id);
        }
    }
}
