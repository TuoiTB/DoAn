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
    [Route("kieu-giuong")]
    public class KieuGiuongController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKieuGiuongManager _KieuGiuongManager;
    


        public KieuGiuongController(ILogger<HomeController> logger, IKieuGiuongManager KieuGiuongManager)
        {
            _logger = logger;
            this._KieuGiuongManager = KieuGiuongManager;

        }
        [HttpGet("them-moi")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Title = "Thêm mới kiểu giường";
            return View();
        }
        [HttpPost("them-moi")]
        public async Task<IActionResult> Create(KieuGiuong inputModel)
        {
            await _KieuGiuongManager.Create(inputModel);
            ViewData["successMsg"] = "thêm mới thành công";
            return RedirectToAction("danh-sach-kieu-giuong", "kieu-giuong");
            //return View();
        }
        [HttpGet("danh-sach-kieu-giuong")]
        public async Task<IActionResult> List()
        {
            var data = await _KieuGiuongManager.Get_List(1, 1, 1, 1);
            ViewBag.Title = "Danh sách kiểu giường";
            return View(data);
        }
        [HttpGet("Sua")]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _KieuGiuongManager.Find_By_Id(id);


            return View(model);
        }
        [HttpPost("Sua")]
        public async Task<IActionResult> Update(KieuGiuong model)
        {

            var data = await _KieuGiuongManager.Find_By_Id(model.Id);
            if (data != null)
            {

                await _KieuGiuongManager.Update(model);
                ViewData["successMsg"] = "Sửa thành công";
            }

            return Redirect("/kieu-giuong/danh-sach-kieu-giuong");
        }
        [HttpPost("xoa")]
        public async Task<IActionResult> Delete(KieuGiuong model)
        {
            try
            {
                var item=await _KieuGiuongManager.Find_By_Id(model.Id);
                item.TrangThai = false;
                await _KieuGiuongManager.Update(model);
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

    


