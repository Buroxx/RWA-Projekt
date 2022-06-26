using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using rwaLib.Dal;
using rwaLib.Models;

namespace RWA_Projekt
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("AdministratorApartments.aspx");
            }


            pnlErrorLogin.Visible = false;

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var username = tbUsername.Text;
                var password = Cryptography.HashPassword(tbPassword.Text);

                User user = ((DBRepo)Application["database"]).AuthUser(username, password);

                if (user == null)
                {
                    tbUsername.Text = "";
                    tbPassword.Text = "";
                    pnlErrorLogin.Visible = true;
                }
                else
                {
                    Session["user"] = user;
                    Response.Redirect("AdministratorApartments.aspx");
                }
            }
        }
    }
}