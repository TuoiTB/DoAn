using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Models;
using Repository;
using Manager;
using Data;

namespace DependencyInjection
{
    public class IOCConfig
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            // Db
            services.AddDbContext<DoAnDbContext>(ServiceLifetime.Scoped, ServiceLifetime.Singleton);
            services.AddTransient<IDbContextFactory<DoAnDbContext>, DoAnDbContextFactory>();
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            //services.AddTransient<ITacGiaManager, TacGiaManager>();
            services.AddTransient<IDanhSachPhongManager, DanhSachPhongManager>();
            services.AddTransient<IDuThuyenManager, DuThuyenManager>();
            services.AddTransient<IHangPhongManager, HangPhongManager>();
            services.AddTransient<IKhachHangManager, KhachHangManager>();
            services.AddTransient<IKieuGiuongManager, KieuGiuongManager>();
            services.AddTransient<INhomPhongManager, NhomPhongManager>();
            services.AddTransient<IPhieuDatChiTietManager, PhieuDatChiTietManager>();
            services.AddTransient<IPhieuDatPhongManager, PhieuDatPhongManager>();
        }
    }
}
