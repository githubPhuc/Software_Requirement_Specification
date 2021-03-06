using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class TaiLieu
    {
        //nhiều tài liệu cho 1 môn học  
        //Trần Ninh phúc
        //Khởi tạo 2:41 13/4/2022
        [Key]
        public int Id { get; set; }
        public string tentailieu { get; set; }
        public int monhocId { get; set; }
        public MonHoc monHoc { get; set; }
        [Display(Name = "Phê duyệt")]
        public bool PheDuyet { get; set; }
        public DateTime NgayGuiPheDuyet { get; set; }
        public int idNguoiDung { get; set; }
        public NguoiDung nguoiDung { get; set; }
        public bool TinhTrang { get; set; }
        public List<Tep> tep { get; set; }
    }
}
