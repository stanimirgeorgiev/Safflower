using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public  class User: IdentityUser
    {


        public int WallId { get; set; }
        public virtual Wall Wall { get; set; }

        public int PostId { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public int CommentId { get; set; }
        public virtual ICollection<Comment> Coments { get; set; }

        public int PostLikeId { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }

        public int CommentLikeId { get; set; }
        public virtual ICollection<CommentLike> CommentLikes { get; set; }

        public int GroupId { get; set; }
        public virtual ICollection<Group> Groups { get; set; }

        public int FriendId { get; set; }
        public virtual ICollection<User> Friends { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<User> manager,
            string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(
                this,
                authenticationType);

            return userIdentity;
        }
    }
}
