using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDTH17.Models.Entities;
using CDTH17.Models.Functions;
using System.IO;

namespace CDTH17.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/

        public ActionResult Index()
        {
            ViewBag.TenDM = "DANH SÁCH TOÀN BỘ CƠ SỞ DỮ LIỆU ";
            var model = new SanPhamF().DSSanPham.ToList();
            return View("index5",model);
        }
  

        public ActionResult Preview(string id)
        {
            var model = new SanPhamF().FindEntity(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult TimKiem(string search)
        {
            ViewBag.TenDM = "KẾT QUẢ TÌM KIẾM ";
            var model = new SanPhamF().DSSanPham.
                Where(x => x.TenSP.Contains(search)).ToList();
            return View("index", model);
        }
     
        

        //
        // GET: /SanPham/Create

        public ActionResult Test()
        {
            return View();
        }


        //
        // GET: /SanPham/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
        
        // GET: /SanPham/Create

        public ActionResult Create()
        {
            ViewBag.DanhMuc = new DanhMucF().DSDanhMuc.ToList();
            return View();
        }

        //
        // POST: /SanPham/Create

        [HttpPost]
        public ActionResult Create(SanPham model, HttpPostedFileBase UrlAnh)
        {
            try
            {

                if (UrlAnh == null)
                {
                    ModelState.AddModelError("File", "Chưa upload file ảnh");
                    return RedirectToAction("Create");

                }
                else if (UrlAnh.ContentLength > 0)
                {                 //TO:DO
                    var fileName = Path.GetFileName(UrlAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    UrlAnh.SaveAs(path);
                    model.UrlAnh = fileName;                      
                    // TODO: Add insert logic here
                    if (new SanPhamF().Insert(model) != null)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }

                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SanPham/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SanPham/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SanPham/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SanPham/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
