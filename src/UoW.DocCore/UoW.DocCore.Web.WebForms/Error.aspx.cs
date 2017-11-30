using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.DocCore.Web.WebForms
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string msg = (string)(Session["ErrorCode"]);
            if(!string.IsNullOrEmpty(msg))
            {
                lblErrorDescription.Text = msg;
            }
        }

        protected void Close_Click(object sender, EventArgs e)
        {
            Response.Redirect("/home");
        }
    }
}