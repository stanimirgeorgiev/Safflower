namespace FaceBook.Services.Controllers
{
    using System.Web.Http;
    using FaceBook.Services.Models.BindingModels;
    using System;
    using System.Linq;
    using FaceBook.Models;
    using FaceBook.Services.Models.DataModels;
    using Microsoft.AspNet.Identity;

    public class CommentsController : BaseApiController
    {
        [HttpPost]
        [Route("api/posts/{postId}/comments")]
        public IHttpActionResult AddCommentToPost(int postId, AddCommentBindingModel model)
        {
            var post = this.Data.Posts.Find(postId);
            if (post == null)
            {
                return this.NotFound();
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();

            var comment = new Comment()
            {
                Content = model.Content,
                PostId = post.Id,
                PostedOn = DateTime.Now,
                UserId = userId
            };

            this.Data.Comments.Add(comment);
            this.Data.SaveChanges();

            var data = this.Data.Comments
                .Where(c => c.Id == comment.Id)
                .Select(CommentDataModel.Create)
                .FirstOrDefault();

            return this.Ok(data);
        }

        [HttpPut]
        [Route("api/comments/{commentId}")]
        public IHttpActionResult EditComment(int commentId, AddCommentBindingModel model)
        {
            var comment = this.Data.Comments.Find(commentId);
            if (comment == null)
            {
                return this.NotFound();
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();
            if (userId != comment.UserId)
            {
                return this.Unauthorized();
            }

            comment.Content = model.Content;
            this.Data.SaveChanges();

            var data = this.Data.Comments
                .Where(c => c.Id == comment.Id)
                .Select(CommentDataModel.Create)
                .FirstOrDefault();

            return this.Ok(data);
        }

        [HttpDelete]
        [Route("api/comments/{commentId}")]
        public IHttpActionResult DeleteComment(int commentId)
        {
            var comment = this.Data.Comments.Find(commentId);
            if (comment == null)
            {
                return this.NotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();
            if (loggedUserId != comment.UserId)
            {
                return this.Unauthorized();
            }

            this.Data.Comments.Remove(comment);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}