using Data;
using Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Repository
{
    public interface INhomPhongRepository : IRepository<NhomPhong>
    {

    }
    public class NhomPhongRepository : Repository<NhomPhong>, INhomPhongRepository
    {
        public NhomPhongRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}