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
    public interface IPhieuDatPhongManager
    {
        Task<PhieuDatPhong> Create(PhieuDatPhong inputModel);
        Task Update(PhieuDatPhong inputModel);
        Task Delete(long id);
        Task<PhieuDatPhong> Find_By_Id(long id);
        //Task<PhieuDatPhong> Find_By_Name(string inputName);
        Task<List<PhieuDatPhong>> Look_up();
        Task<List<PhieuDatPhong>> Get_List(int SoPhong, int status, int pageSize, int pageNumber);
    }
    public class PhieuDatPhongManager : IPhieuDatPhongManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PhieuDatPhong> _logger;
        public PhieuDatPhongManager(IUnitOfWork unitOfWork, ILogger<PhieuDatPhong> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PhieuDatPhong> Create(PhieuDatPhong inputModel)
        {
            try
            {
                var result = await _unitOfWork.PhieuDatPhongRepository.Add(inputModel);
                await _unitOfWork.SaveChange();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(PhieuDatPhong inputModel)
        {
            try
            {
                await _unitOfWork.PhieuDatPhongRepository.Update(inputModel);
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
            var item = await _unitOfWork.PhieuDatPhongRepository.Get(c => c.Id == id);

            await _unitOfWork.PhieuDatPhongRepository.Update(item);
            await _unitOfWork.SaveChange();
        }

        public async Task<PhieuDatPhong> Find_By_Id(long id)
        {
            var item = (await _unitOfWork.PhieuDatPhongRepository.FindBy(c => c.Id == id)).ToList().FirstOrDefault();
            return item;
        }

        //public async Task<PhieuDatPhong> Find_By_Name(string inputName)
        //{
        //    return await _unitOfWork.PhieuDatPhongRepository.Get(c => c.t.ToLower() == inputName.Trim().ToLower());
        //}

        public async Task<List<PhieuDatPhong>> Get_List(int SoPhong, int status, int pageSize = 10, int pageNumber = 0)
        {
            try
            {
                var data = (await _unitOfWork.PhieuDatPhongRepository.GetAll()).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PhieuDatPhong>> Look_up()
        {
            try
            {
                var data = (await _unitOfWork.PhieuDatPhongRepository.GetAll()).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
