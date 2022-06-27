using Microsoft.AspNet.Identity;
using RWA_Javni.Models.DBRepo;
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
            if (Session["user"]!=null)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User u)
        {
            if (ModelState.IsValid)
            {
                return View(u);
            }

            User user = DBUserManager.AuthUser(u.UserName, Cryptography.HashPassword(u.Password));

            if (user == null)
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                Session["user"] = user;
                return RedirectToAction("Index", "Home");
            }
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