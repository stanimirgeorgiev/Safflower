namespace FaceBook.WebClient.Pages.Account
{
    using Common;
    using FaceBook.WebClient.Models.BindingModels;
    using System;
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
            FaceBook.WebClient.Models.BindingModels.UserBindingModel item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
            }
        }
    }
}