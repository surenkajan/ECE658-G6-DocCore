using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.DocCore.Web.WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: Need to fix this. Change the default behaviour to home page. Redirect is not effective.
            Response.Redirect("/Home");
        }
    }
}