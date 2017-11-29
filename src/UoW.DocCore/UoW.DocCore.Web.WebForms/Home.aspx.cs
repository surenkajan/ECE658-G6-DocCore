using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
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
            HiddenField hdnf_CurrentUserEmailID = (HiddenField)Master.FindControl("DocCore_hdnf_LoggedInUserEmailID");
            hdnf_CurrentUserEmailID.Value = currentUserEmailID;
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
                    FileExtImage.ImageUrl = "\\Content\\Images\\extNew\\" + fileExtension.Replace(".", "").ToLower() + "-icon-128x128.png";
                    lblUploadedBy.Text = currentUserEmailID;
                    lblUploadedDate.Text = DateTime.Now.ToString("g");
                    lblDocSize.Text = DocumentUpload.FileBytes.Length.ToString();
                    //Consume the service and insert the document
                    string ext = System.IO.Path.GetExtension(DocumentUpload.FileName).Replace(".", "").ToLower();


                    DocumentDto document = new DocumentDto()
                    {
                        FileData = DocumentUpload.FileBytes,
                        FileName = DocumentUpload.FileName,
                        FileType = (ext != null && !ext.Equals(string.Empty)) ? ext : "file",
                        FileSizeInKB = DocumentUpload.FileBytes.Length,
                        UploadedBy = currentUserEmailID,
                        UploadedTime = DateTime.Now,
                        IsCheckedIn = 0,
                        Modified = DateTime.Now,
                        ModifiedBy = currentUserEmailID
                    };

                    int addDocumentStatus = DocCoreBDelegate.Instance.AddDocument(document);

                    if (addDocumentStatus != -1)
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

        //[WebMethod]
        //public static int ProcessIT(string DocID)
        //{
        //    try
        //    {
        //        //WebClient req = new WebClient();
        //        //HttpResponse response = HttpContext.Current.Response;
        //        //response.Clear();
        //        //response.ClearContent();
        //        //response.ClearHeaders();
        //        //response.Buffer = true;
        //        //response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath(strURL) + "\"");
        //        //DocumentDto document = DocCoreBDelegate.Instance.GetDocumentWithContentByDocID(DocID);

        //        //byte[] data = document.FileData;
        //        //response.BinaryWrite(data);
        //        //response.End();
        //        //ImagePreview.ImageUrl = "~/ImageHandler.ashx?uid=" + uid;

        //        //Calling IHttpHandler for Download
        //        //Response.Redirect("~/DownloadFile.ashx?Docid=" + DocID);

        //        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        //        string currentUserEmailID = HttpContext.Current.User.Identity.Name;
        //        DocumentDto document = DocCoreBDelegate.Instance.GetDocumentByDocID(DocID);
        //        //Check for permission - Doc is created by the user OR Shared with user

        //        //Decide the document is shared with current user
        //        //List<User> matches = document.SharedWith.Where(usr =>usr.EmailAddress == currentUserEmailID);
        //        bool isShared = document.SharedWith.Any(usr => usr.EmailAddress == currentUserEmailID);

        //        if (document.CreatedUser.Equals(currentUserEmailID) || document.ModifiedBy.Equals(currentUserEmailID) || isShared)
        //        {
        //            DocumentDto documentContent = DocCoreBDelegate.Instance.GetDocumentWithContentByDocID(DocID);

        //            response.ClearContent();
        //            response.Clear();
        //            response.ContentType = "text/plain";
        //            response.AddHeader("Content-Disposition", "attachment; filename=" + documentContent.FileName + ";");
        //            //response.TransmitFile(Server.MapPath("FileDownload.csv"));
        //            response.BinaryWrite(documentContent.FileData);
        //            response.Flush();
        //            response.End();
        //        }
        //        else
        //        {
        //            //Session["ErrorCode"] = 001;
        //            //Response.Redirect("/Error");
        //            return -1;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return -1;
        //    }
        //    return 0;
        //}

        //btnTest_Click
        protected void btnTest_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DownloadFile.ashx?Docid=" + 43);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            string values = txtSharedWith.Text;
            List<User> SharedUsers = new List<User>();
            foreach (string val in values.Split(','))
            {
                SharedUsers.Add(new User() {
                    FullName = val
                });
            }

            //Consume the service and insert the document
            int D_ID = (int)(Session["DocID"]);

            if (D_ID != -1)
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
                    ModifiedBy = currentUserEmailID,
                    SharedWith = SharedUsers
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