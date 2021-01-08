using Data;
using Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Repository
{
    public interface IDuThuyenRepository : IRepository<DuThuyen>
    {

    }
    public class DuThuyenRepository : Repository<DuThuyen>, IDuThuyenRepository
    {
        public DuThuyenRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}