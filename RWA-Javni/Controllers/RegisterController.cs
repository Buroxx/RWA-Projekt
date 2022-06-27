using RWA_Javni.Models.DBRepo;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Javni.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            if (Session["user"]!=null)
            {
                return RedirectToAction("Home", "Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User u)
        {
            if (ModelState.IsValid)
            {
                DBUserManager.CreateNewUser(u);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return Index();
            }
        }
    }
}