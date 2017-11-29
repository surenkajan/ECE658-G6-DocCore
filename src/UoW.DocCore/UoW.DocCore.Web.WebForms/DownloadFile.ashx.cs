using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UoW.DocCore.Web.WebForms
{
    /// <summary>
    /// Summary description for DownloadFile
    /// </summary>
    public class DownloadFile : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            HttpRequest request = context.Request;
            string DocID = request.QueryString["Docid"];
            string currentUserEmailID = HttpContext.Current.User.Identity.Name;
            DocumentDto document = DocCoreBDelegate.Instance.GetDocumentByDocID(DocID);
            //Check for permission - Doc is created by the user OR Shared with user

            //Decide the document is shared with current user
            //List<User> matches = document.SharedWith.Where(usr =>usr.EmailAddress == currentUserEmailID);
            bool isShared = document.SharedWith.Any(usr => usr.EmailAddress == currentUserEmailID);
            bool isCreated = (document.CreatedUser != null) ? document.CreatedUser.Equals(currentUserEmailID) : false;
            bool isModified = (document.ModifiedBy != null) ? document.ModifiedBy.Equals(currentUserEmailID) : false;

            if (isCreated || isModified || isShared)
            {
                DocumentDto documentContent = DocCoreBDelegate.Instance.GetDocumentWithContentByDocID(DocID);
                context.Response.Redirect("/home");
                response.ClearContent();
                response.Clear();
                //response.ContentType = "text/plain";
                response.ContentType = MIMEType.Get(documentContent.FileType);
                response.AddHeader("Content-Disposition", "attachment; filename=" + documentContent.FileName + ";");
                //response.TransmitFile(Server.MapPath("FileDownload.csv"));
                response.BinaryWrite(documentContent.FileData);
                response.Flush();
                response.End();
            }
            else
            {
                //Session["ErrorCode"] = 001;
                //Response.Redirect("/Error");
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class MIMEType
    {

        #region MIME type list
        private static readonly Dictionary<String, String> MimeTypeDict = new Dictionary<String, String>()
        {
                {      "pdf", "application/pdf" },
                {     "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                {     "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" }

        };
        #endregion

        #region Get
        /// <summary>
        /// Returns the mime type for the requested file extension. Returns
        /// the default application/octet-stream if the extension is not found.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static String Get(String extension)
        {
            return Get(extension, MimeTypeDict["bin"]);
        }

        /// <summary>
        /// Returns the mime type for the requested file extension. Returns the
        /// specified defaultMimeType if the extension is not found.
        /// </summary>
        /// <param name="extension"></param>
        /// <param name="defaultMimeType"></param>
        /// <returns></returns>
        public static String Get(String extension, String defaultMimeType)
        {
            if (extension.StartsWith("."))
                extension = extension.Remove(0, 1);

            if (MimeTypeDict.ContainsKey(extension))
                return MimeTypeDict[extension];
            else
                return defaultMimeType;
        }
        #endregion Get

    }
}