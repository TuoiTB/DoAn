using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{  [Table ("KhachHang")]
    public class KhachHang
    {
        [Key]
        public int Id { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public int CMND { get; set; }
        public int SDT { get; set; }
        public bool TrangThai { get; set; }
    }
}
