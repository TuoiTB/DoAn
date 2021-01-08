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
    [Route("hang-phong")]
    public class HangPhongController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHangPhongManager _HangPhongManager;



        public HangPhongController(ILogger<HomeController> logger, IHangPhongManager HangPhongManager)
        {
            _logger = logger;
            this._HangPhongManager = HangPhongManager;

        }
        [HttpGet("them-moi")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Title = "Thêm mới hạng phòng";
            return RedirectToAction("danh-sach-hang-phong", "hang-phong");
        }
        [HttpPost("them-moi")]
        public async Task<IActionResult> Create(HangPhong inputModel)
        {
            await _HangPhongManager.Create(inputModel);
            return View();
        }
        [HttpGet("danh-sach-hang-phong")]
        public async Task<IActionResult> List()
        {
            var data = await _HangPhongManager.Get_List();
            ViewBag.Title = "Danh sách hạng phòng";
            return View(data);
        }
        [HttpGet("Sua")]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _HangPhongManager.Find_By_Id(id);


            return View(model);
        }
        [HttpPost("Sua")]
        public async Task<IActionResult> Update(HangPhong model)
        {

            var data = await _HangPhongManager.Find_By_Id(model.Id);
            if (data != null)
            {

                await _HangPhongManager.Update(model);
                ViewData["successMsg"] = "Sửa thành công";
            }

            return Redirect("/hang-phong/danh-sach-hang-phong");
        }
        [HttpPost("xoa")]
        public async Task<IActionResult> Delete(HangPhong model)
        {
            try
            {
                var item = await _HangPhongManager.Find_By_Id(model.Id);
                item.TrangThai = false;
                await _HangPhongManager.Update(item);
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




