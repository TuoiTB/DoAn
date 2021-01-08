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
    public interface IKieuGiuongManager
    {
        Task<KieuGiuong> Create(KieuGiuong inputModel);
        Task Update(KieuGiuong inputModel);
        Task Delete(int id);
        Task<KieuGiuong> Find_By_Id(int id);
        //Task<KieuGiuong> Find_By_Name(string inputName);
        Task<List<KieuGiuong>> Look_up();
        Task<List<KieuGiuong>> Get_List(int SoPhong =1, int status=1, int pageSize=10, int pageNumber=1);
    }
    public class KieuGiuongManager : IKieuGiuongManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<KieuGiuong> _logger;
        public KieuGiuongManager(IUnitOfWork unitOfWork, ILogger<KieuGiuong> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<KieuGiuong> Create(KieuGiuong inputModel)
        {
            try
            {
                var result = await _unitOfWork.KieuGiuongRepository.Add(inputModel);
                await _unitOfWork.SaveChange();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(KieuGiuong inputModel)
        {
            try
            {
                await _unitOfWork.KieuGiuongRepository.Update(inputModel);
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
            var item = (await _unitOfWork.KieuGiuongRepository.FindBy(c => c.Id == id)).ToList().FirstOrDefault();
          
            await _unitOfWork.KieuGiuongRepository.Update(item);
            await _unitOfWork.SaveChange();
           
        }

        public async Task<KieuGiuong> Find_By_Id(int id)
        {
            var item = (await _unitOfWork.KieuGiuongRepository.FindBy(c => c.Id == id)).ToList().FirstOrDefault();
            return item;// _unitOfWork.KieuGiuongRepository.Get(c => c.Id == id);
        }

        //public async Task<KieuGiuong> Find_By_Name(string inputName)
        //{
        //    return await _unitOfWork.KieuGiuongRepository.Get(c => c.t.ToLower() == inputName.Trim().ToLower());
        //}

        public async Task<List<KieuGiuong>> Get_List(int SoPhong, int status, int pageSize = 10, int pageNumber = 0)
        {
            try
            {
                var data = (await _unitOfWork.KieuGiuongRepository.FindBy(x => x.TrangThai == true)).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<KieuGiuong>> Look_up()
        {
            try
            {
                var data = (await _unitOfWork.KieuGiuongRepository.GetAll()).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
