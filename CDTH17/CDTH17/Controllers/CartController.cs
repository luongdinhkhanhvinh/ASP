using CDTH17.Models.Entities;
using CDTH17.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDTH17.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            var cart = (Cart)Session["CartSession"];

            var list = new List<CartItem>();

            if (cart != null)
            {
                list = cart.Lines.ToList();
                ViewBag.TongTien = cart.ComputeTotalValue();
            }

            return View(list);
           
        }



        public ActionResult UpdateCart(string id, FormCollection fr)
        {

            var product = new SanPhamF().FindEntity(id);

            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                int NewQuantity = int.Parse(fr["txtQuantity"].ToString());
                cart.UpdateItem(product, NewQuantity);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Index");

        }

        // GET: /Cart/Details/5
        public ActionResult RemoveLine(string id)
        {

            var product = new SanPhamF().FindEntity(id);

            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                cart.RemoveLine(product);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Index");
        }



        public ActionResult AddItem(string id, string returnURL)
        {

            var product = new SanPhamF().FindEntity(id);
            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }

            if (string.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("Index");
            }

            return Redirect(returnURL);

        }
        //
        public ActionResult Clear()
        {
            var cart = (Cart)Session["CartSession"];
            cart.Clear();
            Session["CartSession"] = cart;
            return RedirectToAction("Index");
        }
        //
        // GET: /Cart/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Cart/Create



        [HttpGet]
        public ActionResult Payment()
        {
            var cart = (Cart)Session["CartSession"];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = cart.Lines.ToList();
            }
            return View(list);
        }


        [HttpPost]
        public ActionResult Payment(HOADON model)
        {
            model.NgayHD= DateTime.Now;
            try
            {
                var id = new HoaDonF().Insert(model);

                var cart = (Cart)Session["CartSession"];

                var detailDao = new ChiTietHDF();
                decimal total = 0;
                foreach (var item in cart.Lines)
                {
                    var orderDetail = new CHITIETHD();
                    orderDetail.MaSP = item.Sanpham.MaSP;
                    orderDetail.MaHD = id;
                    orderDetail.DonGia = item.Sanpham.GiaSP;
                    orderDetail.SoLuong = item.Quantity;

                    detailDao.Insert(orderDetail);

                    total += (item.Sanpham.GiaSP.GetValueOrDefault(0) * item.Quantity);
                }

            }
            catch (Exception ex)
            {
                //ghi log
                return RedirectToAction("/Loi");
            }
            return RedirectToAction("Index", "SanPham");
        }
        //

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cart/Create

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
        // GET: /Cart/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Cart/Edit/5

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
        // GET: /Cart/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cart/Delete/5

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
