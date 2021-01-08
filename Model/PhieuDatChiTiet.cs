using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{   [Table ("PhieuDatChiTiet")]
    public class PhieuDatChiTiet
    {   [Key]
        public int Id { get; set; }
        public int Phieu_id { get; set; }
        public int NhomPhong_id { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
       
    }
}
