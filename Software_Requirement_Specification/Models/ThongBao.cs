using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class ThongBao
    {
        [Key]
        public int Id { get; set; }
        public string LoaiThongBao { get; set; }
        public int LoaiLopHocId { get; set; }
        public LoaiLopHoc loaiLopHoc { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung nguoiDung { get; set; }
        public string ChuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime ThoiGian { get; set; }

    }
}
