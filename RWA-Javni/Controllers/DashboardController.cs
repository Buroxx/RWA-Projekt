//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using RWA_Javni.Models;
//using RWA_Javni.Models.Auth;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

//namespace RWA_Javni.Controllers
//{
//    [Authorize]
//    public class DashboardController : Controller
//    {
//        private UserManager _authManager;

//        public UserManager AuthManager
//        {
//            get
//            {
//                return _authManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
//            }
//            private set
//            {
//                _authManager = value;
//            }
//        }

//        [Authorize]
//        public async Task<ActionResult> Index()
//        {
//            var userId = User.Identity.Name;
//            User model = await AuthManager.FindByNameAsync(userId);

//            return View();
//        }
//    }
//}