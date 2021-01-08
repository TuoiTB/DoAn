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
    [Route("du-thuyen")]
    public class DuThuyenController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDuThuyenManager _DuThuyenManager;



        public DuThuyenController(ILogger<HomeController> logger, IDuThuyenManager DuThuyenManager)
        {
            _logger = logger;
            this._DuThuyenManager = DuThuyenManager;

        }
        [HttpGet("them-moi")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Title = "Thêm mới du thuyền";
            return View();
        }
        [HttpPost("them-moi")]
        public async Task<IActionResult> Create(DuThuyen inputModel)
        {

            await _DuThuyenManager.Create(inputModel);
            ViewData["successMsg"] = "thêm mới thành công";
            return RedirectToAction("danh-sach-du-thuyen", "du-thuyen");
            //return View();
        }
        [HttpGet("danh-sach-du-thuyen")]
        public async Task<IActionResult> List()
        {
            var data = await _DuThuyenManager.Get_List();
            ViewBag.Title = "Danh sách du thuyền";
            return View(data);
        }
        [HttpGet("Sua")]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _DuThuyenManager.Find_By_Id(id);


            return View(model);
        }
        [HttpPost("Sua")]
        public async Task<IActionResult> Update(DuThuyen model)
        {

            var data = await _DuThuyenManager.Find_By_Id(model.Id);
            if (data != null)
            {

                await _DuThuyenManager.Update(model);
                ViewData["successMsg"] = "Sửa thành công";
            }

            return Redirect("/du-thuyen/danh-sach-du-thuyen");
        }
        [HttpPost("xoa")]
        public async Task<IActionResult> Delete(DuThuyen model)
        {
            try
            {
                var item = await _DuThuyenManager.Find_By_Id(model.Id);
                item.TrangThai = false;
                await _DuThuyenManager.Update(item);
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
