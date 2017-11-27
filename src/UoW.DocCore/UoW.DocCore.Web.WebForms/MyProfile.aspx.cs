using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.DocCore.Web.WebForms
{
    public partial class MyProfile : System.Web.UI.Page
    {
        string currentUserEmailID;
        string VisitedUserEmailID;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUserEmailID = HttpContext.Current.User.Identity.Name;
            HiddenField hdnf_LoggedInUserEmailID = (HiddenField)Master.FindControl("DocCore_hdnf_LoggedInUserEmailID");
            HiddenField hdnf_CurrentUserEmailID = (HiddenField)Master.FindControl("DocCore_hdnf_CurrentUserEmailID");
            hdnf_LoggedInUserEmailID.Value = currentUserEmailID;
            UserDto user = null;
            Uri myUri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            string uid = HttpUtility.ParseQueryString(myUri.Query).Get("uid");

            if (string.IsNullOrEmpty(uid))
            {
                // My Profile
                user = DocCoreBDelegate.Instance.GetUserByEmailID(currentUserEmailID);
                hdnf_CurrentUserEmailID.Value = currentUserEmailID;
                uid = user.Uid.ToString();
            }
            else
            {
                //Friends Profile
                user = GetFriendProfile(uid);
                VisitedUserEmailID = user.EmailAddress;
                hdnf_CurrentUserEmailID.Value = user.EmailAddress;
            }

            if (user != null)
            {

                string FirstName = user.FirstName;
                string FullName = user.FullName;
                DateTime BirthDate = user.DateOfBirth ?? DateTime.Now;
                string DateOfBirth = BirthDate.ToString("d");
                string EmailAddress = user.EmailAddress;

                MyProfileName.Text = FullName;
                MyProfileHeading.Text = FirstName;
                MyProfileDOB.Text = DateOfBirth;
                MyProfileEmail.Text = EmailAddress;
                if (user.ProfilePhoto != null)
                {
                    var pieces = user.ProfilePhoto.Split(new[] { ',' }, 2);
                    byte[] imageBytes = Convert.FromBase64String(pieces[1]);
                    Session["ImageBytes" + uid] = imageBytes;
                    ImagePreview.ImageUrl = "~/ImageHandler.ashx?uid=" + uid;
                }

            }
        }

        private UserDto GetFriendProfile(string uid)
        {
            UserDto friend = null;
            if (!String.IsNullOrEmpty(uid))
            {
                int UserID = Int32.Parse(uid);
                friend = DocCoreBDelegate.Instance.GetUserByUid(UserID);
            }
            return friend;
        }
    }
}