using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class cauhoidapan
    {
        [Key]
        public int id { get; set; }
        public int idDeThi { get; set; }
        public DeThi deThi { get; set; }
        public string cauHoi { get; set; }
        public string dapAnA { get; set; }
        public string dapAnB { get; set; }
        public string dapAnC { get; set; }
        public string dapAnD { get; set; }
        public string dapAn { get; set; }
        public bool trangthai { get; set; }

    }
}
