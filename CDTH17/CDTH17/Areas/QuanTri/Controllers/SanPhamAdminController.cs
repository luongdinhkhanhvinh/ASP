using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDTH17.Models.Entities;
using CDTH17.Models.Functions;
using CDTH17.Models.BaoMat;

namespace CDTH17.Areas.QuanTri.Controllers
{
    public class SanPhamAdminController : Controller
    {
        //
        // GET: /QuanTri/SanPhamAdmin/
        [CustomAuthorize(Roles = "Admin,Custommer")]
        public ActionResult Index()
        {
            //if (Session["DangNhap"] == null)
            //{
            //    return Redirect("/Login/Index");
            //}
            //else
            //{
            //    if (Session["Quyen"] == null)
            //    {
            //        return Redirect("/Login/Index");
            //    }
            //    else
            //    {
            //        List<string> dsq = new List<string>();
            //        foreach (viewQuyen dt in Session["Quyen"] as List<viewQuyen>)
            //        {
            //            dsq.Add(dt.RoleName);
            //        }
            //        if (!dsq.Any(r => r.Contains("Admin")))
            //        {
            //            return Redirect("/Login/Index");
            //        }         
                    
                   
            //    }
            //}

            var model = new SanPhamF().DSSanPham.ToList();
            return View(model);
        }

        //
        // GET: /QuanTri/SanPhamAdmin/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /QuanTri/SanPhamAdmin/Create
         [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /QuanTri/SanPhamAdmin/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /QuanTri/SanPhamAdmin/Edit/5
          [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            ViewBag.DanhMuc = new DanhMucF().DSDanhMuc.ToList();
            var model = new SanPhamF().FindEntity(id);
            return View(model);
        }

        //
        // POST: /QuanTri/SanPhamAdmin/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, SanPham model)
        {
            try
            {
                // TODO: Add update logic here
                if (new SanPhamF().Update(model)!= null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /QuanTri/SanPhamAdmin/Delete/5
          [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /QuanTri/SanPhamAdmin/Delete/5

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
