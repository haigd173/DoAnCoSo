using DoAnCoSo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCoSo.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        // GET: DanhMucSanPham
        WebTraSuaEntities objWebTraSuaEntities = new WebTraSuaEntities();
        public ActionResult Index()
        {
            var listDanhSachSanPham = objWebTraSuaEntities.DanhMucSanPhams.ToList();
            return View(listDanhSachSanPham);
        }
        public ActionResult SanPhamCategory(int Id)
        {
            var listSanPham = objWebTraSuaEntities.SanPhams.Where(n => n.CategoryId == Id).ToList();
            return View(listSanPham);
        }
    }
}