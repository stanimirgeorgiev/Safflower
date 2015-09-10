namespace FaceBook.WebClient.Pages.Account
{
    using Common;
    using FaceBook.WebClient.Models.BindingModels;
    using System.Net.Http;

    public partial class Profile : System.Web.UI.Page
    {
        public UserBindingModel FormViewUserProfile_GetItem(string id)
        {
            var httpClient = new HttpClient();
            var userAccessToken = Session["AccessToken"];
            var bearer = "Bearer " + userAccessToken;
            httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

            var response = httpClient.GetAsync(EndPoints.GetUserInfo).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsAsync<UserBindingModel>().Result;
                return responseContent;
            }

            return new UserBindingModel();
        }
    }
}