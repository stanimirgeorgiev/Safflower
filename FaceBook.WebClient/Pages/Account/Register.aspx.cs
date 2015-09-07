namespace FaceBook.WebClient.Pages.Account
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using FaceBook.WebClient.Common;

    public partial class Register : System.Web.UI.Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var email = this.Email.Text;
            var password = this.Password.Text;
            var confirmPassword = this.ConfirmPassword.Text;

            var httpClient = new HttpClient();
            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("confirmPassword", confirmPassword),
                    new KeyValuePair<string, string>("username", email),
                    new KeyValuePair<string, string>("email", email)
                });

            var response = httpClient.PostAsync(EndPoints.Register, content).Result;

            if (response.IsSuccessStatusCode)
            {
                this.Response.Redirect("/Pages/WebContent/Home.aspx");
            }
            else
            {
                ErrorMessage.Text = response.Content.ReadAsStringAsync().Result;
                ErrorMessage.Visible = true;
            }

            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    IdentityHelper.SignIn(manager, user, isPersistent: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}
        }
    }
}