namespace FaceBook.WebClient.Models
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class User
    {
        private ICollection<Comment> comments;
        private ICollection<CommentLike> commentLikes;
        private ICollection<User> friends;
        private ICollection<Group> groups;
        private ICollection<PostLike> postLikes;
        private ICollection<Post> posts;

        public User()
        {
            this.commentLikes = new HashSet<CommentLike>();
            this.comments = new HashSet<Comment>();
            this.friends = new HashSet<User>();
            this.groups = new HashSet<Group>();
            this.postLikes = new List<PostLike>();
            this.posts = new HashSet<Post>();
        }

        public string Username { get; set; }

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
    }
}
