namespace FaceBook.WebClient.Pages.Account
{
    using Common;
    using FaceBook.WebClient.Models.BindingModels;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    public partial class Profile : System.Web.UI.Page
    {
        public FullUserProfileData FormViewUserProfile_GetItem(string id)
        {
            var httpClient = new HttpClient();
            var userAccessToken = Session["AccessToken"];
            var bearer = "Bearer " + userAccessToken;
            httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

            var response = httpClient.GetAsync(EndPoints.GetUserInfo).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsAsync<FullUserProfileData>().Result;
                return responseContent;
            }

            return new FullUserProfileData();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormViewUserProfile_UpdateItem(int id)
        {
            FullUserProfileData item = null;
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var userAccessToken = Session["AccessToken"];
                var bearer = "Bearer " + userAccessToken;
                httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

            var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Email", item.Email),
                    new KeyValuePair<string, string>("FirstName", item.FirstName),
                    new KeyValuePair<string, string>("MiddleName", item.MiddleName),
                    new KeyValuePair<string, string>("FamilyName", item.FamilyName),
                    new KeyValuePair<string, string>("PhoneNumber", item.PhoneNumber),
                    new KeyValuePair<string, string>("Town", item.Town),
                    new KeyValuePair<string, string>("RelationshipStatus", item.RelationshipStatus.ToString()),
                    new KeyValuePair<string, string>("BornDate", item.BornDate.ToString()),
                    new KeyValuePair<string, string>("Gender", item.Gender.ToString()),
                    new KeyValuePair<string, string>("InterestedIn", item.InterestedIn.ToString()),
                    new KeyValuePair<string, string>("DetailsAboutYou", item.DetailsAboutYou),
                });

                var response = httpClient.PostAsync(EndPoints.ChangeUserInfo, content).Result;
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}