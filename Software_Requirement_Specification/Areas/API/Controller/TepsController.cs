using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Data;
using Software_Requirement_Specification.Models;

namespace Software_Requirement_Specification.Areas.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TepsController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; 
        private IHostingEnvironment Environment;
        public TepsController(Software_Requirement_SpecificationContext context, IWebHostEnvironment webHostEnvironment, IHostingEnvironment _environment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            Environment = _environment;
        }
        [HttpGet]
        [Route("loctep")]
        public async Task<ActionResult<IEnumerable<Tep>>> locDanhSachTep(string context)
        {
            if (string.IsNullOrEmpty(context))
            {
                return NotFound();
            }
            else
            {
                var data = await _context.Tep.Where(a => a.TheLoai.Contains(context)).ToListAsync();
                return data;
            }
        }

        // GET: api/Teps
        [HttpGet]
        [Route("xemtep")]
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
        //[HttpPut]
        //[Route("suatep")]
        //public async Task<IActionResult> PutTep(int id, [FromForm] Tep tep,IFormFile formFile)
        //{
        //    if (id != tep.Id)
        //    {
        //        return BadRequest();
        //    }
        //    if (formFile != null)
        //    {
        //        var data = await _context.Tep.FindAsync(id);
        //        var name =data.TenTep ;
        //        var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "file",  name);
        //        FileInfo file = new FileInfo(fileToDelete);
        //        file.Delete();
        //        var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "file");
        //        var filePath = Path.Combine(uploadPath, formFile.FileName);
        //        using (FileStream fs = System.IO.File.Create(filePath))
        //        {
        //            formFile.CopyTo(fs);
        //            fs.Flush();
        //        }
        //    }

        //    tep.TheLoai = Path.GetExtension(formFile.FileName);
        //    tep.TenTep = formFile.FileName;
        //    tep.KichThuoc = Convert.ToInt32(formFile.Length);
        //    tep.NgaySuaCuoi = DateTime.Now;
        //    tep.NguoiChinhSua = 1;
        //    _context.Entry(tep).State = EntityState.Modified;


        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TepExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}



        // POST: api/Teps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("themtep")]

        public async Task<ActionResult<Tep>> PostTep([FromForm] Tep tep, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
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
                    tep.NguoiChinhSua = 1;
                    _context.Tep.Update(tep);
                    await _context.SaveChangesAsync();
                }
                return CreatedAtAction("GetTep", new { id = tep.Id }, tep);
            }
            return NoContent();
        }
        //[HttpGet]
        //[Route("Download")]
        //public FileStreamResult DownloadFile(string fileName)
        //{
        //    //Determine the Content Type of the File.
        //    string contentType = "";
        //    new FileExtensionContentTypeProvider().TryGetContentType(fileName, out contentType);

        //    //Build the File Path.
        //    string path = Path.Combine(this.Environment.WebRootPath, "file/") + fileName;

        //    //Read the File data into FileStream.
        //    FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

        //    //Send the File to Download.
        //    return new FileStreamResult(fileStream, contentType);
        //}

        // DELETE: api/Teps/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTep(int id)
        {
            var tep = await _context.Tep.FindAsync(id);
            if (tep == null)
            {
                return NotFound();
            }
            var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "file",  tep.TenTep);
            FileInfo file = new FileInfo(fileToDelete);
            file.Delete();
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
