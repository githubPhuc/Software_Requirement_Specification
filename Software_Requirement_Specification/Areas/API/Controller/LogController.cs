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
        //public async Task<ActionResult<IEnumerable<TaiKhoan>>> login(string taikhoan, string matkhau)
        [Route("dangnhap")]
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
            //else
            //{
            //    var url = Url.RouteUrl("areas", new { controller = "sanphams", action = "index", area = "Admin" });
            //    return Redirect(url);

            //}
            return "Đăng nhập thất bại chuyển sang lấy lại mật khẩu";

        }
        [HttpGet]
        [Route("dangxuat")]
        public async Task<string> dangxuat()
        {
            HttpContext.Session.Clear();
            return "Dang xuat thanh cong";  //chuyen sang login
        }

        [HttpPost]
        //xác nhận mail
        public async Task<string> guiMailMaCode(string mail,string sdt)
        {
            var kt =await _context.TaiKhoan.Where(a => a.Gmail == mail && a.SoDienThoai == sdt).ToListAsync();
            if (kt.Count() > 0)
            {
                string data = "";
                Random rd = new Random();
                for (int i = 0; i < 6; i++)
                {
                    data += rd.Next(9);
                }
                HttpContext.Session.SetString("maCode",data);
                HttpContext.Session.SetString("Gmail", mail);
                HttpContext.Session.SetString("Sdt", sdt);
                string mailGui = "ptranninh@gmail.com";
                string mkMailGui = "tranninhphuc@1061";
                string NoiDung = "Mã xác nhận";
                var mesage = await MailUtils.MailUtils.SendGmail(mailGui,//mail người gửi
                                                                    mailGui,//mail người nhận
                                                                    NoiDung,
                                                                    data,
                                                                    mailGui,
                                                                    mkMailGui);
                return mesage;
            }
            return "không tìm thấy mail và số điện thoại";
        }
        [HttpGet]
        public async Task<string> XacThucOTP(string otp)
        {
            string ss = HttpContext.Session.GetString("maCode");
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("maCode")))
            {
                return "Dang nhap lai";
            }
            else
            if (otp == HttpContext.Session.GetString("maCode"))
            {
                HttpContext.Session.SetInt32("XacThuc", 1);
                HttpContext.Session.Remove("OTP");
                return "Xac thuc thanh cong"; //chuyen sang doi mat khau
            }
            else
            {
                string a = await guiMailMaCode(HttpContext.Session.GetString("Gmail"), HttpContext.Session.GetString("Sdt"));
                return "Da gui lai ma xac thuc";
            }
        }

    }
}
