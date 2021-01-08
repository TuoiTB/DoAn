using Microsoft.Extensions.Logging;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public interface IPhieuDatChiTietManager
    {
        Task<PhieuDatChiTiet> Create(PhieuDatChiTiet inputModel);
        Task Update(PhieuDatChiTiet inputModel);
        Task Delete(long id);
        Task<PhieuDatChiTiet> Find_By_Id(long id);
        //Task<PhieuDatChiTiet> Find_By_Name(string inputName);
        Task<List<PhieuDatChiTiet>> Look_up();
        Task<List<PhieuDatChiTiet>> Get_List(int SoPhong, int status, int pageSize, int pageNumber);
    }
    public class PhieuDatChiTietManager : IPhieuDatChiTietManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PhieuDatChiTiet> _logger;
        public PhieuDatChiTietManager(IUnitOfWork unitOfWork, ILogger<PhieuDatChiTiet> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PhieuDatChiTiet> Create(PhieuDatChiTiet inputModel)
        {
            try
            {
                var result = await _unitOfWork.PhieuDatChiTietRepository.Add(inputModel);
                await _unitOfWork.SaveChange();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(PhieuDatChiTiet inputModel)
        {
            try
            {
                await _unitOfWork.PhieuDatChiTietRepository.Update(inputModel);
                await _unitOfWork.SaveChange();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                throw ex;
            }
        }
        public async Task Delete(long id)
        {
            var item = await _unitOfWork.PhieuDatChiTietRepository.Get(c => c.Id == id);

            await _unitOfWork.PhieuDatChiTietRepository.Update(item);
            await _unitOfWork.SaveChange();
        }

        public async Task<PhieuDatChiTiet> Find_By_Id(long id)
        {
            var item = (await _unitOfWork.PhieuDatChiTietRepository.FindBy(c => c.Id == id)).ToList().FirstOrDefault();
            return item;
        }

        //public async Task<PhieuDatChiTiet> Find_By_Name(string inputName)
        //{
        //    return await _unitOfWork.PhieuDatChiTietRepository.Get(c => c.t.ToLower() == inputName.Trim().ToLower());
        //}

        public async Task<List<PhieuDatChiTiet>> Get_List(int SoPhong, int status, int pageSize = 10, int pageNumber = 0)
        {
            try
            {
                var data = (await _unitOfWork.PhieuDatChiTietRepository.GetAll()).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PhieuDatChiTiet>> Look_up()
        {
            try
            {
                var data = (await _unitOfWork.PhieuDatChiTietRepository.GetAll()).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
