namespace FaceBook.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User: IdentityUser
    {
        private ICollection<Chat> chats;
        private ICollection<ChatRoom> chatRooms;
        private ICollection<Comment> comments;
        private ICollection<CommentLike> commentLikes;
        private ICollection<User> friends;
        private ICollection<Group> groups;
        private ICollection<PostLike> postLikes;
        private ICollection<Post> posts;

        public User()
        {
            this.chatRooms = new HashSet<ChatRoom>();
            this.chats= new HashSet<Chat>();
            this.commentLikes = new HashSet<CommentLike>();
            this.comments = new HashSet<Comment>();
            this.friends = new HashSet<User>();
            this.groups = new HashSet<Group>();
            this.postLikes = new List<PostLike>();
            this.posts = new HashSet<Post>();
        }

        public virtual WallUser WallUser { get; set; }

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

        public virtual ICollection<ChatRoom> ChatRooms
        {
            get { return this.chatRooms; }
            set { this.chatRooms = value; }
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
