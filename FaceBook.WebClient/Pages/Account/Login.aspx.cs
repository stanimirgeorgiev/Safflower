namespace FaceBook.WebClient.Pages.Account
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web;
    using System.Web.UI;
    using FaceBook.WebClient.Common;
    using System.Web.UI.WebControls;
    using Models.BindingModels;

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";

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
                var email = this.Email.Text;
                var password = this.Password.Text;
                
                var httpClient = new HttpClient();
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", email),
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("confirmPassword", password),
                    new KeyValuePair<string, string>("grant_type", "password")
                });

                var response = httpClient.PostAsync(EndPoints.Login, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var loginData = response.Content.ReadAsAsync<LoginBindingModel>().Result;

                    var httpClientNested = new HttpClient();
                    httpClientNested.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginData.Access_Token);
                    var responseNested = httpClientNested.GetAsync(EndPoints.GetUserInfo).Result;

                    var userInfo = responseNested.Content.ReadAsAsync<FullUserProfileData>().Result;

                    Session["UserId"] = userInfo.UserId;
                    Session["UserName"] = loginData.UserName;
                    Session["AccessToken"] = loginData.Access_Token;

                    this.Response.Redirect("/Pages/WebContent/Home.aspx");
                }
                else
                {
                    FailureText.Text = response.Content.ReadAsStringAsync().Result;
                    ErrorMessage.Visible = true;
                }
                //// This doen't count login failures towards account lockout
                //// To enable password failures to trigger lockout, change to shouldLockout: true
                //var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                //switch (result)
                //{
                //    case SignInStatus.Success:
                //        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                //        break;
                //    case SignInStatus.LockedOut:
                //        Response.Redirect("/Account/Lockout");
                //        break;
                //    case SignInStatus.RequiresVerification:
                //        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                //                                        Request.QueryString["ReturnUrl"],
                //                                        RememberMe.Checked),
                //                          true);
                //        break;
                //    case SignInStatus.Failure:
                //    default:
                //        FailureText.Text = "Invalid login attempt";
                //        ErrorMessage.Visible = true;
                //        break;
            }
        }
    }
}
