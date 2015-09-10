namespace FaceBook.WebClient
{
    using System;
    using System.Web.UI;

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
            }
            else
            {
                this.AnonymusHome.Visible = false;
                this.Register.Visible = false;
                this.Login.Visible = false;

                this.LoginHome.Visible = true;
                this.NewsFeed.Visible = true;
                this.PanelSearchBox.Visible = true;
            }
        }

        protected void ClickSearchBox(object sender, EventArgs e)
        {
            string queryParam = string.Format("?q={0}", this.SearchedQueryTextBox.Text);
            Response.Redirect("~/Pages/WebContent/Search" + queryParam);
        }
    }
}