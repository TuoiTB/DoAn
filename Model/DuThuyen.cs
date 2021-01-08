using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{   [Table ("DuThuyen")]
    public class DuThuyen
    {
        [Key]
        public int Id { get; set; }
        public string BienKiemSoat { get; set; }
        public string TenDuThuyen { get; set; }
        public string MaDuThuyen { get; set; }
        public string Mota { get; set; }
        public bool TrangThai { get; set; }
    }
}
