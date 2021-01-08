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

namespace DoAn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly ITacGiaManager _tacGiaManager;
 
        

        public HomeController(ILogger<HomeController> logger/*, ITacGiaManager tacGiaManager*/)
        {
            _logger = logger;
            //this._tacGiaManager = tacGiaManager;
            
        }

        public async Task<IActionResult> Index()
        {
            //var data = await _tacGiaManager.Look_up();
            return View();
        }
       [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Title = "Thêm mới tắc giả";
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(TacGia inputModel)
        //{
        //    await _tacGiaManager.Create(inputModel);
        //    ViewData["successMsg"] = "thêm thành công";
        //        return View();
        //}
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
