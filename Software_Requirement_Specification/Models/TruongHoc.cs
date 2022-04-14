using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class TruongHoc
    {
        [Key]
        public int Id { get; set; }
        public string TenTruong { get; set; }
        public string TenThuVien { get; set; }
        public string HieuTruong { get; set; }
        public string WebSite { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public bool TrangThai { get; set; }
        public List<LopHoc> lopHocs { get; set; }
    }
}
