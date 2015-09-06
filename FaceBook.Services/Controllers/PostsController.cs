namespace FaceBook.Services.Controllers
{
    using System.Web.Http;
    using FaceBook.Services.Models.BindingModels;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Linq;
    using FaceBook.Services.Models.DataModels;
    using FaceBook.Models;

    public class PostsController : BaseApiController
    {
        [HttpPost]
        [Route("api/posts")]
        public IHttpActionResult AddPostToUserWall(AddPostBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var loggedUserId = this.User.Identity.GetUserId();

            var post = new Post()
            {
                UserId = loggedUserId,
                WallUserId = model.WallId,
                Content = model.Content,
                PostedOn = DateTime.Now
            };

            this.Data.Posts.Add(post);
            this.Data.SaveChanges();

            var data = this.Data.Posts
                .Where(p => p.Id == post.Id)
                .Select(AddPostDataModel.Create)
                .FirstOrDefault();

            return this.Ok(data);
        }
    }
}