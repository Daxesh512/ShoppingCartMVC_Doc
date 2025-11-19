using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using OnlineShoppingCartMVC.Models;

namespace OnlineShoppingCartMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Fashion()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult Jawelry()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Registartion()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registartion(TblUser r1)
        {
            using(ShoppingSCartEntities db=new ShoppingSCartEntities())
            {
                if(ModelState.IsValid)
                {
                    db.TblUsers.Add(r1);
                    db.SaveChanges();
                    ViewBag.message("Registration Sucessfully");
                    ModelState.Clear();
                }
            }
            return View(r1);
        }
        [HttpPost]
        public ActionResult Login(TblUser r1)
        {
            using (ShoppingSCartEntities db = new ShoppingSCartEntities())
            {
                if (ModelState.IsValid)
                {
                    var log = db.TblUsers.Where(a => a.userName.Equals(r1.userName) && a.password.Equals(r1.password)).FirstOrDefault();
                    if(log != null)
                    {
                        return RedirectToAction("Product");
                    }
                    ViewBag.message("Registration Sucessfully");
                    ModelState.Clear();
                }
            }
            return View(r1);
        }

    }
}