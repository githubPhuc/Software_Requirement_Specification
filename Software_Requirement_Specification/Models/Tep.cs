using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Software_Requirement_Specification.Models
{
    public class Tep
    {
        //1 trường học có nhiều lớp học
        //Trần Ninh phúc
        //Khởi tạo 2:00 13/4/2022
        [Key]
        public int Id { get; set; }
        public string LoaiFile { get; set; }
        public string TenTep { get; set; }
        public string NguoiChinhSua { get; set; }
        public DateTime NgaySuaLanCuoi { get; set; }
        public int KichThuoc { get; set; }
    }
}