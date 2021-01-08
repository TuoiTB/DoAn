using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DoAn.Models;
using Manager;
using Models;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoAn.Controllers
{
    [Route("danh-sach-phong")]
    public class DanhSachPhongController : Controller
    {
        private readonly ILogger<DanhSachPhongController> _logger;
        //private readonly ITacGiaManager _tacGiaManager;
        private readonly IDanhSachPhongManager _danhSachPhongManager;
        private readonly INhomPhongManager _nhomPhongManager;


        public DanhSachPhongController(ILogger<DanhSachPhongController> logger, IDanhSachPhongManager danhSachPhongManager,INhomPhongManager nhomPhongManager)
        {
            _logger = logger;
            //this._tacGiaManager = tacGiaManager;
            this._danhSachPhongManager = danhSachPhongManager;
            this._nhomPhongManager = nhomPhongManager;
        }

        public async Task<IActionResult> Index()
        {
            //var data = await _danhSachPhongManager.Look_up();
            return View();
        }

        [HttpGet("danh-sach-danh-sach-phong")]
        public async Task<IActionResult> List()
        {
            var data = await _danhSachPhongManager.Get_List(1, 1, 1, 1);
            ViewBag.Title = "Danh sách phòng";
            return View(data);
        }

        [HttpGet("them-moi")]
        public async Task<IActionResult> Create()
        {
            ViewBag.NhomPhong_id = new SelectList( await _nhomPhongManager.Get_List(), "Id", "TenNhomPhong");
            ViewBag.Title = "Thêm mới số phòng";
            return View();
        }
        [HttpPost("them-moi")]
        public async Task<IActionResult> Create(DanhSachPhong inputModel)
        {

            await _danhSachPhongManager.Create(inputModel);
            ViewData["successMsg"] = "thêm mới thành công";
            return RedirectToAction("danh-sach-danh-sach-phong", "danh-sach-phong");
            //return View();
        }
        
        [HttpGet("Sua")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.NhomPhong_id = new SelectList(await _nhomPhongManager.Get_List(), "Id", "TenNhomPhong");
            var model = await _danhSachPhongManager.Find_By_Id(id);
            return View(model);
        }
        [HttpPost("Sua")]
        public async Task<IActionResult> Update(DanhSachPhong model)
        {

            var data = await _danhSachPhongManager.Find_By_Id(model.Id);
            if (data != null)
            {
                await _danhSachPhongManager.Update(model);
                ViewBag.NhomPhong_id = new SelectList(await _nhomPhongManager.Get_List(), "Id", "TenNhomPhong");
                ViewData["successMsg"] = "Sửa thành công";
            }

            return Redirect("/danh-sach-phong/danh-sach-danh-sach-phong");
        }
        [HttpPost("xoa")]
        public async Task<IActionResult> Delete(DanhSachPhong model)
        {
            var item = await _danhSachPhongManager.Find_By_Id(model.Id);
            item.TrangThai = false;
            await _danhSachPhongManager.Update(item);
            return Json(new
            {
                data = true
            });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
