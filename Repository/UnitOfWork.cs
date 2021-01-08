using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Portal.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Data;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        
        public IDanhSachPhongRepository DanhSachPhongRepository { get; }
        public IDuThuyenRepository DuThuyenRepository { get; }
        public IHangPhongRepository HangPhongRepository { get; }
        public IKhachHangRepository KhachHangRepository { get; }
        public IKieuGiuongRepository KieuGiuongRepository { get; }
        public INhomPhongRepository NhomPhongRepository { get; }
        public IPhieuDatChiTietRepository PhieuDatChiTietRepository { get; }
        public IPhieuDatPhongRepository PhieuDatPhongRepository { get; }

        Task CreateTransaction();
        Task Commit();
        Task Rollback();
        Task SaveChange();
    }
    public class UnitOfWork : IUnitOfWork
    {
        DbContext _dbContext;
        IDbContextTransaction _transaction;

        public UnitOfWork(IDbContextFactory<DoAnDbContext> dbContextFactory, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {//2
            _dbContext = dbContextFactory.GetContext();
            DanhSachPhongRepository = new DanhSachPhongRepository(_dbContext);
            DuThuyenRepository = new DuThuyenRepository(_dbContext);
            HangPhongRepository = new HangPhongRepository(_dbContext);
            KhachHangRepository = new KhachHangRepository(_dbContext);
            KieuGiuongRepository = new KieuGiuongRepository(_dbContext);
            NhomPhongRepository = new NhomPhongRepository(_dbContext);
            PhieuDatChiTietRepository = new PhieuDatChiTietRepository(_dbContext);
            PhieuDatPhongRepository = new PhieuDatPhongRepository(_dbContext);
        }
        #region Transaction
        public async Task CreateTransaction()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public async Task SaveChange()
        {
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        private bool disposedValue = false; // To detect redundant calls
        //3
        public IDanhSachPhongRepository DanhSachPhongRepository { get; }
        public IDuThuyenRepository DuThuyenRepository { get; }
        public IHangPhongRepository HangPhongRepository { get; }
        public IKhachHangRepository KhachHangRepository { get; }
        public IKieuGiuongRepository KieuGiuongRepository { get; }
        public INhomPhongRepository NhomPhongRepository { get; }
        public IPhieuDatChiTietRepository PhieuDatChiTietRepository { get; }
        public IPhieuDatPhongRepository PhieuDatPhongRepository { get; }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
