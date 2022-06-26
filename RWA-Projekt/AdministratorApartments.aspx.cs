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
    public partial class AdministratorApartments : System.Web.UI.Page
    {
        private IList<Apartment> listOfAllApartments;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            User owner = (User)Session["user"];

            if(Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            listOfAllApartments = ((DBRepo)Application["database"]).GetAllApartments();

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            rptApartments.DataSource = listOfAllApartments;
            rptApartments.DataBind();

        }

        protected void ViewApartment_Click(object sender, EventArgs e)
        {
            Button btnViewApartment = (Button)sender;
            int Id = int.Parse(btnViewApartment.CommandArgument);
            Session["ApartmentID"] = Id;
            Response.Redirect("ViewApartment.aspx");
        }

        protected void btnDeleteApartment_Click(object sender, EventArgs e)
        {
            int apartmentID = (int)ViewState["apartmentID"];
            ((DBRepo)Application["database"]).DeleteApartment(apartmentID);
            Response.Redirect("AdministratorApartments.aspx");
        }

        protected void btnDeleteModal_Click(object sender, EventArgs e)
        {
            Button btnDeleteApartment = (Button)sender;
            int apartmentID = int.Parse(btnDeleteApartment.CommandArgument);
            pnlModal.Visible = true;
            ViewState["apartmentID"] = apartmentID;
        }

        protected void btnNewApartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewApartment.aspx");
        }
    }
}