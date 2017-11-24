using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.DocCore.Web.WebForms.Account
{
    public partial class Settings : System.Web.UI.Page
    {
        string currentUserEmailID;
        UserDto Currentuser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUserEmailID = HttpContext.Current.User.Identity.Name;
            Session["ImageBytes"] = null;
            Currentuser = PictreBDelegate.Instance.GetUserByEmailID(currentUserEmailID);
            if (!IsPostBack)
            {
                //Retrieve User Personal Details

                if (Currentuser != null)
                {
                    FName.Text = Currentuser.FirstName;
                    LName.Text = Currentuser.LastName;
                    FullName.Text = Currentuser.FullName;
                    Gender.Text = Currentuser.Sex;
                    //DOB.Text = String.Format("MMMM d, yyyy", Currentuser.DateOfBirth);
                    //ImagePreview = Base64ToImage(Currentuser.ProfilePhoto);
                    //ImagePreview.Attributes["src"] = Currentuser.ProfilePhoto;
                    if (Currentuser.ProfilePhoto != null)
                    {
                        var pieces = Currentuser.ProfilePhoto.Split(new[] { ',' }, 2);
                        byte[] imageBytes = Convert.FromBase64String(pieces[1]);
                        //byte[] imageBytes = Convert.FromBase64String(Currentuser.ProfilePhoto);
                        Session["ImageBytes"] = imageBytes;
                        ImagePreview.ImageUrl = "~/ImageHandler.ashx";
                    }
                }
            }
            else
            {
                if (IsPostBack && ProfilePhotoUpload.PostedFile != null)
                {
                    if (ProfilePhotoUpload.PostedFile.FileName.Length > 0)
                    {
                        Session["ImageBytes"] = ProfilePhotoUpload.FileBytes;
                        ImagePreview.ImageUrl = "~/ImageHandler.ashx";

                        UserDto user_Updated = new UserDto()
                        {
                            EmailAddress = Currentuser.EmailAddress,
                            DateOfBirth = Currentuser.DateOfBirth,
                            FirstName = Currentuser.FirstName,
                            FullName = Currentuser.FullName,
                            LastName = Currentuser.LastName,
                            Sex = Currentuser.Sex,
                            UserName = Currentuser.UserName,
                            ProfilePhoto = Convert.ToBase64String(ProfilePhotoUpload.FileBytes)
                        };
                        int updateuserStatus = PictreBDelegate.Instance.UpdateUser(user_Updated);

                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Update the User Details
            UserDto user_Updated = new UserDto()
            {
                EmailAddress = Currentuser.EmailAddress,
                DateOfBirth = Currentuser.DateOfBirth,
                FirstName = FName.Text,
                FullName = FullName.Text,
                LastName = LName.Text,
                Sex = Gender.Text,
                UserName = Currentuser.UserName,
                ProfilePhoto = Currentuser.ProfilePhoto.Split(new[] { ',' }, 2)[1]
            };
            int updateuserStatus = PictreBDelegate.Instance.UpdateUser(user_Updated);
            
            lblSaveStatus.Visible = true;
            if (updateuserStatus != -1)
            {
                lblSaveStatus.Text = "Your Profile is successfully saved.";
                lblSaveStatus.ForeColor = Color.Green;
            }
            else
            {
                lblSaveStatus.Text = "Something went wrong. Please try again.";
                lblSaveStatus.ForeColor = Color.Red;
            }

            //Render the image again
            var pieces = Currentuser.ProfilePhoto.Split(new[] { ',' }, 2);
            byte[] imageBytes = Convert.FromBase64String(pieces[1]);
            Session["ImageBytes"] = imageBytes;
            ImagePreview.ImageUrl = "~/ImageHandler.ashx";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home/Home");
        }
    }
}