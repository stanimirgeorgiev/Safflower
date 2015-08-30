using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Post
    {


        private IEnumerable<Comment> comments;


        public Post()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int CommentId { get; set; }

        public virtual IEnumerable<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public int WallId { get; set; }
        public virtual IEnumerable<Wall> Walls { get; set; }

       
    }
}
