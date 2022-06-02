using DoAnCoSo.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCoSo.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        WebTraSuaEntities objWebTraSuaEntities = new WebTraSuaEntities();
        /*public ActionResult Index(string SearchS  tring)
        {
            var objProduct = objWebTraSuaEntities.SanPhams.Where(n => n.Name.Contains(SearchString)).ToList();
            return View(objProduct);
        }*/

        public ActionResult Index(string SearchString, string currentFilter, int? page)
        {
            var listSanPham = new List<SanPham>();
            if(SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                //lấy danh sách sản phẩm theo tử khoá tìm kiếm
                listSanPham = objWebTraSuaEntities.SanPhams.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                listSanPham = objWebTraSuaEntities.SanPhams.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            listSanPham = listSanPham.OrderByDescending(n => n.Id).ToList();
            return View(listSanPham.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Detail(int Id)
        {
            var objSanPham = objWebTraSuaEntities.SanPhams.Where(n => n.Id == Id).FirstOrDefault();
            return View(objSanPham);
        }

        
    }
}