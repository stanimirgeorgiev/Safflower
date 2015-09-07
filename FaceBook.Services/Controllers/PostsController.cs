namespace FaceBook.Services.Controllers
{
    using System.Web.Http;
    using FaceBook.Services.Models.BindingModels;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Linq;
    using FaceBook.Services.Models.DataModels;
    using FaceBook.Models;

    [Authorize]
    public class PostsController : BaseApiController
    {
        [HttpGet]
        [Route("api/posts/{postId}")]
        public IHttpActionResult GetPostById(int postId)
        {
            var post = this.Data.Posts
                .Where(p => p.Id == postId)
                .Select(PostDataModel.Create)
                .FirstOrDefault();

            if (post == null)
            {
                return this.NotFound();
            }

            return this.Ok(post);
        }

        [HttpPost]
        [Route("api/user/posts")]
        public IHttpActionResult AddPostToUserWall(AddPostUserWallBindingModel model)
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
                WallUserId = model.Id,
                Content = model.Content,
                PostedOn = DateTime.Now
            };

            this.Data.Posts.Add(post);
            this.Data.SaveChanges();

            var data = this.Data.Posts
                .Where(p => p.Id == post.Id)
                .Select(PostDataModel.Create)
                .FirstOrDefault();

            return this.Ok(data);
        }

        [HttpPost]
        [Route("api/group/posts")]
        public IHttpActionResult AddPostToGroupWall(AddPostGroupWallBindingModel model)
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
                WallGroupId = model.Id,
                Content = model.Content,
                PostedOn = DateTime.Now
            };

            this.Data.Posts.Add(post);
            this.Data.SaveChanges();

            var data = this.Data.Posts
                .Where(p => p.Id == post.Id)
                .Select(PostDataModel.Create)
                .FirstOrDefault();

            return this.Ok(data);
        }

        [HttpPut]
        [Route("api/posts/{postId}")]
        public IHttpActionResult EditPost(int postId, EditPostBindingModel model)
        {
            var post = this.Data.Posts.Find(postId);
            if (post == null)
            {
                return this.NotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();
            if (loggedUserId != post.UserId)
            {
                return this.Unauthorized();
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be empty!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            post.Content = model.Content;
            this.Data.SaveChanges();

            var data = this.Data.Posts
                .Where(p => p.Id == post.Id)
                .Select(PostDataModel.Create)
                .FirstOrDefault();

            return this.Ok(data);
        }

        [HttpDelete]
        [Route("api/posts/{postId}")]
        public IHttpActionResult DeletePostById(int postId)
        {
            var post = this.Data.Posts.Find(postId);
            if (post == null)
            {
                return this.NotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();
            if (loggedUserId != post.UserId)
            {
                return this.Unauthorized();
            }

            this.Data.Posts.Remove(post);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}