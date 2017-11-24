using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.DocCore.Web.WebForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                //using (SqlConnection con = new SqlConnection(constr))
                //{
                //using (SqlCommand cmd = new SqlCommand("SELECT CustomerId, Name FROM Customers"))
                //{
                //cmd.CommandType = CommandType.Text;
                //cmd.Connection = con;
                //con.Open();
                var products = new List<Product>();
                //products.Add(new Product() {  Name = "Admin"});
                products.Add(new Product() { Name = "Project Manager" });
                products.Add(new Product() { Name = "Team Member" });
                DropDownList1.DataSource = products;
                DropDownList1.DataTextField = "Name";
                //ddlCustomers.DataValueField = "CustomerId";
                DropDownList1.DataBind();
                //con.Close();
                //}
                ListBox1.DataSource = products;
                ListBox1.DataTextField = "Name";
                //DropDownList1.DataValueField = "LastName";
                ListBox1.DataBind();
            }
            DropDownList1.Items.Insert(0, new ListItem("--Select Customer--", "0"));
        }

        public class Product
        {

            public string Name { get; set; }


        }

        protected void DeleteProject(object sender, EventArgs e)
        {

        }

        protected void CreateProject(object sender, EventArgs e)
        {

        }
    }
}
