using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{   [Table ("NhomPhong")]
    public class NhomPhong
    {   [Key]
        public int Id { get; set; }
        public int HangPhong_id { get; set; }
        public int KieuGiuong_id { get; set; }
        public int DuThuyen_id { get; set; }
        public string TenNhomPhong { get; set; }
        public int Gia { get; set; }
        public bool TrangThai { get; set; }
    }
}
