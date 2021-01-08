using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Models
{   [Table ("KieuGiuong")]
    public class KieuGiuong
    {   [Key]
        public int Id { get; set; }
        public string TenKieuGiuong { get; set; }
        public bool TrangThai { get; set; }
    }
}
