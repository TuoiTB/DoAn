using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace DoAn.Controllers
{
    [Route("khach-hang")]
    public class KhachHangController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKhachHangManager _khachHangManager;



        public KhachHangController(ILogger<HomeController> logger, IKhachHangManager khachHangManager)
        {
            _logger = logger;
            this._khachHangManager = khachHangManager;

        }
        [HttpGet("them-moi")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Title = "Thêm mới khách hàng";
            return View();
        }
        [HttpPost("them-moi")]
        public async Task<IActionResult> Create(KhachHang inputModel)
        {
            await _khachHangManager.Create(inputModel);
            ViewData["successMsg"] = "thêm mới thành công";
            return RedirectToAction("danh-sach-khach-hang", "khach-hang");
        }
        [HttpGet("danh-sach-khach-hang")]
        public async Task<IActionResult> List()
        {
            var data = await _khachHangManager.Get_List();
            ViewBag.Title = "Danh sách khách hàng";
            return View(data);
        }
        [HttpGet("Sua")]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _khachHangManager.Find_By_Id(id);


            return View(model);
        }
        [HttpPost("Sua")]
        public async Task<IActionResult> Update(KhachHang model)
        {

            var data = await _khachHangManager.Find_By_Id(model.Id);
            if(data !=  null)
            {
                
                await _khachHangManager.Update(model);
                ViewData["successMsg"] = "Sửa thành công";
            }

            return Redirect("/khach-hang/danh-sach-khach-hang");
        }
        [HttpPost("xoa")]
        public async Task<IActionResult> Delete(KhachHang model)
        {
            try
            {
                var item = await _khachHangManager.Find_By_Id(model.Id);
                item.TrangThai = false;
                await _khachHangManager.Update(model);
                return Json(new
                {
                    data = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = false
                });
            }
        }
    }

}
