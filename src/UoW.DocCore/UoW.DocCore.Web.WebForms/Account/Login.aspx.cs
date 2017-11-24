using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using UoW.DocCore.Web.WebForms.Models;

namespace UoW.DocCore.Web.WebForms.Account
{
    public partial class Login : Page
    {
        string currentUserEmailID;
        protected void Page_Load(object sender, EventArgs e)
        {
            RememberMe.Visible = false;
            lbl_RememberMe.Visible = false;
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        //User Must enter the security questions if it the first time to log in
                        // Find first time user by checking the Security questions and Answers
                        //Retrieve Answers of Security Questions
                        currentUserEmailID = Email.Text;
                        SecurityAnswersDto answersList = DocCoreBDelegate.Instance.GetSecurityQuestionsAnswers(currentUserEmailID);
                        if((answersList == null) ||
                            (answersList.QuestionsAnswers.Count == 0) ||
                            (answersList != null && (answersList.QuestionsAnswers[0] == null || answersList.QuestionsAnswers[1] == null)) || 
                            string.IsNullOrEmpty(answersList.QuestionsAnswers[0].Answer) || string.IsNullOrEmpty(answersList.QuestionsAnswers[1].Answer))
                        {
                            //TODO: Have to handle the Redirect URL here
                            Response.Redirect("/Account/Settings");
                        }

                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}