namespace FaceBook.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Comment
    {
        private ICollection<CommentLike> likes;

        public Comment()
        {
            this.likes = new HashSet<CommentLike>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsLikedByCurrentUser { get; set; }

        public DateTime PostedOn { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual ICollection<CommentLike> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        } 
    }
}
