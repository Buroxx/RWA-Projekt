using rwaLib.Dal;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWA_Projekt
{
    public partial class AdministratorRegisteredUsers : System.Web.UI.Page
    {
        IList<User> users = new List<User>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
            else
            {
                users = (IList<User>)ViewState["users"];
            }
        }

        private void LoadData()
        {
            users = ((DBRepo)Application["database"]).GetAllUsers();
            rptUsers.DataSource = users;
            rptUsers.DataBind();
            ViewState["users"] = users;
        }
    }
}