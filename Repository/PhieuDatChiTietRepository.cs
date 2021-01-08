using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public interface IPhieuDatChiTietRepository : IRepository<PhieuDatChiTiet>
    {

    }
    public class PhieuDatChiTietRepository : Repository<PhieuDatChiTiet>, IPhieuDatChiTietRepository
    {
        public PhieuDatChiTietRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}