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
    public interface IDanhSachPhongManager
    {
        Task<DanhSachPhong> Create(DanhSachPhong inputModel);
        Task Update(DanhSachPhong inputModel);
        Task Delete(int id);
        Task<DanhSachPhong> Find_By_Id(int id);
        //Task<DanhSachPhong> Find_By_Name(string inputName);
        Task<List<DanhSachPhong>> Look_up();
        Task<List<DanhSachPhong>> Get_List(int SoPhong = 0, int status = 1, int pageSize = 10, int pageNumber = 1);
    }
    public class DanhSachPhongManager : IDanhSachPhongManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DanhSachPhong> _logger;
        public DanhSachPhongManager(IUnitOfWork unitOfWork, ILogger<DanhSachPhong> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<DanhSachPhong> Create(DanhSachPhong inputModel)
        {
            try
            {
                var result = await _unitOfWork.DanhSachPhongRepository.Add(inputModel);
                await _unitOfWork.SaveChange();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(DanhSachPhong inputModel)
        {
            try
            {
                await _unitOfWork.DanhSachPhongRepository.Update(inputModel);
                await _unitOfWork.SaveChange();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                throw ex;
            }
        }
        public async Task Delete(int id)
        {
            var item = (await _unitOfWork.DanhSachPhongRepository.FindBy(c => c.Id == id)).ToList().FirstOrDefault();

            await _unitOfWork.DanhSachPhongRepository.Update(item);
            await _unitOfWork.SaveChange();
        }

        public async Task<DanhSachPhong> Find_By_Id(int id)
        {
            var item = (await _unitOfWork.DanhSachPhongRepository.FindBy(c => c.Id == id)).ToList().FirstOrDefault();
            return item;// _unitOfWork.DanhSachPhongRepository.Get(c => c.Id == id);
        }

        //public async Task<DanhSachPhong> Find_By_Name(string inputName)
        //{
        //    return await _unitOfWork.DanhSachPhongRepository.Get(c => c.t.ToLower() == inputName.Trim().ToLower());
        //}

        public async Task<List<DanhSachPhong>> Get_List(int SoPhong=0, int status=1, int pageSize = 10, int pageNumber = 0)
        {
            try
            {
                var data = (await _unitOfWork.DanhSachPhongRepository.FindBy(x => x.TrangThai == true)).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DanhSachPhong>> Look_up()
        {
            try
            {
                var data = (await _unitOfWork.DanhSachPhongRepository.GetAll()).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
