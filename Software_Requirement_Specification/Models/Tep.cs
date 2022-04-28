﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Software_Requirement_Specification.Models
{
    public class Tep
    {
        //1 trường học có nhiều lớp học
        //Trần Ninh phúc
        //Khởi tạo 2:00 13/4/2022
        public int Id { get; set; }
        public string TenTep { get; set; }
        public string TheLoai { get; set; }
        public int NguoiChinhSua { get; set; }
        public DateTime NgaySuaCuoi { get; set; }
        public string File { get; set; }
        public int KichThuoc { get; set; }
        [NotMapped]
        public IFormFile FileTep { get; set; }
        public TaiLieu TaiLieu { get; set; }
        public DeThi DeThi { get; set; }
    }
}