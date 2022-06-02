using DoAnCoSo.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCoSo.Areas.Admin.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        WebTraSuaEntities objWebTraSuaEntities = new WebTraSuaEntities();
        // GET: Admin/DanhMucSanPham
        public ActionResult Index()
        {
            if (Session["idUser"] != null && Session["IsAdmin"] != null)
            {
                var objDanhSachSanPham = objWebTraSuaEntities.DanhMucSanPhams.ToList();
            return View(objDanhSachSanPham);
            }
            else
            {
                return Redirect("~/Home/Login");
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
                if (Session["idUser"] != null && Session["IsAdmin"] != null)
                {
                    DanhMucSanPham dmsp = new DanhMucSanPham();
            return View(dmsp);
                }
                else
                {
                    return Redirect("~/Home/Login");
                }
            }
        [HttpPost]
        public ActionResult Create(DanhMucSanPham objDanhMucSanPham)
        {
            try
            {
                if (objDanhMucSanPham.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objDanhMucSanPham.ImageUpload.FileName);
                    string extension = Path.GetExtension(objDanhMucSanPham.ImageUpload.FileName);
                    fileName = fileName + extension;
                    objDanhMucSanPham.Avatar = "~/Content/images/" + fileName;
                    objDanhMucSanPham.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                objWebTraSuaEntities.DanhMucSanPhams.Add(objDanhMucSanPham);
                objWebTraSuaEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var objDanhMucSanPham = objWebTraSuaEntities.DanhMucSanPhams.Where(n => n.Id == id).FirstOrDefault();
            return View(objDanhMucSanPham);
        }
        [HttpGet]
        public ActionResult Delete(int id)
       
               {
                if (Session["idUser"] != null && Session["IsAdmin"] != null)
                {
                    var objDanhMucSanPham = objWebTraSuaEntities.DanhMucSanPhams.Where(n => n.Id == id).FirstOrDefault();
            return View(objDanhMucSanPham);
            }
            else
            {
                return Redirect("~/Home/Login");
            }
        }
        [HttpPost]
        public ActionResult Delete(DanhMucSanPham objdmsp)
        {
            var objDanhMucSanPham = objWebTraSuaEntities.DanhMucSanPhams.Where(n => n.Id == objdmsp.Id).FirstOrDefault();
            objWebTraSuaEntities.DanhMucSanPhams.Remove(objDanhMucSanPham);
            objWebTraSuaEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        
                        {
            if (Session["idUser"] != null && Session["IsAdmin"] != null)
            {
                var objDanhMucSanPham = objWebTraSuaEntities.DanhMucSanPhams.Where(n => n.Id == id).FirstOrDefault();
            return View(objDanhMucSanPham);
    }
            else
            {
                return Redirect("~/Home/Login");
}

        }
        [HttpPost]
        public ActionResult Edit(DanhMucSanPham objDanhMucSanPham)
        {
            if (objDanhMucSanPham.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objDanhMucSanPham.ImageUpload.FileName);
                string extension = Path.GetExtension(objDanhMucSanPham.ImageUpload.FileName);
                fileName = fileName + extension;
                objDanhMucSanPham.Avatar = "~/Content/images/" + fileName;
                objDanhMucSanPham.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            objWebTraSuaEntities.Entry(objDanhMucSanPham).State = EntityState.Modified;
            objWebTraSuaEntities.SaveChanges();
            return View(objDanhMucSanPham);
        }
    }
}