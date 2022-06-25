using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using RWA_Javni.Models;
//using RWA_Javni.Models.Auth;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(RWA_Javni.App_Start.Startup))]

namespace RWA_Javni.App_Start
{
    public class Startup
    {

        //public void Configuration(IAppBuilder app)
        //{
        //    app.CreatePerOwinContext(DBContext.Create);
        //    app.CreatePerOwinContext<UserManager>(UserManager.Create);
        //    app.CreatePerOwinContext<SignInManager>(SignInManager.Create);

        //    app.UseCookieAuthentication(new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        //        LoginPath = new PathString("/Login/Index"),
        //        Provider = new CookieAuthenticationProvider
        //        {
        //            OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager, User>(
        //                validateInterval: TimeSpan.FromMinutes(30),
        //                regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
        //        }
        //    });
        //    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        //}
    }
}
