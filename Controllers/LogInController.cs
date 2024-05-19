using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Security;
using evaluationproject.Models;

namespace evaluationproject.Controllers
{
    public class LogInController : Controller
    {
        evaluationprojectEntities2 db = new evaluationprojectEntities2();
        // GET: LogIn
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = db.userdetails.FirstOrDefault(a => a.name == username && a.password == password);
               if (user != null)
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
                else
                {
                    ViewBag.Message = "Invalid Username or Password";
                    return View();
                }
            }
            else {
                return View();
            }
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login", "LogIn");
        }
    }
}