using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class DeThi
    {
        //1 môn học có nhiều đề thi
        //1 đề thi do 1 giáo viên cung cấp
        //Trần Ninh phúc
        //Khởi tạo 2:41 12/4/2022
        [Key]
        public int Id { get; set; }
        [Display(Name = "Môn học")]
        public MonHoc monHocId { get; set; }
        
        [Display(Name = "Hình thức thi")]
        public string HinhThuc { get; set; }

        public Tep tepId { get; set; }
        [Display(Name = "Thời Lượng thi")]
        public int ThoiLuong { get; set; }
        [Display(Name = "Ngày Tạo")]
        public DateTime NgayTao { get; set; }
        [Display(Name = "Tình Trạng")]
        public bool TinhTrang { get; set; }
        [Display(Name = "Người phê duyệt")]
        public int NguoiPheDuyet { get; set; }
        [Display(Name = "Phê duyệt")]
        public bool PheDuyet { get; set; }
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
        public List<Tep> teps { get; set; }
    }
}
