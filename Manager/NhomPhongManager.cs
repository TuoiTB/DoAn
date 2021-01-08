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
    public interface INhomPhongManager
    {
        Task<NhomPhong> Create(NhomPhong inputModel);
        Task Update(NhomPhong inputModel);
        Task Delete(long id);
        Task<NhomPhong> Find_By_Id(long id);
        //Task<NhomPhong> Find_By_Name(string inputName);
        Task<List<NhomPhong>> Look_up();
        Task<List<NhomPhong>> Get_List(int SoPhong=1, int status=1, int pageSize=10, int pageNumber=10);
    }
    public class NhomPhongManager : INhomPhongManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<NhomPhong> _logger;
        public NhomPhongManager(IUnitOfWork unitOfWork, ILogger<NhomPhong> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<NhomPhong> Create(NhomPhong inputModel)
        {
            try
            {
                var result = await _unitOfWork.NhomPhongRepository.Add(inputModel);
                await _unitOfWork.SaveChange();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(NhomPhong inputModel)
        {
            try
            {
                await _unitOfWork.NhomPhongRepository.Update(inputModel);
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
            var item = await _unitOfWork.NhomPhongRepository.Get(c => c.Id == id);

            await _unitOfWork.NhomPhongRepository.Update(item);
            await _unitOfWork.SaveChange();
        }

        public async Task<NhomPhong> Find_By_Id(long Id)
        {
            var item = (await _unitOfWork.NhomPhongRepository.FindBy(c => c.Id == Id)).ToList().FirstOrDefault();
            return item;
        }

        //public async Task<NhomPhong> Find_By_Name(string inputName)
        //{
        //    return await _unitOfWork.NhomPhongRepository.Get(c => c.t.ToLower() == inputName.Trim().ToLower());
        //}

        public async Task<List<NhomPhong>> Get_List(int SoPhong=1, int status=1, int pageSize = 10, int pageNumber = 0)
        {
            try
            {
                var data = (await _unitOfWork.NhomPhongRepository.FindBy(x => x.TrangThai == true)).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NhomPhong>> Look_up()
        {
            try
            {
                var data = (await _unitOfWork.NhomPhongRepository.FindBy(x => x.TrangThai == true)).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
