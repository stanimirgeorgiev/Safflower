namespace FaceBook.WebClient.Pages.WebContent
{
    using Common;
    using FaceBook.WebClient.Models.BindingModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    public partial class Search : System.Web.UI.Page
    {
        public ICollection<UserBindingModel> ListViewSearchedUsers_GetData()
        {
            var httpClient = new HttpClient();

            var userAccessToken = Session["AccessToken"];
            var bearer = "Bearer " + userAccessToken;

            var searchedKeyword = Request.QueryString["q"];
            var requestURL = EndPoints.SearchUser + searchedKeyword;
        
            httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

            var response = httpClient.GetAsync(requestURL).Result;
            var responseContent = response.Content.ReadAsAsync<ICollection<UserBindingModel>>().Result;

            return responseContent;
        }
    }
}