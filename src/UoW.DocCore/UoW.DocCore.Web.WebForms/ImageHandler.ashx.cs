using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UoW.DocCore.Web.WebForms
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //Checking whether the imagebytes session variable have anything else not doing anything
            HttpRequest request = context.Request;
            //if ((context.Session["ImageBytes"]) != null)
            //if (!string.IsNullOrEmpty(request.QueryString["uid"]))
            //{
            string id = request.QueryString["uid"];

            //byte[] image = (byte[])(context.Session["ImageBytes" + id]);
            byte[] image;
            if (string.IsNullOrEmpty(id))
            {
                image = (byte[])(context.Session["ImageBytes"]);
            }
            else
            {
                image = (byte[])(context.Session["ImageBytes" + id]);
            }
            context.Response.ContentType = "image/JPEG";
            //context.Response.BinaryWrite(image);
            //context.Response.OutputStream.Write(image, 0, image.Length);
            context.Response.BinaryWrite(image);
            context.Response.AddHeader("Content-Type", "image/JPEG");
            context.Response.AddHeader("Content-Length", image.LongLength.ToString());
            context.Response.End();
            context.Response.Close();
            //}
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}