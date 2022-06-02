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
    public class LoaiSanPhamController : Controller
    {
        // GET: Admin/LoaiSanPham
        WebTraSuaEntities objWebTraSuaEntities = new WebTraSuaEntities();
        public ActionResult Index()
        {
            if (Session["idUser"] != null && Session["IsAdmin"] != null)
            {
                var objLoaiSanPham = objWebTraSuaEntities.LoaiSanPhams.ToList();
            return View(objLoaiSanPham);
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
                    LoaiSanPham loaisp = new LoaiSanPham();
            return View(loaisp);
            }
            else
            {
                return Redirect("~/Home/Login");
            }
        }
        [HttpPost]
        public ActionResult Create(LoaiSanPham objLoaiSanPham)
        {
            try
            {
                if (objLoaiSanPham.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objLoaiSanPham.ImageUpload.FileName);
                    string extension = Path.GetExtension(objLoaiSanPham.ImageUpload.FileName);
                    fileName = fileName + extension;
                    objLoaiSanPham.Avatar = "~/Content/images/" + fileName;
                    objLoaiSanPham.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                objWebTraSuaEntities.LoaiSanPhams.Add(objLoaiSanPham);
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

                    if (Session["idUser"] != null && Session["IsAdmin"] != null)
                    {
                        var objLoaiSanPham = objWebTraSuaEntities.LoaiSanPhams.Where(n => n.Id == id).FirstOrDefault();
            return View(objLoaiSanPham);
            }
            else
            {
                return Redirect("~/Home/Login");
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {

                    if (Session["idUser"] != null && Session["IsAdmin"] != null)
                    {
                        var objLoaiSanPham = objWebTraSuaEntities.LoaiSanPhams.Where(n => n.Id == id).FirstOrDefault();
            return View(objLoaiSanPham);
            }
            else
            {
                return Redirect("~/Home/Login");
            }
        }
        [HttpPost]
        public ActionResult Delete(LoaiSanPham objlsp)
        {
            var objLoaiSanPham = objWebTraSuaEntities.LoaiSanPhams.Where(n => n.Id == objlsp.Id).FirstOrDefault();
            objWebTraSuaEntities.LoaiSanPhams.Remove(objLoaiSanPham);
            objWebTraSuaEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            if (Session["idUser"] != null && Session["IsAdmin"] != null)
            {
                var objLoaiSanPham = objWebTraSuaEntities.LoaiSanPhams.Where(n => n.Id == id).FirstOrDefault();
            return View(objLoaiSanPham);
        }
            else
            {
                return Redirect("~/Home/Login");

    }
}
        [HttpPost]
        public ActionResult Edit(LoaiSanPham objLoaiSanPham)
        {

            if (objLoaiSanPham.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objLoaiSanPham.ImageUpload.FileName);
                string extension = Path.GetExtension(objLoaiSanPham.ImageUpload.FileName);
                fileName = fileName + extension;
                objLoaiSanPham.Avatar = "~/Content/images/" + fileName;
                objLoaiSanPham.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            objWebTraSuaEntities.Entry(objLoaiSanPham).State = EntityState.Modified;
            objWebTraSuaEntities.SaveChanges();
            return View(objLoaiSanPham);
        }
    }
}