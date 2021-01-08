using Data;
using Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Repository
{
    public interface IKieuGiuongRepository : IRepository<KieuGiuong>
    {

    }
    public class KieuGiuongRepository : Repository<KieuGiuong>, IKieuGiuongRepository
    {
        public KieuGiuongRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}