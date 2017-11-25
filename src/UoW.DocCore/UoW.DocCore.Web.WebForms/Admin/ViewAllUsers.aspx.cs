using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.DocCore.Web.WebForms
{
    public partial class ViewAllUsers : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridData();
            }
        }
        private void LoadGridData()
        {
            //I am adding dummy data here. You should bring data from your repository.
            DataTable dt = new DataTable();
            dt.Columns.Add("ImageUrl");
            dt.Columns.Add("Profile_Name");
            dt.Columns.Add("Action");


            for (int i = 0; i < 20; i++)
            {


                DataRow dr = dt.NewRow();
                dr["ImageUrl"] = "../Content/Images/friends.png";
                dr["Profile_Name"] = "User " + (i + 1);
                dr["Action"] = "Edit";
                string prof = dr["Profile_Name"].ToString();
                string textdata = txtSearch.ToString();
                // if (prof == textdata)

                //{

                dt.Rows.Add(dr);
                // }
            }
            gvCustomers.DataSource = dt;
            gvCustomers.DataBind();
        }

        protected void Search(object sender, EventArgs e)
        {
            this.LoadGridData();
        }
        protected void gvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].Text = Regex.Replace(e.Row.Cells[0].Text, txtSearch.Text.Trim(), delegate (Match match)
                //{
                //    return string.Format("<span style = 'background-color:#D9EDF7'>{0}</span>", match.Value);
                //}, RegexOptions.IgnoreCase);
            }
        }
        private void BindGrid()
        {
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        cmd.CommandText = "SELECT ContactName, City, Country FROM Customers WHERE ContactName LIKE '%' + @ContactName + '%'";
            //        cmd.Connection = con;
            //        cmd.Parameters.AddWithValue("@ContactName", txtSearch.Text.Trim());
            //        DataTable dt = new DataTable();
            //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            //        {
            //            sda.Fill(dt);
            //            gvCustomers.DataSource = dt;
            //            gvCustomers.DataBind();
            //        }
            //    }
            //}
        }

        //protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvCustomers.PageIndex = e.NewPageIndex;
        //    BindGrid();
        //}
    }
}