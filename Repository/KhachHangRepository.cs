using Data;
using Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Repository
{
    public interface IKhachHangRepository : IRepository<KhachHang>
    {

    }
    public class KhachHangRepository : Repository<KhachHang>, IKhachHangRepository
    {
        public KhachHangRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}