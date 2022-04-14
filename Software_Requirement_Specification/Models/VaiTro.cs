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
        [Display(Name ="Tên người dùng")]
        public int NguoiDung { get; set; }
        [Display(Name = "Tên vai trò")]
        public string TenVaiTro { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "MonHoc")]
        public MonHoc MonHoc { get; set; }

        public Tep TepRiengTu { get; set; }

        public TaiLieu TaiNguyen { get; set; }

        public DeThi De { get; set; }

        public string ThongBao { get; set; }
        public TaiKhoan taiKhoan { get; set; }
    }
}
