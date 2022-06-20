//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using RWA_Javni.Models.Auth;
//using RWA_Javni.Models.CustomAttributes;
//using RWA_Javni.Models.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

//namespace RWA_Javni.Controllers
//{
//    [Authorize]

//    public class LoginController : Controller
//    {
//        private UserManager _authManager;
//        private SignInManager _signInManager;

//        public SignInManager SignInManager
//        {
//            get
//            {
//                return _signInManager ?? HttpContext.GetOwinContext().Get<SignInManager>();
//            }
//            private set
//            {
//                _signInManager = value;
//            }
//        }

//        public UserManager AuthManager {
//            get
//            {
//                return _authManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
//            }
//            private set
//            {
//                _authManager = value;
//            }
//        }

//        [HttpGet]
//        [AllowAnonymous]
//        [IsAuthorized]
//        public ActionResult Index()
//        {
//            return View();
//        }
        
//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Index(LoginViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            var user = await AuthManager.FindAsync(model.Email, model.Password);
//            if(user != null)
//            {
//                await SignInManager.SignInAsync(user, true, model.RememberMe);
//                return RedirectToAction("Index", "Dashboard");
//            }
//            else
//            {
//                ModelState.AddModelError("", "User does not exist");
//                return View(model);
//            }
//        }

//        [HttpGet]
//        [Authorize]
//        public ActionResult Logout()
//        {
//            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
//            return RedirectToAction("Index", "Home");
//        }



//    }
//}