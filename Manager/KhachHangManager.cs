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
    public interface IKhachHangManager
    {
        Task<KhachHang> Create(KhachHang inputModel);
        Task Update(KhachHang inputModel);
        Task Delete(int id);
        Task<KhachHang> Find_By_Id(int id);
        Task<KhachHang> Find_By_Name(string inputName);
        Task<List<KhachHang>> Look_up();
        Task<List<KhachHang>> Get_List(string name = "", int status = 1, int pageSize=10, int pageNumber=1);
    }
    public class KhachHangManager : IKhachHangManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<KhachHang> _logger;
        public KhachHangManager(IUnitOfWork unitOfWork, ILogger<KhachHang> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<KhachHang> Create(KhachHang inputModel)
        {
            try
            {
                var result = await _unitOfWork.KhachHangRepository.Add(inputModel);
                await _unitOfWork.SaveChange();
                return inputModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(KhachHang inputModel)
        {
            try
            {
                await _unitOfWork.KhachHangRepository.Update(inputModel);
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
            var item = await Find_By_Id(id);
        
            await _unitOfWork.KhachHangRepository.Update(item);
            await _unitOfWork.SaveChange();
        }

        public async Task<KhachHang> Find_By_Id(int id)
        {
            var item = (await _unitOfWork.KhachHangRepository.FindBy(c => c.Id == id)).ToList().FirstOrDefault();
            return item;
        }

        public async Task<KhachHang> Find_By_Name(string inputName)
        {
            return await _unitOfWork.KhachHangRepository.Get(c => c.TenKhachHang.ToLower() == inputName.Trim().ToLower());
        }

        public async Task<List<KhachHang>> Get_List(string name="", int status=1, int pageSize = 10, int pageNumber = 0)
        {
            try
            {
                var data = (await _unitOfWork.KhachHangRepository.FindBy(x => x.TenKhachHang != null )).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<KhachHang>> Look_up()
        {
            try
            {
                var data = (await _unitOfWork.KhachHangRepository.GetAll()).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
