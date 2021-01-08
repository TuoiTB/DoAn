using Data;
using Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPhieuDatPhongRepository : IRepository<PhieuDatPhong>
    {

    }
    public class PhieuDatPhongRepository : Repository<PhieuDatPhong>, IPhieuDatPhongRepository
    {
        public PhieuDatPhongRepository(DbContext dbContext) : base(dbContext)
        {

        }

        
    }
}