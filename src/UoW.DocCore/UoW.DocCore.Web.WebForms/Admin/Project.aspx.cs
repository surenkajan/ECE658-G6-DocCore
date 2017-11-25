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
                currentUserEmailID = HttpContext.Current.User.Identity.Name;
                //HiddenField hdnf_CurrentUserEmailID = (HiddenField)Master.FindControl("doccore_hdnf_CurrentUserEmailID");
                //hdnf_CurrentUserEmailID.Value = currentUserEmailID;
                UserDto user = DocCoreBDelegate.Instance.GetUserRoleByEmailID(currentUserEmailID);
                if (user.ProjectRole == "Admin")
                {
                    FriendProfiles new1 = new FriendProfiles();
                    ListBox1.DataSource = new1.FriendProfiless();
                    ListBox1.DataTextField = "FirstName";
                    //DropDownList1.DataValueField = "LastName";
                    ListBox1.DataBind();
                    LoadGridData();
                }
                else
                {
                    //hide
                }

            }
        }

        private void LoadGridData()
        {
            List<UserDto> User = DocCoreBDelegate.Instance.GetAllManagers();
            foreach (UserDto user in User)
            {
                ListBox1.DataSource = user;
                ListBox1.DataTextField = "FullName";
                ListBox1.DataBind();
            }
            List<UserDto> teamMembers = DocCoreBDelegate.Instance.GetAllTeamMembers();
            foreach (UserDto member in teamMembers)
            {
                ListBox2.DataSource = member;
                ListBox2.DataTextField = "FullName";
                ListBox2.DataBind();
            }
        }
        protected void CreateProject(object sender, EventArgs e)
        {
            //string currentUserEmailID = HttpContext.Current.User.Identity.Name;
            //int UserID = Int32.Parse(param1);
            //FriendRequestDto addfriend = new FriendRequestDto() { CurrentUserEmailID = currentUserEmailID, Uid = UserID };
            //int AddStatus = PictreBDelegate.Instance.InsertFriend(addfriend);
            //LoadGridData();
        }
        protected void DeleteProject(object sender, EventArgs e)
        {

        }

    }
}