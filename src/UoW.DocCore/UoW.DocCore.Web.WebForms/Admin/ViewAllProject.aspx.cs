﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.DocCore.Web.WebForms.Admin
{
    public partial class ViewAllProject : Page
    {
         

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                
                string currentUserEmailID;
                currentUserEmailID = HttpContext.Current.User.Identity.Name;
                HiddenField hdnf_CurrentUserEmailID = (HiddenField)Master.FindControl("DocCore_hdnf_CurrentUserEmailID");
                hdnf_CurrentUserEmailID.Value = currentUserEmailID;
                UserDto role = DocCoreBDelegate.Instance.GetUserRoleByEmailID(currentUserEmailID);
                if (role.ProjectRole == "Admin")
                {
                    //UserDto userNew = DocCoreBDelegate.Instance.GetUserRoleByEmailID(currentUserEmailID);
                    Uri myUri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
                    string uid = HttpUtility.ParseQueryString(myUri.Query).Get("Uid");


                    if (string.IsNullOrEmpty(uid))
                    {
                        List<ProjectDto> project = DocCoreBDelegate.Instance.GetAllProject();
                        DataList1.DataSource = project;
                     
 
                        //theDataList.DataBind();
                        DataList1.DataBind();
                            
                    }
                    else
                    {

                        int ID = Int32.Parse(uid);
                        ProjectDto project = DocCoreBDelegate.Instance.GetProjectDetailsByID(ID);
                        project.pID = ID;
                        List<ProjectDto> projectNew = new List<ProjectDto>();
                        projectNew.Add(project);
                       
                        DataList1.DataSource = projectNew;
                        DataList1.DataBind();

                        //    List<ProjectDto> projectNew = new List<ProjectDto>();
                        //    foreach (ProjectDto proj in project)
                        //    {
                        //        if (txtSearch.Text == proj.ProjectName)
                        //        {


                        //            projectNew.Add(proj);
                        //        }
                        //    }
                        //    DataList1.DataSource = projectNew;
                        //    DataList1.DataBind();
                        //}

                    }
                    //else
                    //{
                    //    List<ProjectDto> project = DocCoreBDelegate.Instance.GetAllProject();
                    //    DataList1.DataSource = project;
                    //    if (txtSearch.Text == "")
                    //    {
                    //        DataList1.DataBind();
                    //    }
                    //    else
                    //    {
                    //        List<ProjectDto> projectNew = new List<ProjectDto>();
                    //        foreach (ProjectDto proj in project)
                    //        {
                    //            if (txtSearch.Text == proj.ProjectName)
                    //            {


                    //                projectNew.Add(proj);
                    //            }
                    //        }
                    //        DataList1.DataSource = projectNew;
                    //        DataList1.DataBind();
                    //    }
                    //}
                }
                else
                {
                    Session["ErrorCode"] = "You are not Authorised to access this page";
                    Response.Redirect("~/Error.aspx");
                }
            }
        }
      
        protected void outerRep_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //DataListItem selectedDataListItem;
            HiddenField databaseKeyHiddenField;
            string databaseKey;
            if (e.Item.ItemType == ListItemType.Item || (e.Item.ItemType == ListItemType.AlternatingItem))
            {

                //var test = new List<Test>();
                //test.Add(new Test() { testName = "Bike1" });
                //test.Add(new Test() { testName = "Bike2" });
                //test.Add(new Test() { testName = "Bike3" });
                // databaseKeyHiddenField = (HiddenField)selectedDataListItem.FindControl("DatabaseKeyHiddenField");
                //databaseKey = databaseKeyHiddenField.Value;
                //System.Data.DataRowView drv = e.Item.DataItem as System.Data.DataRowView;

                databaseKeyHiddenField = e.Item.FindControl("HiddenField1") as HiddenField;
                databaseKey = databaseKeyHiddenField.Value;
                int ProjectID = Int32.Parse(databaseKey);


                List<UserDto> managers = DocCoreBDelegate.Instance.GetAllManagersByProjectID(ProjectID);
                List<UserDto> members = DocCoreBDelegate.Instance.GetAllTeamMembersByProjectID(ProjectID);
                DataList innerDataList = e.Item.FindControl("DataList2") as DataList;
                DataList innerDataList1 = e.Item.FindControl("DataList3") as DataList;

                innerDataList.DataSource = managers;
                innerDataList.DataBind();
                innerDataList1.DataSource = members;
                innerDataList1.DataBind();

                //Control tbx = this.FindControl("Button3");
                //tbx.ID = databaseKey;
            }
        }
        public class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }

            public double Price { get; set; }
        }
        public class Test
        {
            public string testName { get; set; }

        }

        protected void UpdateProject(object sender, EventArgs e)
        {
            //HiddenField pIDField;
            //string ProjectID;
            //pIDField = (HiddenField)FindControl("HiddenField2") as HiddenField;

            Button button = (Button)sender;
            string buttonId = button.ID;
            // ProjectID = pIDField.Value;
            int ProjID = Int32.Parse(buttonId);
            Response.Redirect("Project.aspx?Uid=" + ProjID);
        }

    }
}