using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using UoW.DocCore.Web.WebForms.Models;

namespace UoW.DocCore.Web.WebForms
{
    public partial class UserRegistration : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentUserEmailID;



            //If the user does not have access, Redirect to Error Page
            //if()
            //{
            //Session["ErrorCode"] = 001;
            //    Response.Redirect("/Error");
            //}

            if (!this.IsPostBack)
            {
                PasswordSection.Visible = false;
                PlaceHolder2.Visible = false;
                PlaceHolder1.Visible = false;
                currentUserEmailID = HttpContext.Current.User.Identity.Name;
                //HiddenField hdnf_CurrentUserEmailID = (HiddenField)Master.FindControl("DocCore_hdnf_CurrentUserEmailID");
                //hdnf_CurrentUserEmailID.Value = currentUserEmailID;
                UserDto user = DocCoreBDelegate.Instance.GetUserRoleByEmailID(currentUserEmailID);
                Uri myUri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
                string uid = HttpUtility.ParseQueryString(myUri.Query).Get("Uid");
                uid = "4";
                //if (user.ProjectRole == "Admin")
                //{
               
                //PopulateAllRoles();
                if (string.IsNullOrEmpty(uid))
                {
                    // My Profile
                    PasswordSection.Visible = true;
                    PlaceHolder1.Visible = true;
                    //PopulateAllProjects();

                }
                else
                {

                    LoadData(uid);

                }

                //}


                
            }
            
        }

        private void PopulateAllProjects()
        {
            //List<ProjectDto> AllProject = DocCoreBDelegate.Instance.GetAllProject();
            
            //lstBoxProject.DataSource = AllProject;
            //lstBoxProject.DataTextField = "ProjectName";
            ////DropDownList1.DataValueField = "LastName";
            //lstBoxProject.DataBind();
        }
        private void LoadData(string uid)
        {
            PasswordSection.Visible = false;
            PlaceHolder2.Visible = true;
            int UserID = Int32.Parse(uid);
            UserDto user = DocCoreBDelegate.Instance.GetUserByUid(UserID);
            FName.Text = user.FirstName;
            LName.Text = user.LastName;
            FullName.Text = user.FullName;
            string gender = user.Sex;
            Gender.SelectedValue = gender;
            DateTime date = user.DateOfBirth ?? DateTime.Now;
            //Gender.SelectedIndex = Gender.Items.IndexOf(Gender.Items.FindByText(gender));
            DOB.Text = user.DateOfBirth != null ? date.ToString("dd/MM/yyyy") : "";
            Email.Text = user.EmailAddress;
            UserDto user1 = DocCoreBDelegate.Instance.GetAllUserDetailsByUid(UserID);
            ddlRole.SelectedValue = user1.ProjectRole;
           List<ProjectDto> user2 = DocCoreBDelegate.Instance.GetProjectDetailsByUid(UserID);
            //List<ProjectDto> AllProject = DocCoreBDelegate.Instance.GetAllProject();
            //List<string> lstdays = new List<string>();
           //foreach (ProjectDto proj1 in user2)
           // {
           //     lstdays.Add(proj1.ProjectName);
           // }
            //foreach (ProjectDto dto in AllProject)
            //{
            //    bool flag = false;
            //    foreach (ProjectDto proj1 in user2)
            //    {
            //        if (proj1.ProjectName.Trim().Equals(dto.ProjectName.Trim()))
            //        {
            //            flag = true;
            //            break;



            //        }

            //    }
            //    if (flag == false)
            //    {
            //        lstdays.Add(dto.ProjectName);
            //    }


            //}
            //lstBoxProject.DataSource = lstdays;
            ////lstBoxProject.DataTextField = "ProjectName";
            //lstBoxProject.DataBind();
            //for (int I = lstBoxProject.Items.Count - 1; I >= 0; I += -1)
            //{

            //    bool flag2 = false;
            //    String MyStr = lstBoxProject.Items[I].ToString();
            //    foreach (ProjectDto proj1 in user2)
            //    {
            //        if (proj1.ProjectName.Trim().Equals(MyStr.Trim()))
            //        {
            //            flag2 = true;
            //            break;
            //        }
            //    }
            //    if (flag2 == true)
            //    {
            //        lstBoxProject.Items[I].Selected = true;
            //    }



            //}




        }
        //private void PopulateAllRoles()
        //{
        //    var products = new List<Product>();
        //    products.Add(new Product() { Name = "Manager" });
        //    products.Add(new Product() { Name = "TeamMember" });
        //    ddlRole.DataSource = products;
        //    ddlRole.DataTextField = "Name";
        //    ddlRole.DataBind();
        //    ddlRole.Items.Insert(0, new ListItem("--Select Customer--", "0"));
        //}

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                //Add user details to DocCore DB
                //Add user
                UserDto newUser = new UserDto()
                {
                    EmailAddress = Email.Text,
                    DateOfBirth = Convert.ToDateTime(DOB.Text),
                    FirstName = FName.Text,
                    FullName = FullName.Text,
                    LastName = LName.Text,
                    Sex = Gender.Text,
                    UserName = Email.Text,
                    ProfilePhoto = ImageToBase64()
                };
                UserDto UserAccess = new UserDto()
                {
                    EmailAddress = Email.Text,
                    ProjectRole = ddlRole.Text
                };
                int AddStatus = DocCoreBDelegate.Instance.InsertUser(newUser);
                int status = DocCoreBDelegate.Instance.CreateUserAccess(UserAccess);

                //signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                RegisterStatusPH.Visible = true;
                DocCoreRegisterUserPH.Visible = false;
                ClearData();
                registerStatus.Text = "New account has been created successfully and is ready to use";
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
            
        }

        protected void UpdateProject(object sender, EventArgs e)
        {
            //Response.Redirect("/Account/Login");
        }

        public class Product
        {

            public string Name { get; set; }


        }

        protected void DeleteProject(object sender, EventArgs e)
        {


            string EmailAddress = Email.Text;
            int status = DocCoreBDelegate.Instance.DeleteUserByEmailID(EmailAddress);
            RegisterStatusPH.Visible = true;
            DocCoreRegisterUserPH.Visible = false;
            ClearData();
            registerStatus.Text = "The user has been successfully deleted!";

        }

        protected void CreateProject(object sender, EventArgs e)
        {

        }
        protected void CreateUserCancel_Click(object sender, EventArgs e)
        {

        }
        protected void ClearData()
        {
            
            FName.Text ="";
            LName.Text = "";
            FullName.Text = "";
            string gender = "Gender:";
            Gender.SelectedValue = gender;

            //Gender.SelectedIndex = Gender.Items.IndexOf(Gender.Items.FindByText(gender));
            DOB.Text = "";
            Email.Text = "";
            
            ddlRole.SelectedValue = "Project Role:";
        }
        public string ImageToBase64()
        {
            string base64String = null;

            //TODO:
            base64String = @"/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAMCAgMCAgMDAwMEAwMEBQgFBQQEBQoHBwYIDAoMDAsKCwsNDhIQDQ4RDgsLEBYQERMUFRUVDA8XGBYUGBIUFRT / 2wBDAQMEBAUEBQkFBQkUDQsNFBQUFBQU
FBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBT / wAARCADwAPADAREA
AhEBAxEB / 8QAHAABAAIDAQEBAAAAAAAAAAAAAAYHAQQFAgMI / 8QAORAAAgECAwQIBAILAQAAAAAA
AAECAwQFBhEHEiExEyJBUWFxgZFCobHBUtEUI0NicnOCkrLC4fD / xAAZAQEAAwEBAAAAAAAAAAAA
AAAAAwQFAgH / xAAhEQEAAgICAQUBAAAAAAAAAAAAAQIDMQQRIRIiMkFRM//aAAwDAQACEQMRAD8A
/ ZBuqQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
ADMU5SUYpyk + UUtX7AdCllvFq8N6nhl3KPf0MiOclI + 3vpn8KuW8WoQ3qmGXcY9 / QyEZKT9npn8c
    + ScZOMk4yXNPg / YkeMAAAAAAAAAAAAAAAAAAAAAAAAAAAA7uAZMxLMOk6NNUbZ / t6vCL8lzfp7kN
81ab27rWbJ3hmy7C7VJ3c6t7U7U5bkPZcfmUrci868JYxx9pPYYPY4XHdtLSjb + NOCTfrzK9rWtu
UkREabhy9ANO / wAHscUju3dpRuPGpBNr15nVbWrqXkxE7RjE9l2F3SbtJ1bKp2aS34ez4 / MsV5F4
35RzjidIJj + TMSy9rOtTVa2X7elxivNc16 + 5dpmrfW0VqzVwiZwAAAAAAAAAAAAAAAAAAAAAAAJ9
kXIcb2FPEcShrQfWo28vj / el4dy7Slmzde2qalO / MrMjFQioxSUUtEl2GenZAAAAAABiUVOLjJJx
a0afaBWeeshxsoVMRw2GlBdatbx + D96Ph3rsNDDm79tkF6deYQEuoQAAAAAAAAAAAAAAAAAAAAEg
yRgUcex2nTqretqK6WqvxJPhH1fy1IM1 / RXuHdI7ldSSikktEuxGStMgAAAAAAAAMNKSaa1T7GBS
md8CjgOO1KdJbttWXS0l + FPmvR / LQ1sN / XXuVW8dS4BO4AAAAAAAAAAAAAAAAAAAAsLZHRbrYnV0
4JU4a / 3Mo8qdQmx / aySgnAAAAAAAAAACttrlFqthlXTg1Uhr / ay / xZ3CDJ9K9LyEAAAAAAAAAAAA
AAAAAAAC2tl1mqGXHW061etKTfguqvozM5E936WMceExKqUAAAAAAAAAAIdtRs1Xy4q2nWoVoyT8
H1X9UWuPPV + kWSPCpTTVwAAAAAAAAAAAAAAAAAAALd2YXKrZYjT140a04Neb3l9TM5EdXWcekuKq
QAAAAAAAAAAIjtPuVRyxKnrxrVoQS8nvP6Frjx3dHk0qI01YAAAAAAAAAAAAAAAAAAACwtkl5pWx
G0faoVV80 / sUeVGpTY / uFklBOAAAAAAAAAAFbbW7zWth1ouxTqv5Jfcv8WNygyfUK9LyEAAAAAAA
AAAAAAAAAAAACY7LXNZjqbsZODt5KTS4LjHTX2KvJ + CTHtbRmLIAAAAAAAAAAVLtSc3mOnvRkoK3
iotrg + MtdPc0 + N8FbJtDi0jAAAAAAAAAAAAAAAAAAAAtvZdbwpZbdWKW / VrTcn28OC + hmcmff0sY
48JgVUoAAAAAAAAAAQ / ajbwq5bVWSW / SrQcX28eD + pa40 +/ pFkjwqQ01cAAAAAAAAAAAAAAAAAAA
C09lF4quDXVtr1qNbe9JL80zO5Me6JWMc + Ok4KaUAAAAAAAAAAIPtXvFSwa1ttevWrb3pFfm0XON
HumUWSfHSrDRVwAAAAAAAAAAAAAAAAAAAJXs2xRWGY40ZPSndQdLjy3ucfuvUrcivdO / xJjnqVwG
WsgAAAAAAAAABT + 0nFFf5jlRi9adrBUuH4ucvsvQ1OPXqnf6rZJ7lFCyjAAAAAAAAAAAAAAAAAAA
  AzCcqc4zhJxnFpqSejT7xsW1s4zDWxmwuaN3WlWuqM9d6fNwfL2aaMzPjikxMaWKW7jymBVSgAAA
AAAAEP2j5hrYNYW1G0rSo3Vaeu9DmoLn7tpFrBji8zM6RXt1HhUs5yqTlOcnKcm25N6tvvNNXYAA
AAAAAAAAAAAAAAAAAAAA7OU8deX8bo3Mm + gf6usl2wfN + nB + hFlp669Oqz6ZXhCcakIzjJSjJapr
k0Y629AAAAAAA8znGnCU5SUYxWrb5JAUdmzHXmDG61zFvoF + rop9kF2 + vF + psYqeivSpafVLjkrk
AAAAAAAAAAAAAAAAAAAAAALmBdmRG5ZSw3Vtvo3xf8TMjN / SVqnxh3yF2AAAAABwM9txyliWjafR
riv4kTYf6Q4v8ZUm + ZrqoAAAAAAAAAAAAAAAAAAAAAAALmBduRFplLDf5f8AszIzf0lap8Yd4hdg
AAAAAcHPa1yliX8v / ZE2H + kOL / GVJPma6qAAAAAAAAAAAAAAAAAAAAAAAC5gXlk + 3qWuWcOpVYSp
1I0VvQktGvNGPlmJvMwt11DskToAAAAADjZwt6l1lnEaVKEqlSVF7sIrVvyRLimIvEy5tqVGvmbC
oAAAAAAAAAAAAAAAAAAAAAAfS2tqt5XhRoU5Va03pGEFq2zyZiI7k2tTJ + z + lg + 5d36jXvucYc4U
vLvfj7d5nZc838V0sVp15lMyolAAAAAAAAIZnDZ / Sxjfu7BRoX3OUOUKvn3Px9 + 8t4s808W0itTv
zCq7m2q2dedGvTlSrQekoTWjTNGJiY7hX0 + Z6AAAAAAAAAAAAAAAAAB7pUp16sadKEqlSXBQgm2 /
RCZiPMiW4NszxLEN2d242FF9k + tUf9K5erKtuRWuvKSMcztYOXspWGW4SdtBzrSWkq9TjN + HgvBF
G + W2TaetYrp2iJ0AAAAAAAAAAHFzDlKwzJCLuYOFaK0jWpPSa8PFeDJaZbY9ObVi21fYzszxLD96
do439FdkOrUX9L5 + jL1eRW2 / CCccxpEqtKdCrKnVhKnUjwcJppr0ZaiYnzCN4AAAAAAAAAAAAABs
WOH3OJ11RtaFS4qv4aa108 + 71ObWisdyREzpOME2VVam7UxS46KPPoKD1l6y5L09ynfkxqsJox / q
eYVgVhgtLcs7aFHvklrKXm3xZTte1 / lKaIiNN84egAAAAAAAAAAAAAAGhiuBWGNUty8toVu6TWko
+ TXFHdb2p8ZeTETtA8b2VVae9Uwu46WPPoK70l6S5P19y5Tkxq0IZx / iD32H3OGV3RuqFS3qr4ai
018u / wBC5W0WjuEMxMba50AAAAAAAAH3s7K4xC4jQtqM69aXKEFq / wD3ieTMVjuSI70nuAbLNd2t
i1Xx / R6L / wApfl7lG / J + qJox / qfWGG2uF0FRtKELekvhgtNfPvKc2m09ymiIjTZOXoAAAAAAAAAA
AAAAAAAAAGtf4ba4pQdG7oQuKT + Ga108u46i01nuHkxE7QHH9lmm9Wwmr4 / o9Z / 4y / P3LlOT9XQz
j / EBvLK4w + 4lQuaM6FaPOE1o / wDvmXomLR3CGY62 + J6AAAAAk2U8j3OY2q9Ru2sE + NXTrT8Ir78v
Mr5c0Y / Ebd1pNlrYRgdlgdt0NnQjSj8UucpPvb7TNte157ssxERpvnD0AAAAAAAAAAAAAAAAAAAA
AAAANDF8DssctuhvKEasfhlylF96fYd1vak91eTETtVObMj3OXG69Nu5sG + FXTrQ8JL78vI0sWaM
nidq1qelGSw4AAHSy5haxnHLOzlruVJ9fT8K4v5IjyW9FZl7WO56XtRowt6UKdOChTglGMYrRJLs
MeZ78yuPZ4AAAAAAAAAAAAAAAAAAAAAAAAAAAeK1GFxSnTqQU6c04yjJapp9h7E9eYFE5jwtYNjl
5Zx13Kc + pr + F8V8mbGO3rrFlO0dT05pI8AJpsqt41cfr1ZcXSt3u + bkkVOTPt6S49rXM1YAAAAAA
AAAAAAAAAAAAAAAAAAAAAAAKo2q28aWP0KseDq263vNSaNLjT7elfJtCy2if / 9k = ";
            //string path = "/../../Content/Images/ProfileAvator.png";
            //using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
            //{
            //    using (MemoryStream m = new MemoryStream())
            //    {
            //        image.Save(m, image.RawFormat);
            //        byte[] imageBytes = m.ToArray();
            //        base64String = Convert.ToBase64String(imageBytes);
            //    }
            //}
            return base64String;
        }

    }
}
