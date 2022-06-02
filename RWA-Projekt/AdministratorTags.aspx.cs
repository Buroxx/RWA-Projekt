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
    public partial class AdministratorTags : System.Web.UI.Page
    {
        IList<Tags> tags = new List<Tags>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
            {
                tags = (IList<Tags>)ViewState["tags"];
            }
        }

        private void LoadData()
        {
            tags = ((DBRepo)Application["database"]).GetAllTags();
            gvTags.DataSource = tags;
            gvTags.DataBind();
            
            IList<String> tagTypes = new List<String>();
            tagTypes = ((DBRepo)Application["database"]).GetAllTagTypes();
            int counter = 0;
            foreach (string tag in tagTypes)
            {
                ddlCategory.Items.Insert(counter,tag);
                counter++;
            }

            ViewState["tags"] = tags;
        }

        protected void btnDeleteModal_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int tagID = int.Parse(btn.CommandArgument);
            pnlModal.Visible = true;
            ViewState["tagID"] = tagID;
        }

        protected void btnDeleteTag_Click(object sender, EventArgs e)
        {
            int tagID = (int)ViewState["tagID"];
            ((DBRepo)Application["database"]).DeleteTagByID(tagID);
            Response.Redirect("AdministratorTags.aspx");
        }

        protected void btnAddNewTagPanel_Click(object sender, EventArgs e)
        {
            pnlAddNewTag.Visible = true;
            btnAddNewTagPanel.Visible = false;
            btnAddNewTag.Visible = true;
        }

        protected void btnAddNewTag_Click(object sender, EventArgs e)
        {
            int typeID = ddlCategory.SelectedIndex + 1;
            string nameHrv = tbTagNameHrv.Text;
            string nameEng = tbTagNameEng.Text;

            for (int i = 0; i < tags.Count(); i++)
            {
                if (nameHrv.ToUpper() == tags[i].Name.ToUpper() || nameEng.ToUpper() == tags[i].NameEng.ToUpper())
                {
                    pnlAlreadyExists.Visible = true;
                    return;
                }
            }

            ((DBRepo)Application["database"]).AddNewTag(typeID, nameHrv, nameEng);

            Response.Redirect("AdministratorTags.aspx");
        }
    }
}