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
        public string TenNguoiDung { get; set; }
        public string MatKhau { get; set; }
        public string Gmail { get; set; }
        public string SoDienThoai { get; set; }
        public int VaiTro { get; set; }
        public PhanQuyen QuyenID { get; set; }
        public bool TrangThai { get; set; }
    }
}