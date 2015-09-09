using FaceBook.WebClient.Common;
using FaceBook.WebClient.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FaceBook.WebClient.Pages.WebContent
{
    public partial class Friends : System.Web.UI.Page
    {
        public ICollection<UserBindingModel> ListViewFriends_GetData()
        {
            var httpClient = new HttpClient();

            var userAccessToken = Session["AccessToken"];
            var bearer = "Bearer " + userAccessToken;
            var requestURL = EndPoints.GetUserFriends;
            httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

            var response = httpClient.GetAsync(requestURL).Result;
            var responseContent = response.Content.ReadAsAsync<ICollection<UserBindingModel>>().Result;

            return responseContent;
        }

        protected void GoToUserWall(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            this.Response.Redirect("/Pages/WebContent/UserWall.aspx?uid=" + e.CommandName);
        }
    }
}