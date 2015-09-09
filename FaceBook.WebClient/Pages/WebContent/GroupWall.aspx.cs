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
    public partial class GroupWall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var userWallId = Request.QueryString["uid"];
            var userAccessToken = Session["AccessToken"];
            var bearer = "Bearer " + userAccessToken;
            httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

            var response = httpClient.GetAsync(String.Format(EndPoints.AreFriends, userWallId)).Result;

            if (response.IsSuccessStatusCode)
            {
                this.JoinGroupButton.Text = "Leave group";
            }
            else
            {
                this.JoinGroupButton.Text = "Join group";
            }
        }

        public IEnumerable<PostBindingModel> Select()
        {
            var httpClient = new HttpClient();
            var groupWallId = Request.QueryString["uid"];
            var userAccessToken = Session["AccessToken"];
            var bearer = "Bearer " + userAccessToken;
            httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

            var response = httpClient.GetAsync(String.Format(EndPoints.GetGroupWall, groupWallId)).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsAsync<GroupWallBindingModel>().Result;

                if (responseContent.Posts == null)
                {
                    return new List<PostBindingModel>();
                }

                return responseContent.Posts;
            }

            return new List<PostBindingModel>();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        protected void PostButton_Click(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var userAccessToken = Session["AccessToken"];
            var userWallId = Request.QueryString["uid"];
            var bearer = "Bearer " + userAccessToken;
            var postContent = this.TextBoxPostContent.Text;
            httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("content", postContent),
                new KeyValuePair<string, string>("id", userWallId)
            });

            var response = httpClient.PostAsync(EndPoints.PostToUserWall, content).Result;

            Response.Redirect(Request.RawUrl);
        }

        protected void CommandLikeComment(object sender, CommandEventArgs e)
        {
            var httpClient = new HttpClient();
            var userAccessToken = Session["AccessToken"];
            var userWallId = Request.QueryString["uid"];
            var commentId = e.CommandName;
            var bearer = "Bearer " + userAccessToken;
            httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

            var postQuery = String.Format(EndPoints.LikeComment, commentId);
            var response = httpClient.PostAsync(postQuery, null).Result;

            Response.Redirect(Request.RawUrl);
        }

        protected void CommandPostComment(object sender, CommandEventArgs e)
        {
            var httpClient = new HttpClient();
            var userAccessToken = Session["AccessToken"];
            var userWallId = Request.QueryString["uid"];
            var postId = e.CommandName;
            var bearer = "Bearer " + userAccessToken;

            var buttonComment = sender as Button;
            var postContent = (TextBox)buttonComment.NextControl();

            httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("content", postContent.Text)
            });

            var postQuery = String.Format(EndPoints.PostComment, postId);
            var response = httpClient.PostAsync(postQuery, content).Result;

            Response.Redirect(Request.RawUrl);
        }

        protected void CommandLikePost(object sender, CommandEventArgs e)
        {
            var httpClient = new HttpClient();
            var userAccessToken = Session["AccessToken"];
            var userWallId = Request.QueryString["uid"];
            var postId = e.CommandName;
            var bearer = "Bearer " + userAccessToken;
            httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

            var postQuery = String.Format(EndPoints.LikePost, postId);
            var response = httpClient.PostAsync(postQuery, null).Result;

            Response.Redirect(Request.RawUrl);
        }

        protected void ButtonJoinGroup_Click(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;

            if (button.Text == "Add frined")
            {
                var httpClient = new HttpClient();
                var userAccessToken = Session["AccessToken"];
                var userWallId = Request.QueryString["uid"];
                var bearer = "Bearer " + userAccessToken;
                httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

                var postQuery = String.Format(EndPoints.AddFriend, userWallId);
                var response = httpClient.PutAsync(postQuery, null).Result;
            }
            else
            {
                var httpClient = new HttpClient();
                var userAccessToken = Session["AccessToken"];
                var userWallId = Request.QueryString["uid"];
                var bearer = "Bearer " + userAccessToken;
                httpClient.DefaultRequestHeaders.Add("Authorization", bearer);

                var postQuery = String.Format(EndPoints.RemoveFriend, userWallId);
                var response = httpClient.PutAsync(postQuery, null).Result;
            }

            Response.Redirect(Request.RawUrl);
        }
    }
}