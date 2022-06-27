using Microsoft.AspNet.Identity;
using RWA_Javni.Models.DBRepo;
using RWA_Javni.Models.ViewModels;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RWA_Javni.Controllers
{

    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginUser u)
        {
            if (ModelState.IsValid)
            {
                User user = DBUserManager.AuthUser(u.UserName, Cryptography.HashPassword(u.Password));
                Session["user"] = user;
                return RedirectToAction("Index", "Home");
            }
            return View(u);
        }  


        [HttpGet]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }



    }
}