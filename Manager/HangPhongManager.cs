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
    public interface IHangPhongManager
    {
        Task<HangPhong> Create(HangPhong inputModel);
        Task Update(HangPhong inputModel);
        Task Delete(int Id);
        Task<HangPhong> Find_By_Id(int Id);
        Task<HangPhong> Find_By_Name(string inputName);
        Task<List<HangPhong>> Look_up();
        Task<List<HangPhong>> Get_List(string name="", int status=1, int pageSize=10, int pageNumber=1);
    }
    public class HangPhongManager : IHangPhongManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HangPhong> _logger;
        public HangPhongManager(IUnitOfWork unitOfWork, ILogger<HangPhong> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<HangPhong> Create(HangPhong inputModel)
        {
            try
            {
                var result = await _unitOfWork.HangPhongRepository.Add(inputModel);
                await _unitOfWork.SaveChange();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(HangPhong inputModel)
        {
            try
            {
                await _unitOfWork.HangPhongRepository.Update(inputModel);
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
            var item = await _unitOfWork.HangPhongRepository.Get(c => c.Id == Id);

            await _unitOfWork.HangPhongRepository.Update(item);
            await _unitOfWork.SaveChange();
        }

        public async Task<HangPhong> Find_By_Id(int Id)
        {
            //return await _unitOfWork.HangPhongRepository.Get(c => c.Id == Id);
            var item = (await _unitOfWork.HangPhongRepository.FindBy(c => c.Id == Id)).ToList().FirstOrDefault();
            return item;// _unitOfWork.KieuGiuongRepository.Get(c => c.Id == id);
        }

        public async Task<HangPhong> Find_By_Name(string inputName)
        {
            return await _unitOfWork.HangPhongRepository.Get(c => c.TenHangPhong.ToLower() == inputName.Trim().ToLower());
        }

        public async Task<List<HangPhong>> Get_List(string name = "", int status = 1, int pageSize = 10, int pageNumber = 1)
        {
            try
            {
                var data = (await _unitOfWork.HangPhongRepository.FindBy(x => x.TrangThai == true)).ToList();
                return (List<HangPhong>)data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<HangPhong>> Look_up()
        {
            try
            {
                var data = (await _unitOfWork.HangPhongRepository.GetAll()).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
