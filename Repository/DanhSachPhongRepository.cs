using Data;
using Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Repository
{
    public interface IDanhSachPhongRepository : IRepository<DanhSachPhong>
    {

    }
    public class DanhSachPhongRepository : Repository<DanhSachPhong>, IDanhSachPhongRepository
    {
        public DanhSachPhongRepository(DbContext dbContext) : base(dbContext)
        {
    
        }
    }
}
