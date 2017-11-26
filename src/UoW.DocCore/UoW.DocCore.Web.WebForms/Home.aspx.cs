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
                    
                    string fileName = DocumentUpload.FileName;
                    string fileExtension = System.IO.Path.GetExtension(fileName);
                    txtDocName.Text = fileName;
                    FileExtImage.ImageUrl = "\\Content\\Images\\ext\\" + fileExtension.Replace(".","").ToLower() + "256.png";
                    lblUploadedBy.Text = currentUserEmailID;
                    lblUploadedDate.Text = DateTime.Now.ToString("g");
                    lblDocSize.Text = DocumentUpload.FileBytes.Length.ToString();
                    //Consume the service and insert the document
                    DocumentDto document = new DocumentDto()
                    {
                        FileData = DocumentUpload.FileBytes,
                        FileName = DocumentUpload.FileName,
                        FileType = System.IO.Path.GetExtension(DocumentUpload.FileName).Replace(".", "").ToLower(),
                        FileSizeInKB = DocumentUpload.FileBytes.Length,
                        UploadedBy = currentUserEmailID,
                        UploadedTime = DateTime.Now,
                        IsCheckedIn = 0,
                        Modified = DateTime.Now,
                        ModifiedBy = currentUserEmailID
                    };

                    int addDocumentStatus = DocCoreBDelegate.Instance.AddDocument(document);

                    if(addDocumentStatus != -1)
                    {
                        //Retrieve the document 
                        Session["DocID"] = addDocumentStatus;
                        DocumentUpload.Visible = false;
                        UploadedDocumentDetailsPH.Visible = true;
                    }
                    else
                    {
                        Session["DocID"] = -1;
                        DocumentUpload.Visible = true;
                        UploadedDocumentDetailsPH.Visible = false;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            //Consume the service and insert the document
            int D_ID =  (int)(Session["DocID"]);

            if(D_ID != -1)
            {
                DocumentDto document = new DocumentDto()
                {
                    DocID = D_ID,
                    FileData = null,
                    FileName = txtDocName.Text,
                    FileSummary = txtFileDescription.Text,
                    UploadedBy = currentUserEmailID,
                    UploadedTime = DateTime.Now,
                    IsCheckedIn = 1,
                    Modified = DateTime.Now,
                    ModifiedBy = currentUserEmailID
                };

                int UpdatedDocID = DocCoreBDelegate.Instance.UpdateDocument(document);

                if (UpdatedDocID != -1)
                {
                    Response.Redirect("/MyProfile");
                }
                else
                {
                    Response.Redirect("/Home");
                }
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            UploadedDocumentDetailsPH.Visible = false;
            Response.Redirect("/Home");
        }
    }
}