
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Model;

namespace Models
{
    public class DoAnDbContext : DbContext
    {
        private static readonly MethodInfo _propertyMethod = typeof(EF).GetMethod(nameof(EF.Property), BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeof(bool));
        public DoAnDbContext(DbContextOptions<DoAnDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.HasDefaultSchema("orcl");
        }
        public DbSet<DanhSachPhong> DanhSachPhong { get; set; } //đôir dong nay
        public DbSet<DuThuyen> DuThuyen { get; set; }
        public DbSet<HangPhong> HangPhong { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<KieuGiuong> KieuGiuong { get; set; }
        public DbSet<NhomPhong> NhomPhong { get; set; }
        public DbSet<PhieuDatChiTiet> PhieuDatChiTiet { get; set; }
        public DbSet<PhieuDatPhong> PhieuDatPhong { get; set; }
    } 
}
