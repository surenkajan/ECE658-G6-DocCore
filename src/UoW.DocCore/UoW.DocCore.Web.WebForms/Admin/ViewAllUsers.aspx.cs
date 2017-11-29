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
            dt.Columns.Add("FullName");
            dt.Columns.Add("ProjectRole");
            dt.Columns.Add("Uid");
            dt.Columns.Add("Action");
            List<UserDto> user = DocCoreBDelegate.Instance.GetAllUserDetails();
            if (txtSearch.Text == "")
            {
                foreach (UserDto newuser in user)
                {
                    DataRow dr = dt.NewRow();
                    dr["FullName"] = newuser.FullName;
                    dr["ProjectRole"] = newuser.ProjectRole;
                    dr["Uid"] = newuser.Uid;
                    dr["Action"] = "Edit";



                    dt.Rows.Add(dr);
                    // }
                }
                gvCustomers.DataSource = dt;
                gvCustomers.DataBind();
            }
            else
            {
                foreach (UserDto newuser in user)
                {
                    if (newuser.FullName == txtSearch.Text)
                    {
                        DataRow dr = dt.NewRow();
                        dr["FullName"] = newuser.FullName;
                        dr["ProjectRole"] = newuser.ProjectRole;
                        dr["Uid"] = newuser.Uid;
                        dr["Action"] = "Edit";



                        dt.Rows.Add(dr);
                    }
                    // }
                }
                gvCustomers.DataSource = dt;
                gvCustomers.DataBind();

            }
        }


        protected void Search(object sender, EventArgs e)
        {
            LoadGridData();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("FullName");
            //dt.Columns.Add("ProjectRole");
            //dt.Columns.Add("Uid");
            //dt.Columns.Add("Action");
            //List<UserDto> user = DocCoreBDelegate.Instance.GetAllUserDetails();


            //    foreach (UserDto newuser in user)
            //    {
            //        if (newuser.FullName == txtSearch.Text)
            //        {
            //            DataRow dr = dt.NewRow();
            //            dr["FullName"] = newuser.FullName;
            //            dr["ProjectRole"] = newuser.ProjectRole;
            //            dr["Uid"] = newuser.Uid;
            //            dr["Action"] = "Edit";



            //            dt.Rows.Add(dr);
            //        }
            // }
            //}
            //gvCustomers.DataSource = dt;
            //gvCustomers.DataBind();

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
        //private void BindGrid()
        //{
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
        //}

        protected void gvCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCustomers.PageIndex = e.NewPageIndex;
            LoadGridData();
        }
    }
}