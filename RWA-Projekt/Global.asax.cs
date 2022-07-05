using rwaLib.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace RWA_Projekt
{
    public class Global : System.Web.HttpApplication
    {
        private readonly IRepo _repo;

        public Global()
        {
            _repo = RepoFactory.GetRepo();
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["database"] = _repo;
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Response.Redirect("AdministratorApartments.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}