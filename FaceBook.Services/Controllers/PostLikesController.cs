namespace FaceBook.Services.Controllers
{
    using System.Linq;
    using FaceBook.Models;
    using Microsoft.AspNet.Identity;
    using System.Web.Http;

    [Authorize]
    public class PostLikesController : BaseApiController
    {
        [HttpPost]
        [Route("api/posts/{postId}/likes")]
        public IHttpActionResult LikeOrUnlikePost(int postId)
        {
            var post = this.Data.Posts.Find(postId);
            if (post == null)
            {
                return this.NotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();

            var isAlreadyLiked = post.Likes
                .Any(pl => pl.UserId == loggedUserId);
            if (isAlreadyLiked)
            {
                var like = post.Likes
                    .FirstOrDefault(pl => pl.UserId == loggedUserId);

                post.Likes.Remove(like);
                this.Data.SaveChanges();

                return this.Ok();
            }

            post.Likes.Add(new PostLike()
            {
                UserId = loggedUserId
            });
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}