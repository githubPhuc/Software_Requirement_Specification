using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Software_Requirement_Specification.Models
{
    public class TaiKhoan
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Tên người dùng")]
        public string TenNguoiDung { get; set; }
        [Display(Name ="Mật khẩu")]
        public string MatKhau { get; set; }
        [Display(Name ="Gmail người dùng")]
        public string Gmail { get; set; }
        [Display(Name ="Số điện thoại")]
        public string SoDienThoai { get; set; }
        [Display(Name ="Quyền tài khoản")]
        public int idQuyen { get; set; }
        public PhanQuyen QuyenID { get; set; }
        public bool TrangThai { get; set; }
        public List<VaiTro> vaiTro { get; set; }
    }
}