
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;



namespace FaceBook.Models
{
    public  class User: IdentityUser
    {
        private ICollection<Chat> chats;
        private ICollection<Post> posts;
        private ICollection<Comment> comments;
        private ICollection<PostLike> postLikes;
        private ICollection<CommentLike> commentLikes;
        private ICollection<Group> groups;
        private ICollection<User> friends;

        public User()
        {
            this.chats= new HashSet<Chat>();
            this.posts = new HashSet<Post>();
            this.comments = new HashSet<Comment>();
            this.postLikes = new List<PostLike>();
            this.commentLikes = new HashSet<CommentLike>();
            this.groups = new HashSet<Group>();
            this.friends = new HashSet<User>();
        }


        public int WallId { get; set; }
        public virtual Wall Wall { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<PostLike> PostLikes
        {
            get { return this.postLikes; }
            set { this.postLikes = value; }
        }

        public virtual ICollection<CommentLike> CommentLikes
        {
            get { return this.commentLikes; }
            set { this.commentLikes = value; }
        }

        public virtual ICollection<Group> Groups
        {
            get { return this.groups; }
            set { this.groups = value; }
        }

        public virtual ICollection<User> Friends
        {
            get { return this.friends; }
            set { this.friends = value; }
        }

        public virtual ICollection<Chat> Chats
        {
            get { return this.chats; }
            set { this.chats = value; }
        }


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
