using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FaceBook.Models
{
    public class Post
    {


        private ICollection<Comment> comments;
        
        
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string WallUserId { get; set; }
        public virtual WallUser WallUser { get; set; }
        public Guid WallGroupId { get; set; }
        public virtual WallGroup WallGroup { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public Post()
        {
            this.comments = new HashSet<Comment>();
        }
    }
}
