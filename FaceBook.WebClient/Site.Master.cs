namespace FaceBook.WebClient
{
    using System;
    using System.Web.UI;

    public partial class SiteMaster : MasterPage
    {
        protected void ClickSearchBox(object sender, EventArgs e)
        {
            string queryParam = string.Format("?q={0}", this.SearchedQueryTextBox.Text);
            Response.Redirect("~/Pages/WebContent/Search" + queryParam);
        }
    }
}