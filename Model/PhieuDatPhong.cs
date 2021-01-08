using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace Models
{   [Table ("PhieuDatPhong") ]
    public class PhieuDatPhong
    {   [Key]
        public int Id { get; set; }
        public int KhachHang_id { get; set; }
        public int MaPhieu { get; set; }
        public DateTime NgayDat { get; set; }
        public string TinhTrang { get; set; }
        public bool DatCoc { get; set; }
        public int GiaDatCoc { get; set; }
    }
}
