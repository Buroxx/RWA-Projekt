using rwaLib.Dal;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWA_Projekt
{
    public partial class NewApartment : System.Web.UI.Page
    {
        IList<City> cities = new List<City>();
        IList<Owner> owners = new List<Owner>();
        IList<Tags> tags = new List<Tags>();
        IList<Tags> newTags = new List<Tags>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadData();
            }
            else
            {
                
            }
        }


        private void LoadData()
        {
            User owner = (User)Session["user"];
            cities = ((DBRepo)Application["database"]).GetAllCities();
            owners = ((DBRepo)Application["database"]).GetAllOwners();

            finishAddingTags.Visible = false;
            pnlAddNewPicture.Visible = false;
            rptImgs.Visible = false;
            pnlFinish.Visible = false;

            foreach (City city in cities)
            {
                ddlCity.Items.Add(city.Name);
            }
            foreach (Owner ow in owners)
            {
                ddlOwner.Items.Add(ow.Name);
            }

        }

        protected void btnAddNewApartment_Click(object sender, EventArgs e)
        {
            Apartment apartment = new Apartment
            {
                Name = tbName.Text,
                NameEng = tbNameEng.Text,
                Price = tbPrice.Text,
                MaxAdults = int.Parse(tbAdults.Text),
                MaxChildren = int.Parse(tbChildren.Text),
                TotalRooms = int.Parse(tbRooms.Text),
                BeachDistance = tbBeachDistance.Text,
                Address = tbAddress.Text,
                CityId = ddlCity.SelectedIndex + 1,
                OwnerID = ddlOwner.SelectedIndex + 1
            };


            ((DBRepo)Application["database"]).AddNewApartment(apartment);
            pnlInfoForm.Visible = false;
            ViewState["owner"] = apartment.OwnerID;
            ViewState["nameEng"] = tbNameEng.Text;

            NextStep();

        }

        private void NextStep()
        {
            finishAddingTags.Visible = true;
            pnlTags.Visible = true;
            pnlPickNewTag.Visible = true;
            int ownerID = (int)ViewState["owner"];
            string nameEng = (string)ViewState["nameEng"];
            int apartmentID = ((DBRepo)Application["database"]).GetNewApartment(ownerID, nameEng);
            ViewState["apartmentID"] = apartmentID;
            tags = ((DBRepo)Application["database"]).GetTagsByApartmentID(apartmentID);
            newTags = ((DBRepo)Application["database"]).GetUnusedTagsOnTaggedApartmentByID(apartmentID);
            ViewState["tags"] = tags;
            if (tags.Count == 0)
            {
                pnlTags.Visible = false;
                pnlPickNewTag.Visible = true;
                rptPickNewTag.DataSource = newTags;
                rptPickNewTag.DataBind();
            }
            else
            {
                rptTags.DataSource = tags;
                rptTags.DataBind();
                rptPickNewTag.DataSource = newTags;
                rptPickNewTag.DataBind();

                pnlTags.Visible = true;
                pnlPickNewTag.Visible = true;
            }
        }

        protected void btnPickTag_Click(object sender, EventArgs e)
        {
            Button btnPicked = (Button)sender;
            int tagID = int.Parse(btnPicked.CommandArgument);
            int apartmentID = (int)ViewState["apartmentID"];
            ((DBRepo)Application["database"]).AddNewTagToApartment(tagID, apartmentID);
            NextStep();
        }

        protected void btnDeleteTag_Click(object sender, EventArgs e)
        {
            int tagID = (int)ViewState["pickedTagToDelete"];
            int apartmentID = (int)ViewState["apartmentID"];
            ((DBRepo)Application["database"]).DeleteApartmentTagByID(tagID, apartmentID);
            IList<Tags> tags = ((DBRepo)Application["database"]).GetTagsByApartmentID(apartmentID);
            rptTags.DataSource = tags;
            rptTags.DataBind();
            pnlModal.Visible = false;
            NextStep();
        }

        protected void btnAreYouSure_Click(object sender, EventArgs e)
        {
            Button btnPicked = (Button)sender;
            int tagID = int.Parse(btnPicked.CommandArgument);
            pnlModal.Visible = true;
            ViewState["pickedTagToDelete"] = tagID;
        }

        protected void finishAddingTags_Click(object sender, EventArgs e)
        {
            pnlModal.Visible = false;
            pnlPickNewTag.Visible = false;
            pnlTags.Visible = false;
            pnlAddNewPicture.Visible = true;
            finishAddingTags.Visible = false;
        }

        protected void btnChooseFile_Click(object sender, EventArgs e)
        {
            int apartmentID = (int)ViewState["apartmentID"];
            string folderPath = Request.PhysicalApplicationPath + "/Images/";
            string fullPath = folderPath + Path.GetFileName(FileUpload.FileName);
            string forDataBase = "/Images/" + Path.GetFileName(FileUpload.FileName);
            if (File.Exists(fullPath))
            {
                return;
            }

            if (String.IsNullOrEmpty(Path.GetFileName(FileUpload.FileName)))
            {
                return;
            }
            else
            {
                FileUpload.SaveAs(fullPath);
            }
            ((DBRepo)Application["database"]).SaveNewPicture(apartmentID, forDataBase);
            
            IList<ApartmentPicture> pictureList = new List<ApartmentPicture>();
            pictureList = ((DBRepo)Application["database"]).GetApartmentPicturesByID(apartmentID);
            rptImgs.DataSource = pictureList;
            rptImgs.DataBind();
            rptImgs.Visible = true;

        }

        protected void pickRepresentative_Click(object sender, EventArgs e)
        {
            int apartmentID = (int)ViewState["apartmentID"];
            IList<ApartmentPicture> pictureList = new List<ApartmentPicture>();
            pictureList = ((DBRepo)Application["database"]).GetApartmentPicturesByID(apartmentID);
            Button btnPicked = (Button)sender;
            int newID = int.Parse(btnPicked.CommandArgument);
            int oldID = GetOldID(pictureList);
            ((DBRepo)Application["database"]).SetRepresentativePicture(newID, oldID);
            pnlFinish.Visible = true;
        }

        private int GetOldID(IList<ApartmentPicture> pictureList)
        {
            int temp = 0;

            for (int i = 0; i < pictureList.Count(); i++)
            {
                if (pictureList[i].IsRepresentative)
                {
                    temp = pictureList[i].Id;
                }
            }
            return temp;
        }

        protected void finish_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministratorApartments.aspx");
        }
    }
}