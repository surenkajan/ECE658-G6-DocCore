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
                currentUserEmailID = HttpContext.Current.User.Identity.Name;
                //HiddenField hdnf_CurrentUserEmailID = (HiddenField)Master.FindControl("doccore_hdnf_CurrentUserEmailID");
                //hdnf_CurrentUserEmailID.Value = currentUserEmailID;
                UserDto user = DocCoreBDelegate.Instance.GetUserRoleByEmailID(currentUserEmailID);
                //if (user.ProjectRole == "Admin")
                //{
                    FriendProfiles new1 = new FriendProfiles();
                    ListBox1.DataSource = new1.FriendProfiless();
                    ListBox1.DataTextField = "FirstName";
                    //DropDownList1.DataValueField = "LastName";
                    ListBox1.DataBind();
                    LoadGridData();
                //}
                //else
                //{
                //    //hide
                //}

            }
        }

        private void LoadGridData()
        {
            List<UserDto> User = DocCoreBDelegate.Instance.GetAllManagers();
            //foreach (UserDto user in User)
            //{
                ListBox1.DataSource = User;
                ListBox1.DataTextField = "FullName";
                ListBox1.DataBind();
            //}
            List<UserDto> teamMembers = DocCoreBDelegate.Instance.GetAllTeamMembers();
            //foreach (UserDto member in teamMembers)
            //{
                ListBox2.DataSource = teamMembers;
                ListBox2.DataTextField = "FullName";
                ListBox2.DataBind();
            //}
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

        }

    }
}