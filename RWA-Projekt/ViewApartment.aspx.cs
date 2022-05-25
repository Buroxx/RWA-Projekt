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
    public partial class ViewApartment : System.Web.UI.Page
    {
        private IList<ApartmentPicture> pictureList;
        private Apartment apartment;
        private IList<User> users;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            users = ((DBRepo)Application["database"]).GetAllUsers();


            if (!IsPostBack)
            {
                LoadData();
            }
            else
            {
                gvPickedUser.Visible = false;
                btnRegistered.ForeColor = System.Drawing.Color.Black;
                btnUnregistered.ForeColor = System.Drawing.Color.Black;
                pnlUnregistered.Visible = false;
                //LoadViewState();
            }

        }

        private void LoadViewState()
        {
            Apartment apartment = (Apartment)ViewState["apartment"];

            tbName.Text = apartment.Name;
            tbPrice.Text = apartment.Price;
            tbCity.Text = apartment.City;
            tbAdults.Text = apartment.MaxAdults.ToString();
            tbChildren.Text = apartment.MaxChildren.ToString();
            tbRooms.Text = apartment.TotalRooms.ToString();
        }

        private void LoadData()
        {
            pnlUnregistered.Visible = false;
            gvPickedUser.Visible = false;
            pnlOption.Visible = false;
            ddlStatus.Items.Insert(0,"Occupied");
            ddlStatus.Items.Insert(1,"Reserved");
            ddlStatus.Items.Insert(2,"Vacant");
            ddlStatus.SelectedIndex = 2;

            int apartmentID = (int)Session["ApartmentID"];
            apartment = ((DBRepo)Application["database"]).GetApartmentByID(apartmentID); 
            pictureList = ((DBRepo)Application["database"]).GetApartmentPicturesByID(apartmentID);
            rptImgs.DataSource = pictureList;
            rptImgs.DataBind();

            tbName.Text = apartment.Name;
            tbPrice.Text = apartment.Price;
            tbCity.Text = apartment.City;
            tbAdults.Text = apartment.MaxAdults.ToString();
            tbChildren.Text = apartment.MaxChildren.ToString();
            tbRooms.Text = apartment.TotalRooms.ToString();
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SaveData();
            pnlOption.Visible = true;
        }

     

        private void SaveData()
        {
            ViewState["apartment"] = new Apartment
            {
                Name = tbName.Text,
                Price = tbPrice.Text,
                City = tbCity.Text,
                MaxAdults = int.Parse(tbAdults.Text),
                MaxChildren = int.Parse(tbChildren.Text),
                TotalRooms = int.Parse(tbRooms.Text)
            };
        }

        protected void btnRegistered_Click(object sender, EventArgs e)
        {
            rptUsers.DataSource = users;
            rptUsers.DataBind();
            btnRegistered.ForeColor = System.Drawing.Color.Green;
            pnlRegistered.Visible = true;
        }

        protected void PickPerson_Click(object sender, EventArgs e)
        {
            LinkButton btnPicked = (LinkButton)sender;
            int userID = int.Parse(btnPicked.CommandArgument);
            pnlRegistered.Visible = false;
            gvPickedUser.Visible = true;
            IList<User> u = ((DBRepo)Application["database"]).GetUserByID(userID);
            gvPickedUser.DataSource = u;
            gvPickedUser.DataBind();
        }

        protected void btnUnregistered_Click(object sender, EventArgs e)
        {
            pnlRegistered.Visible = false;
            btnUnregistered.ForeColor = System.Drawing.Color.Green;
            pnlUnregistered.Visible = true;
        }
    }
}