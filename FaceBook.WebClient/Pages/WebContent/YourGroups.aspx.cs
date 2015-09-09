using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FaceBook.WebClient.Common;
using FaceBook.WebClient.Models.BindingModels;

namespace FaceBook.WebClient.Pages.WebContent
{
    public partial class YourGroups : System.Web.UI.Page
    {
        public ICollection<GroupBindingModel> GetUserGroups()
        {
            var httpClient = new HttpClient();

            var userAccessToken = Session["AccessToken"];
            var bearer = "Bearer " + userAccessToken;
            var requestURL = EndPoints.GetUserGroups;
            httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

            var response = httpClient.GetAsync(requestURL).Result;
            var responseContent = response.Content.ReadAsAsync<ICollection<GroupBindingModel>>().Result;

            return responseContent;
        }

        protected void GoToGroupWall(object sender, CommandEventArgs e)
        {
            this.Response.Redirect("/Pages/WebContent/GroupWall.aspx?uid=" + e.CommandName);
        }
    }
}