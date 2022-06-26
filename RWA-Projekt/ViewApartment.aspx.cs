using rwaLib.Dal;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace RWA_Projekt
{
    public partial class ViewApartment : System.Web.UI.Page
    {
        private IList<ApartmentPicture> pictureList;
        private Apartment apartment;
        private IList<User> users;
        private int apartmentID;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadData();
            }
            else
            {
                MaintainScrollPositionOnPostBack = true;
                btnRegistered.ForeColor = System.Drawing.Color.Black;
                btnUnregistered.ForeColor = System.Drawing.Color.Black;
                pnlUnregistered.Visible = false;
                pnlRegistered.Visible = false;
                OldSession();
                pnlModal.Visible = false;
                pnlAddNewPicture.Visible = false;
            }

        }

        private void OldSession()
        {
            pictureList = (IList<ApartmentPicture>)ViewState["pictureList"];
            apartment = (Apartment)ViewState["apartment"];
            users = (IList<User>)ViewState["user"];
            apartmentID = (int)Session["ApartmentID"];
        }

        private void LoadData()
        {
            pnlButtonAddTag.Visible = false;
            pnlRegistered.Visible = false;
            pnlRegisteredDetails.Visible = false;
            pnlAddNewPicture.Visible = false;

            ddlStatus.Items.Insert(0, "Occupied");
            ddlStatus.Items.Insert(1, "Reserved");
            ddlStatus.Items.Insert(2, "Vacant");
            ddlStatus.SelectedIndex = 2;

            apartmentID = (int)Session["ApartmentID"];
            apartment = ((DBRepo)Application["database"]).GetApartmentByID(apartmentID);
            LoadFormInfo(apartment);

            users = ((DBRepo)Application["database"]).GetAllUsers();

            pictureList = ((DBRepo)Application["database"]).GetApartmentPicturesByID(apartmentID);
            pictureList = SortPictures(pictureList);

            rptImgs.DataSource = pictureList;
            rptImgs.DataBind();


            ViewState["apartment"] = apartment;
            ViewState["pictureList"] = pictureList;
            ViewState["users"] = users;
        }


        private IList<ApartmentPicture> SortPictures(IList<ApartmentPicture> pictureList)
        {
            for (int i = 0; i < pictureList.Count(); i++)
            {
                if (pictureList[i].IsRepresentative)
                {
                    ApartmentPicture temp = pictureList[i];
                    pictureList.RemoveAt(i);
                    pictureList.Insert(0, temp);
                }
            }
            return pictureList;
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedValue == "Vacant")
            {
                pnlOption.Visible = false;
                pnlSaveCancel.Visible = true;
            }
            else
            {
                pnlOption.Visible = true;
                pnlSaveCancel.Visible = false;
            }
        }

        protected void btnRegistered_Click(object sender, EventArgs e)
        {

            IList<User> users = (IList<User>)ViewState["users"];
            rptUsers.DataSource = users;
            rptUsers.DataBind();
            btnRegistered.ForeColor = System.Drawing.Color.Red;
            pnlRegistered.Visible = true;
            gvAddedUser.Visible = false;
            pnlAddUnregisteredBTN.Visible = false;
        }

        protected void PickPerson_Click(object sender, EventArgs e)
        {
            LinkButton btnPicked = (LinkButton)sender;
            int userID = int.Parse(btnPicked.CommandArgument);
            pnlRegistered.Visible = false;
            IList<User> u = ((DBRepo)Application["database"]).GetUserByID(userID);
            gvPickedUser.DataSource = u;
            gvPickedUser.DataBind();
            gvPickedUser.Visible = true;
            pnlBtnAddRegisteredUser.Visible = true;
            ViewState["pickedRegisteredUserID"] = u[0].Id;
        }

        protected void btnUnregistered_Click(object sender, EventArgs e)
        {
            gvPickedUser.Visible = false;
            gvPickedUser.DataSource = null;
            pnlUnregistered.Visible = true;
            pnlRegistered.Visible = false;
            pnlBtnAddRegisteredUser.Visible = false;
            btnUnregistered.ForeColor = System.Drawing.Color.Red;

        }

        protected void btnRepresentative_Click(object sender, EventArgs e)
        {
            rptRepresentativePictures.DataSource = pictureList;
            rptRepresentativePictures.DataBind();
            pnlRepresentativePictures.Visible = true;
            
            pnlEditImages.Visible = false;
            pnlAddNewPicture.Visible = false;
            pnlTags.Visible = false;
            pnlButtonAddTag.Visible = false;
            pnlPickNewTag.Visible = false;
        }

        

        protected void lbRepresentativeChange_Click(object sender, EventArgs e)
        {
            LinkButton btnPicked = (LinkButton)sender;
            int newID = int.Parse(btnPicked.CommandArgument);
            int oldID = GetOldID(pictureList);
            pnlRepresentativePictures.Visible = false;
            ((DBRepo)Application["database"]).SetRepresentativePicture(newID, oldID);
            Response.Redirect("ViewApartment.aspx");
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

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            IList<User> user = new List<User>();

            User u = new User
            {
                UserName = tbFirstName.Text + " " + tbLastName.Text,
                Email = tbEmail.Text,
                PhoneNumber = tbPhoneNumber.Text,
                Address = tbAddress.Text
            };

            string details = tbDetails.Text;
            user.Add(u);

            gvAddedUser.DataSource = user;
            gvAddedUser.DataBind();
            gvAddedUser.Visible = true;
            pnlSaveCancel.Visible = true;
            pnlAddUnregisteredBTN.Visible = true;
        }

        protected void btnTag_Click(object sender, EventArgs e)
        {
            IList<Tags> tags = ((DBRepo)Application["database"]).GetTagsByApartmentID(apartmentID);
            rptTags.DataSource = tags;
            rptTags.DataBind();
            rptTags.Visible = true;
            pnlButtonAddTag.Visible = true;
            pnlTags.Visible = true;
            pnlPickNewTag.Visible = true;

            pnlRepresentativePictures.Visible = false;
            pnlEditImages.Visible = false;
            pnlAddNewPicture.Visible = false;
        }


        protected void btnDeleteTag_Click(object sender, EventArgs e)
        {
            pnlModal.Visible = false;
            int tagID = (int)ViewState["pickedTagToDelete"];
            ((DBRepo)Application["database"]).DeleteApartmentTagByID(tagID, apartmentID);
            IList<Tags> tags = ((DBRepo)Application["database"]).GetTagsByApartmentID(apartmentID);
            rptTags.DataSource = tags;
            rptTags.DataBind();
        }

        protected void btnAddTag_Click(object sender, EventArgs e)
        {
            IList<Tags> tags = ((DBRepo)Application["database"]).GetUnusedTagsOnTaggedApartmentByID(apartmentID);
            rptPickNewTag.DataSource = tags;
            rptPickNewTag.DataBind();
            pnlPickNewTag.Visible = true;
            rptPickNewTag.Visible = true;
            pnlButtonAddTag.Visible = false;
        }

        protected void btnPickTag_Click(object sender, EventArgs e)
        {
            Button btnPicked = (Button)sender;
            int tagID = int.Parse(btnPicked.CommandArgument);
            ((DBRepo)Application["database"]).AddNewTagToApartment(tagID, apartmentID);
            rptPickNewTag.Visible = false;
            rptTags.Visible = false;
        }

        protected void btnResetForm_Click(object sender, EventArgs e)
        {
            LoadFormInfo(apartment);
        }

        private void LoadFormInfo(Apartment apartment)
        {
            tbName.Text = apartment.Name;
            tbPrice.Text = apartment.Price;
            tbAdults.Text = apartment.MaxAdults.ToString();
            tbChildren.Text = apartment.MaxChildren.ToString();
            tbRooms.Text = apartment.TotalRooms.ToString();
            tbBeachDistance.Text = apartment.BeachDistance.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            apartmentID = (int)Session["ApartmentID"];

            Apartment newInfo = new Apartment
            {
                Name = tbName.Text,
                Price = tbPrice.Text,
                MaxAdults = int.Parse(tbAdults.Text),
                MaxChildren = int.Parse(tbChildren.Text),
                TotalRooms = int.Parse(tbRooms.Text),
                BeachDistance = tbBeachDistance.Text
            };
            ((DBRepo)Application["database"]).UpdateApartmentInfo(newInfo, apartmentID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministratorApartments.aspx");
        }

        protected void btnAddUnregisteredUser_Click(object sender, EventArgs e)
        {

            apartmentID = (int)Session["ApartmentID"];

            User u = new User
            {
                UserName = tbFirstName.Text + tbLastName.Text,
                Email = tbEmail.Text,
                PhoneNumber = tbPhoneNumber.Text,
                Address = tbAddress.Text
            };
            string details = tbDetails.Text;
            ((DBRepo)Application["database"]).UnregisteredApartmentReservation(u, details, apartmentID);
            gvAddedUser.Visible = false;
            pnlAddUnregisteredBTN.Visible = false;
        }

        protected void btnAddRegisteredUser_Click(object sender, EventArgs e)
        {
            apartmentID = (int)Session["ApartmentID"];
            int userID = (int)ViewState["pickedRegisteredUserID"];
            string details = tbRegisteredDetails.Text;
            ((DBRepo)Application["database"]).RegisteredApartmentReservation(userID, apartmentID, details);
            pnlRegisteredDetails.Visible = false;
            pnlBtnAddRegisteredUser.Visible = false;
            gvPickedUser.Visible = false;
        }

        protected void btnAreYouSure_Click(object sender, EventArgs e)
        {
            Button btnPicked = (Button)sender;
            int tagID = int.Parse(btnPicked.CommandArgument);
            pnlModal.Visible = true;
            ViewState["pickedTagToDelete"] = tagID;
        }

        protected void btnEditPictures_Click(object sender, EventArgs e)
        {
            int apartmentID = (int)Session["ApartmentID"];
            pnlEditImages.Visible = true;
            rptDeleteImage.DataSource = pictureList;
            rptDeleteImage.DataBind();

            pnlRepresentativePictures.Visible = false;
            pnlAddNewPicture.Visible = false;
            pnlTags.Visible = false;
            pnlButtonAddTag.Visible = false;
            pnlPickNewTag.Visible = false;
            pnlAddNewPicture.Visible = false;

        }

        protected void btnDeleteImageChose_Click(object sender, EventArgs e)
        {
            Button btnPicked = (Button)sender;
            int pictureID = int.Parse(btnPicked.CommandArgument);
            string path = btnPicked.CommandName.ToString();
            ViewState["pickedImageToDeleteID"] = pictureID;
            ViewState["pickedImageToDeletePath"] = path;

            pnlImageDelete.Visible = true;

        }

        protected void btnDeleteImage_Click(object sender, EventArgs e)
        {
            int pictureID = (int)ViewState["pickedImageToDeleteID"];
            string path = Request.PhysicalApplicationPath + ViewState["pickedImageToDeletePath"].ToString();

            ((DBRepo)Application["database"]).DeleteApartmentPictureByID(apartmentID, pictureID);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else
            {
                Response.Redirect("ViewApartment.aspx");
            }

            Response.Redirect("ViewApartment.aspx");

        }

        protected void btnChooseFile_Click(object sender, EventArgs e)
        {
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
            Response.Redirect("ViewApartment.aspx");
        }

        protected void btnAddPictures_Click(object sender, EventArgs e)
        {
            pnlAddNewPicture.Visible = true;

            pnlRepresentativePictures.Visible = false;
            pnlTags.Visible = false;
            pnlButtonAddTag.Visible = false;
            pnlPickNewTag.Visible = false;
            pnlEditImages.Visible = false;
        }
    }
}