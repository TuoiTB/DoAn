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
    public interface IDuThuyenManager
    {
        Task<DuThuyen> Create(DuThuyen inputModel);
        Task Update(DuThuyen inputModel);
        Task Delete(int Id);
        Task<DuThuyen> Find_By_Id(int Id);
        //Task<DuThuyen> Find_By_Name(string inputName);
        Task<List<DuThuyen>> Look_up();
        Task<List<DuThuyen>> Get_List(string BienKiemSoat="", int status=1, int pageSize=10, int pageNumber=1);
    }
    public class DuThuyenManager : IDuThuyenManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DuThuyen> _logger;
        public DuThuyenManager(IUnitOfWork unitOfWork, ILogger<DuThuyen> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<DuThuyen> Create(DuThuyen inputModel)
        {
            try
            {
                var result = await _unitOfWork.DuThuyenRepository.Add(inputModel);
                await _unitOfWork.SaveChange();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(DuThuyen inputModel)
        {
            try
            {
                await _unitOfWork.DuThuyenRepository.Update(inputModel);
                await _unitOfWork.SaveChange();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                throw ex;
            }
        }
        public async Task Delete(int Id)
        {
            var item = await _unitOfWork.DuThuyenRepository.Get(c => c.Id == Id);

            await _unitOfWork.DuThuyenRepository.Update(item);
            await _unitOfWork.SaveChange();
        }

        public async Task<DuThuyen> Find_By_Id(int Id)
        {
            var item = (await _unitOfWork.DuThuyenRepository.FindBy(c => c.Id == Id)).ToList();
            return item.FirstOrDefault();
        }

        //public async Task<DuThuyen> Find_By_Name(string inputName)
        //{
        //    return await _unitOfWork.DuThuyenRepository.Get(c => c.t.ToLower() == inputName.Trim().ToLower());
        //}

        public async Task<List<DuThuyen>> Get_List(string BienKiemSoat, int status=1, int pageSize = 10, int pageNumber = 0)
        {
            try
            {
                var data = (await _unitOfWork.DuThuyenRepository.FindBy(x=>x.TrangThai ==true)).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DuThuyen>> Look_up()
        {
            try
            {
                var data = (await _unitOfWork.DuThuyenRepository.GetAll()).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}

