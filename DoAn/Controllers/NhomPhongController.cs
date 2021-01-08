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
    [Route("nhom-phong")]
    public class NhomPhongController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INhomPhongManager _NhomPhongManager;
        private readonly IDuThuyenManager _DuThuyenManager;
        private readonly IHangPhongManager _HangPhongManager;
        private readonly IKieuGiuongManager _KieuGiuongManager;
        public NhomPhongController(ILogger<HomeController> logger, INhomPhongManager NhomPhongManager, IDuThuyenManager DuThuyenManager,IHangPhongManager HangPhongManager,IKieuGiuongManager KieuGiuongManager)
        {
            _logger = logger;
            this._NhomPhongManager = NhomPhongManager;
            this._DuThuyenManager = DuThuyenManager;
            this._HangPhongManager = HangPhongManager;
            this._KieuGiuongManager = KieuGiuongManager;
        }
        [HttpGet("them-moi")]
        public async Task<IActionResult> Create()
        {
            ViewBag.DuThuyen_id = new SelectList(await _DuThuyenManager.Get_List(), "Id", "TenDuThuyen");
            ViewBag.HangPhong_id = new SelectList(await _HangPhongManager.Get_List(), "Id", "TenHangPhong");
            ViewBag.KieuGiuong_id = new SelectList(await _KieuGiuongManager.Get_List(), "Id", "TenKieuGiuong");
            ViewBag.Title = "Thêm mới nhóm phòng";
            return View();
        }
        [HttpPost("them-moi")]
        public async Task<IActionResult> Create(NhomPhong inputModel)
        {
            await _NhomPhongManager.Create(inputModel);
            ViewData["successMsg"] = "thêm mới thành công";
            return RedirectToAction("danh-sach-nhom-phong", "nhom-phong");
        }
        [HttpGet("danh-sach-nhom-phong")]
        public async Task<IActionResult> List()
        {
            var data = await _NhomPhongManager.Get_List();
            ViewBag.Title = "Danh sách nhóm phòng";
            return View(data);
        }
        [HttpGet("Sua")]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _NhomPhongManager.Find_By_Id(id);
            ViewBag.DuThuyen_id = new SelectList(await _DuThuyenManager.Get_List(), "Id", "TenDuThuyen");
            ViewBag.HangPhong_id = new SelectList(await _HangPhongManager.Get_List(), "Id", "TenHangPhong");
            ViewBag.KieuGiuong_id = new SelectList(await _KieuGiuongManager.Get_List(), "Id", "TenKieuGiuong");

            return View(model);
        }
        [HttpPost("Sua")]
        public async Task<IActionResult> Update(NhomPhong model)
        {

            var data = await _NhomPhongManager.Find_By_Id(model.Id);
            if (data != null)
            {

                await _NhomPhongManager.Update(model);
                ViewData["successMsg"] = "Sửa thành công";
            }

            return Redirect("/nhom-phong/danh-sach-nhom-phong");
        }
        [HttpPost("xoa")]
        public async Task<IActionResult> Delete(NhomPhong model)
        {
            try
            {
                var item = await _NhomPhongManager.Find_By_Id(model.Id);
                item.TrangThai = false;
                await _NhomPhongManager.Update(item);
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




