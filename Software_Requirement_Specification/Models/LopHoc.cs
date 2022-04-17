using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Software_Requirement_Specification.Models
{
    public class LopHoc
    {
        //1 lớp học có nhiều học sinh
        //1 lớp học có nhiều môn học 
        //Trần Ninh phúc
        //Khởi tạo 2:41 12/4/2022
        [Key]
        public int Id { get; set; }
        public string TenLop { get; set; }
        public string NienKhoa { get; set; }
        public int idtruong { get; set; }
        public TruongHoc TruongID { get; set; }
        public List<MonHoc> monHocs { get; set; }
    }
}
