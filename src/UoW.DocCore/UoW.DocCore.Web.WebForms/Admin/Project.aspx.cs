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
        string currentUserEmailID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SuccessMesg.Visible = false;
                DeleteMsg.Visible = false;
                currentUserEmailID = HttpContext.Current.User.Identity.Name;
                //HiddenField hdnf_CurrentUserEmailID = (HiddenField)Master.FindControl("doccore_hdnf_CurrentUserEmailID");
                //hdnf_CurrentUserEmailID.Value = currentUserEmailID;
                UserDto user = DocCoreBDelegate.Instance.GetUserRoleByEmailID(currentUserEmailID);
                Uri myUri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
                string uid = HttpUtility.ParseQueryString(myUri.Query).Get("uid");
                uid = "15";
                //if (user.ProjectRole == "Admin")
                //{
                //FriendProfiles new1 = new FriendProfiles();
                //ListBox1.DataSource = new1.FriendProfiless();
                //ListBox1.DataTextField = "FirstName";
                ////DropDownList1.DataValueField = "LastName";
                //ListBox1.DataBind();
                if (string.IsNullOrEmpty(uid))
                {
                    // My Profile
                    LoadGridDataFirst();
                }
                else
                {

                    LoadGridData(uid);

                }
            }

        }
        private void LoadGridDataFirst()
        {
            List<UserDto> User = DocCoreBDelegate.Instance.GetAllManagers();
            ListBox1.DataSource = User;
            ListBox1.DataTextField = "FullName";
            ListBox1.DataBind();
            List<UserDto> teamMembers = DocCoreBDelegate.Instance.GetAllTeamMembers();
            
                ListBox2.DataSource = teamMembers;
                ListBox2.DataTextField = "FullName";
                ListBox2.DataBind();

        }
        private void LoadGridData(string uID)
        {
            if (!String.IsNullOrEmpty(uID))
            {
                int ProjectID = Int32.Parse(uID);
                ProjectDto project = DocCoreBDelegate.Instance.GetProjectDetailsByID(ProjectID);
                TextBox1.Text = project.ProjectName;
                string listboxvalues = project.ProjectManager;
                List<string> lstdays = new List<string>();
                string[] newDays = listboxvalues.Split(',');

               

                foreach (string d in newDays)
                {
                    lstdays.Add(d);  //add single day to days List
                    // ListBox1.Items.FindByValue(d);
                }
 
                List<UserDto> User = DocCoreBDelegate.Instance.GetAllManagers();
               foreach (UserDto  dto in User)
                {
                    bool flag = false;
                    foreach (string d in newDays)
                    {
                        if (d.Trim().Equals(dto.FullName.Trim()))
                        {
                            flag = true;
                            break;
                           


                        }
                        
                    }if (flag== false)
                    {
                        lstdays.Add(dto.FullName);
                    }

                    
                 }
                ListBox1.DataSource = lstdays;
                ListBox1.DataBind();
                for (int I = ListBox1.Items.Count - 1; I >= 0; I += -1)
                {

                    bool flag2 = false;
                    String MyStr = ListBox1.Items[I].ToString();
                    foreach (string d in newDays)
                    {
                        if (d.Trim().Equals(MyStr.Trim()))
                        {
                            flag2 = true;
                            break;
                        }
                    }
                    if (flag2 == true)
                    {
                        ListBox1.Items[I].Selected = true;
                    }



                }







                string members = project.TeamMember;
                List<string> memberlist = new List<string>();
                string[] memberArray = members.Split(',');

                foreach (string i in memberArray)
                {
                    memberlist.Add(i);  //add single day to days List
                }
               
              
                List<UserDto> teamMembers = DocCoreBDelegate.Instance.GetAllTeamMembers();
                
                foreach (UserDto dto in teamMembers)
                {
                    bool flag1 = false;
                    foreach (string d in memberArray)
                    {
                        
                            if (d.Trim().Equals(dto.FullName.Trim()))
                            {
                                flag1 = true;
                                break;



                            }

                    }
                        if (flag1 == false)
                        {
                           memberlist.Add(dto.FullName);
                        }

                }
                ListBox2.DataSource = memberlist;
                ListBox2.DataBind();
                for (int I = ListBox2.Items.Count - 1; I >= 0; I += -1)
                {

                    bool flag3 = false;
                    String MyStr = ListBox2.Items[I].ToString();
                    foreach (string d in memberArray)
                    {
                        if (d.Trim().Equals(MyStr.Trim()))
                        {
                            flag3 = true;
                            break;
                        }
                    }
                    if (flag3 == true)
                    {
                        ListBox2.Items[I].Selected = true;
                    }



                }
            }
             
        }
        protected void CreateProject(object sender, EventArgs e)
        {

            //string currentUserEmailID = HttpContext.Current.User.Identity.Name;
            //int UserID = Int32.Parse(param1);
            string projectName = TextBox1.Text;
           
            List<string> list = new List<string>();
            if (ListBox1.Items.Count > 0)
            {
                for (int i = 0; i < ListBox1.Items.Count; i++)
                {
                    if (ListBox1.Items[i].Selected)
                    {
                        string selectedItem = ListBox1.Items[i].Text;
                        list.Add(selectedItem);
                        //insert command
                    }
                }
            }
            string managers = String.Join(",", list.ToArray());
           
            List<string> list2 = new List<string>();
            if (ListBox2.Items.Count > 0)
            {
                for (int i = 0; i < ListBox2.Items.Count; i++)
                {
                    if (ListBox2.Items[i].Selected)
                    {
                        string selectedItem2 = ListBox2.Items[i].Text;
                        list2.Add(selectedItem2);
                        //insert command
                    }
                }
            }
            string members = String.Join(",", list2.ToArray());
            ProjectDto project = new ProjectDto() { ProjectName = projectName, ProjectManager = managers, TeamMember = members };
            int AddStatus = DocCoreBDelegate.Instance.CreateProject(project);
            //LoadGridData();
            TextBox1.Text = "";
            for (int I = ListBox1.Items.Count - 1; I >= 0; I += -1)
            {
                if (ListBox1.Items[I].Selected)
                {
                    ListBox1.Items.RemoveAt(I);
                }
            }
            for (int I = ListBox2.Items.Count - 1; I >= 0; I += -1)
            {
                if (ListBox2.Items[I].Selected)
                {
                    ListBox2.Items.RemoveAt(I);
                }
            }
            SuccessMesg.Visible = true;

        }
        protected void DeleteProject(object sender, EventArgs e)
        {
            Uri myUri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            string uid = HttpUtility.ParseQueryString(myUri.Query).Get("uid");
            uid = "9";
            int ProjectID = Int32.Parse(uid);
            int k = DocCoreBDelegate.Instance.DeleteProjectByProjectID(ProjectID);
            if (k!=-1)
            {
                DeleteMsg.Visible = true;
                TextBox1.Text = "";
                for (int I = ListBox1.Items.Count - 1; I >= 0; I += -1)
                {
                    if (ListBox1.Items[I].Selected)
                    {
                        ListBox1.Items.RemoveAt(I);
                    }
                }
                for (int I = ListBox2.Items.Count - 1; I >= 0; I += -1)
                {
                    if (ListBox2.Items[I].Selected)
                    {
                        ListBox2.Items.RemoveAt(I);
                    }
                }

            }
        }

    }
}