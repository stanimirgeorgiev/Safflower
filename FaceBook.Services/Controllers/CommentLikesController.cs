namespace FaceBook.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using FaceBook.Models;
    using Microsoft.AspNet.Identity;

    public class CommentLikesController : BaseApiController
    {
        [HttpPost]
        [Route("api/comments/{commentId}/likes")]
        public IHttpActionResult LikeOrUnlikeComment(int commentId)
        {
            var comment = this.Data.Comments.Find(commentId);
            if (comment == null)
            {
                return this.NotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();

            var isAlreadyLikes = comment.Likes
                .Any(cl => cl.UserId == loggedUserId);
            if (isAlreadyLikes)
            {
                var commentLike = comment
                    .Likes
                    .FirstOrDefault(cl => cl.UserId == loggedUserId);

                this.Data.CommentLikes.Remove(commentLike);
                this.Data.SaveChanges();

                return this.Ok();
            }

            comment.Likes.Add(new CommentLike()
            {
                UserId = loggedUserId
            });
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}