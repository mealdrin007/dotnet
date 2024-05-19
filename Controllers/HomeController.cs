    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using evaluationproject.Models;

namespace evaluationproject.Controllers
{
    public class HomeController : Controller
    {
        evaluationprojectEntities2 db = new evaluationprojectEntities2();
        // GET: Home
        public ActionResult Index()
        {
            var lst = db.userdetails.ToList();
            return View(lst);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(userdetail model)
        {
            if (ModelState.IsValid)
            {
                db.userdetails.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int Id)
        {
            userdetail user = db.userdetails.Where(a => a.id == Id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(userdetail model)
        {
            userdetail user=db.userdetails.Where(a=>a.id == model.id).FirstOrDefault();
            user.name = model.name;
            user.email = model.email;
            user.password = model.password;

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(int Id)
        {
            userdetail user = db.userdetails.Where(a=>a.id == Id).FirstOrDefault();
            db.userdetails.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            userdetail user =db.userdetails.Where(a=>a.id==Id).FirstOrDefault();
            return View(user);
        }

    }
}