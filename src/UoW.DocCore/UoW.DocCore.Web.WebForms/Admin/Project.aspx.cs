using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.DocCore.Web.WebForms.Admin
{
    public partial class Project : System.Web.UI.Page
    {
        public class FriendProfiles
        {
            List<Names> _Friendnames = new List<Names>();

            public List<Names> FriendProfiless()
            {
                _Friendnames.Add(new Names()
                {
                    FirstName = "Brindha",
                    LastName = 1,

                });
                _Friendnames.Add(new Names()
                {
                    FirstName = "Enlil",
                    LastName = 2,

                });
                _Friendnames.Add(new Names()
                {
                    FirstName = "Kajaruban",
                    LastName = 3,

                });
                _Friendnames.Add(new Names()
                {
                    FirstName = "Shitij",
                    LastName = 4,

                });
                _Friendnames.Add(new Names()
                {
                    FirstName = "Jaspreet",
                    LastName = 5,

                });
                return _Friendnames;
            }

            public class Names
            {
                public string FirstName { get; set; }
                public int LastName { get; set; }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FriendProfiles new1 = new FriendProfiles();
                ListBox1.DataSource = new1.FriendProfiless();
                ListBox1.DataTextField = "FirstName";
                //DropDownList1.DataValueField = "LastName";
                ListBox1.DataBind();

            }
        }
        protected void CreateProject(object sender, EventArgs e)
        {
            string message = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    message += item.Text + " " + item.Value + "\\n";
                }
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
        }
        protected void DeleteProject(object sender, EventArgs e)
        {

        }

    }
}