using Data;
using Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Repository
{
    public interface IHangPhongRepository : IRepository<HangPhong>
    {

    }
    public class HangPhongRepository : Repository<HangPhong>, IHangPhongRepository
    {
        public HangPhongRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}