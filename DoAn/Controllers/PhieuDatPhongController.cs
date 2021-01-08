using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Models;

namespace DoAn.Controllers
{
    [Route("phieu-dat-phong")]
    public class PhieuDatPhongController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPhieuDatPhongManager _PhieuDatPhongManager;
        private readonly IKhachHangManager _khachHangManager;
        private readonly IHangPhongManager _HangPhongManager;
        private readonly IKieuGiuongManager _KieuGiuongManager;
        public PhieuDatPhongController(ILogger<HomeController> logger, IPhieuDatPhongManager PhieuDatPhongManager, IKhachHangManager khachHangManager, IHangPhongManager HangPhongManager, IKieuGiuongManager KieuGiuongManager)
        {
            _logger = logger;
            this._PhieuDatPhongManager = PhieuDatPhongManager;
            this._khachHangManager = khachHangManager;
            this._HangPhongManager = HangPhongManager;
            this._KieuGiuongManager = KieuGiuongManager;
        }
        [HttpGet("them-moi")]
        public async Task<IActionResult> Create()
        {
            ViewBag.KhachHang_id = new SelectList(await _khachHangManager.Get_List(), "Id", "TenDuThuyen");
          
            ViewBag.Title = "Thêm mới phiếu đặt phòng";
            return View();
        }
        [HttpPost("them-moi")]
        public async Task<IActionResult> Create(PhieuDatPhong inputModel)
        {
            await _PhieuDatPhongManager.Create(inputModel);
            ViewData["successMsg"] = "thêm mới thành công";
            return RedirectToAction("danh-sach-nhom-phong", "nhom-phong");
        }
        [HttpGet("danh-sach-nhom-phong")]
        public async Task<IActionResult> List()
        {
            var data = await _PhieuDatPhongManager.Get_List(1,1,10,1);
            ViewBag.Title = "Danh sách phiếu đặt phòng";
            return View(data);
        }
        [HttpGet("Sua")]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _PhieuDatPhongManager.Find_By_Id(id);
            ViewBag.KhachHang_id = new SelectList(await _khachHangManager.Get_List(), "Id", "TenDuThuyen");

            return View(model);
        }
        [HttpPost("Sua")]
        public async Task<IActionResult> Update(PhieuDatPhong model)
        {

            var data = await _PhieuDatPhongManager.Find_By_Id(model.Id);
            if (data != null)
            {

                await _PhieuDatPhongManager.Update(model);
                ViewData["successMsg"] = "Sửa thành công";
            }

            return Redirect("/nhom-phong/danh-sach-nhom-phong");
        }
        [HttpPost("xoa")]
        public async Task<IActionResult> Delete(PhieuDatPhong model)
        {
            try
            {
                var item = await _PhieuDatPhongManager.Find_By_Id(model.Id);
                //item.TinhTrang = false;
                await _PhieuDatPhongManager.Update(item);
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
