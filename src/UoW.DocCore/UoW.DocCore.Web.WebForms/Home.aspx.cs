using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.DocCore.Web.WebForms
{
    public partial class Home : System.Web.UI.Page
    {
        string currentUserEmailID;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUserEmailID = HttpContext.Current.User.Identity.Name;
            UploadedDocumentDetailsPH.Visible = false;
            if (!IsPostBack)
            {

            }
            else
            {
                if (IsPostBack && DocumentUpload.HasFile)
                {
                    //Populate details of Uploaded Documents
                    UploadedDocumentDetailsPH.Visible = true;
                    string fileName = DocumentUpload.FileName;
                    string fileExtension = System.IO.Path.GetExtension(fileName);
                    lblDocName.Text = fileName;
                    FileExtImage.ImageUrl = "\\Content\\Images\\ext\\" + fileExtension.Replace(".","").ToLower() + "256.png";
                    lblUploadedBy.Text = currentUserEmailID;
                    lblUploadedDate.Text = DateTime.Now.ToString("g");
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Consume the service and insert the document

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            UploadedDocumentDetailsPH.Visible = false;
            Response.Redirect("/Home");
        }
    }
}