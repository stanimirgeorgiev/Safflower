namespace FaceBook.WebClient.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        private ICollection<Comment> comments;
        private ICollection<PostLike> likes;

        public Post()
        {
            this.comments = new HashSet<Comment>();
            this.likes = new HashSet<PostLike>();
        }
        
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsLikedByCurrentUser { get; set; }

        public DateTime PostedOn { get; set; }
        
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string WallUserId { get; set; }

        public virtual WallUser WallUser { get; set; }

        public Guid? WallGroupId { get; set; }

        public virtual WallGroup WallGroup { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<PostLike> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }
    }
}
