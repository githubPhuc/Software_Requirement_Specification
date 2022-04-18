using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Data;
using Software_Requirement_Specification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Software_Requirement_Specification.Areas.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public LogController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }
        // GET: api/<LogController>
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<TaiKhoan>>> login(string taikhoan,string matkhau)
        public string login(string taikhoan, string matkhau)
        {
            var db = _context.TaiKhoan.Where(a => a.TenNguoiDung.Equals(taikhoan) && a.MatKhau.Equals(matkhau)).ToList();
            if (db.Count() > 0)
            {
                var quyen = _context.PhanQuyen.Where(d => d.Id.Equals(db[0].idQuyen)).FirstOrDefault();
                HttpContext.Session.SetString("tenDangnhap", db.FirstOrDefault().TenNguoiDung);
                HttpContext.Session.SetInt32("id", db.FirstOrDefault().Id);
                if (db[0].idQuyen == 1)
                {
                    string name = db[0].TenNguoiDung;
                    name = name + " đăng nhập thành công với quyền " + quyen.TenQuyen;
                    return name;
                }
                if (db[0].idQuyen == 2)
                {
                    string name = db[0].TenNguoiDung;
                    name = name + " đăng nhập thành công với quyền " + quyen.TenQuyen;
                    return name;
                }
                if (db[0].idQuyen == 3)
                {
                    string name = db[0].TenNguoiDung;
                    name = name + " đăng nhập thành công với quyền " + quyen.TenQuyen;
                    return name;
                }
            }
            else
            {
                //var url = Url.RouteUrl("areas", new { controller = "sanphams", action = "index", area = "Admin" });
                //return Redirect(url);

            }
            return "Đăng nhập thất bại chuyển sang lấy lại mật khẩu";

        }
        public string maCode = "";
        [HttpPost]
        //xác nhận mail
        public async Task<string> guiMailMaCode()
        {
            
            Random rd = new Random();
            for(int i = 0; i < 6; i++)
            {
                maCode += rd.Next(9);
            }
            var mesage = await MailUtils.MailUtils.SendGmail("ptranninh@gmail.com",
                                                                "ptranninh@gmail.com",
                                                                "Mã xác nhận",
                                                                maCode,
                                                                "ptranninh@gmail.com",
                                                                "tranninhphuc@1061");
            return mesage;
        }
        
       
    }
}
