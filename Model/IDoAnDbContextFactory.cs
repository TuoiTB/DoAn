using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Microsoft.EntityFrameworkCore;
namespace Models
{
    public interface IDoAnDbContextFactory : IDbContextFactory<DoAnDbContext>
    {

    }
    public class DoAnDbContextFactory : IDoAnDbContextFactory
    {
        private readonly DbContextOptions<DoAnDbContext> _options;
        private DoAnDbContext _context;
        public DoAnDbContextFactory(DbContextOptions<DoAnDbContext> options)
        {
            _options = options;
        }
        public DoAnDbContext GetContext()
        {
            if (_context == null) _context = new DoAnDbContext(_options);
            return _context;
        }
    }
}
