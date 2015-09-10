namespace FaceBook.WebClient
{
    using Common;
    using System;
    using System.Net.Http;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = Session["userId"] as string;
            var username = Session["UserName"] as string;
            var accessToken = Session["AccessToken"] as string;

            if (userId == null || username == null || accessToken == null)
            {
                this.AnonymusHome.Visible = true;
                this.Register.Visible = true;
                this.Login.Visible = true;

                this.LoginHome.Visible = false;
                this.NewsFeed.Visible = false;
                this.PanelSearchBox.Visible = false;
                this.DropDownUserOptions.Visible = false;
            }
            else
            {
                this.AnonymusHome.Visible = false;
                this.Register.Visible = false;
                this.Login.Visible = false;

                this.LoginHome.Visible = true;
                this.NewsFeed.Visible = true;
                this.PanelSearchBox.Visible = true;
                this.DropDownUserOptions.Visible = true;
            }
        }

        protected void ClickSearchBox(object sender, EventArgs e)
        {
            string queryParam = string.Format("?q={0}", this.SearchedQueryTextBox.Text);
            Response.Redirect("~/Pages/WebContent/Search" + queryParam);
        }

        protected void DropDownUserOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dd = sender as DropDownList;
            var selectedUrl = dd.SelectedValue;

            if (String.IsNullOrEmpty(selectedUrl))
            {
                var httpClient = new HttpClient();
                var userAccessToken = Session["AccessToken"];
                var bearer = "Bearer " + userAccessToken;
                httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

                var response = httpClient.PostAsync(EndPoints.Logout, null).Result;
                Session["userId"] = null;
                Session["UserName"] = null;
                Session["AccessToken"] = null;

                Response.Redirect("~/Pages/Account/Login.aspx");
            }

            Response.Redirect(selectedUrl);
        }
    }
}