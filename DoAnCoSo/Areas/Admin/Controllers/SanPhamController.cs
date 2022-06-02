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
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        WebTraSuaEntities objWebTraSuaEntities = new WebTraSuaEntities();
        public ActionResult Index(string SearchString)
        {
            if (Session["idUser"] != null && Session["IsAdmin"] != null)
            {
                /*var objSanPham = objWebTraSuaEntities.SanPhams.Where(n => n.Name.Contains(SearchString)).ToList();*/
                var objSanPham = objWebTraSuaEntities.SanPhams.ToList();
            return View(objSanPham);
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
                SanPham sp = new SanPham();
            return View(sp);
        }
            else
            {
                return Redirect("~/Home/Login");
    }
}
        [HttpPost]
        public ActionResult Create(SanPham objSanPham)
        {
            try
            {
                if (objSanPham.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objSanPham.ImageUpload.FileName);
                    string extension = Path.GetExtension(objSanPham.ImageUpload.FileName);
                    fileName = fileName + extension;
                    objSanPham.Avartar = "~/Content/images/" + fileName;
                    objSanPham.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"),fileName));
                }
                objWebTraSuaEntities.SanPhams.Add(objSanPham);
                objWebTraSuaEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            if (Session["idUser"] != null && Session["IsAdmin"] != null)
            {
                var objSanPham = objWebTraSuaEntities.SanPhams.Where(n => n.Id == id).FirstOrDefault();
            return View(objSanPham);
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

                var objSanPham = objWebTraSuaEntities.SanPhams.Where(n => n.Id == id).FirstOrDefault();
            return View(objSanPham);
}
            else
{
    return Redirect("~/Home/Login");
}
        }
        [HttpPost]
        public ActionResult Delete(SanPham objsp)
        {
            var objSanPham = objWebTraSuaEntities.SanPhams.Where(n => n.Id == objsp.Id).FirstOrDefault();
            objWebTraSuaEntities.SanPhams.Remove(objSanPham);
            objWebTraSuaEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)

        {
    if (Session["idUser"] != null && Session["IsAdmin"] != null)
    {
        var objSanPham = objWebTraSuaEntities.SanPhams.Where(n => n.Id == id).FirstOrDefault();
            return View(objSanPham);
}
            else
{
    return Redirect("~/Home/Login");
}
        }
        [HttpPost]
        public ActionResult Edit(SanPham objSanPham)
        {
            if (objSanPham.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objSanPham.ImageUpload.FileName);
                string extension = Path.GetExtension(objSanPham.ImageUpload.FileName);
                fileName = fileName + extension;
                objSanPham.Avartar = "~/Content/images/" + fileName;
                objSanPham.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            objWebTraSuaEntities.Entry(objSanPham).State = EntityState.Modified;
            objWebTraSuaEntities.SaveChanges();
            return View(objSanPham);
        }
    }
}