using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDTH17.Controllers
{
    public class TrangChuController : Controller
    {
        //
        // GET: /TrangChu/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /TrangChu/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TrangChu/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TrangChu/Create

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
        // GET: /TrangChu/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TrangChu/Edit/5

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
        // GET: /TrangChu/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TrangChu/Delete/5

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
