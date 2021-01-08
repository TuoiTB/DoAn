using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{   [Table ("HangPhong")]
    public class HangPhong
    {   
        [Key]
        public int Id { get; set; }
        public string TenHangPhong { get; set; }
        public bool TrangThai { get; set; }
    }
}
