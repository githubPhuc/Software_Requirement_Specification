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
        public MonHoc MonHocID { get; set; }
        public int SoTaiLieuChoDuyet { get; set; }
        public DateTime NgayGuiPheDuyet { get; set; }
        public bool TinhTrang { get; set; }
    }
}
