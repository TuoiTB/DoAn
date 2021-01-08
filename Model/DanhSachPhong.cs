using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("DanhSachPhong")]
    public class DanhSachPhong
    {
        [Key]
        public int Id { get; set; }
        public int SoPhong { get; set; }
        public int NhomPhong_id { get; set; }
        public bool TrangThai { get; set; }
    }
}
