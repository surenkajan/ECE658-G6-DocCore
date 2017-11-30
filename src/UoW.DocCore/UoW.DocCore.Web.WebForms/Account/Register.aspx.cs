using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using UoW.DocCore.Web.WebForms.Models;
using System.Collections.Generic;

namespace UoW.DocCore.Web.WebForms.Account
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //ErrorMessage.Visible = false;

            //Retrieve the Security questions:
            List<SecurityQuestionDto> questionsList = DocCoreBDelegate.Instance.GetSecurityQuestions();
            if (questionsList != null)
            {
                SQuestion1.Text = questionsList[0].Question;
                SQuestion2.Text = questionsList[1].Question;
            }

            //Redirect if the user is already loggedin
            //string CurrentEmailID = (string)(Session["s_CurrentUserEmailID"]);
            string LoggedInUserEmailID = HttpContext.Current.User.Identity.Name;
            if (!string.IsNullOrEmpty(LoggedInUserEmailID))
            {
                Response.Redirect("/Home/Home");
            }
        }

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
                int AddStatus = DocCoreBDelegate.Instance.InsertUser(newUser);

                //Add Answers to the security questions
                List<SecurityAnswerPair> questionsAnswers = new List<SecurityAnswerPair>();
                SecurityAnswersDto answers = new SecurityAnswersDto()
                {
                    UserEmailID = Email.Text,
                    //QuestionAnswer = new Dictionary<string, string>
                    //{
                    //    {SQuestion1.Text,SQuestion1Ans.Text},
                    //    {SQuestion2.Text,SQuestion2Ans.Text}
                    //}
                    QuestionsAnswers = new List<SecurityAnswerPair> {
                        new SecurityAnswerPair(){
                            Question = new SecurityQuestion(){ Question = SQuestion1.Text},
                            Answer =  SQuestion1Ans.Text
                        },
                        new SecurityAnswerPair(){
                            Question = new SecurityQuestion(){ Question = SQuestion2.Text},
                            Answer =  SQuestion2Ans.Text
                        }
                    }
                };
                int AddAnsStatus = DocCoreBDelegate.Instance.InsertSecurityAnswers(answers);

                UserDto newUserForAccess = new UserDto()
                {
                    EmailAddress = Email.Text,
                    ProjectRole = "Admin"
                };
                int AddAccessStatus = DocCoreBDelegate.Instance.CreateUserAccess(newUserForAccess);

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void CreateUserCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Login");
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