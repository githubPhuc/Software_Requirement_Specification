using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class VaiTro
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Mã người dùng")]
        public string MaNguoiDung { get; set; }
        [Display(Name ="Tên người dùng")]
        public string NguoiDung { get; set; }
        [Display(Name = "Tên vai trò")]
        public string TenVaiTro { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        public int IdTaiKhoan { get; set; }
        public string ThongBao { get; set; }
        public TaiKhoan taikhoan { get; set; }
        public Tep TepRiengTu { get; set; }
        public List<MonHoc> monHocs { get; set; }
        public List<DeThi> De { get; set; }

    }
}
