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
        private ICollection<Wall> walls;
        
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Wall> Walls
        {
            get { return this.walls; }
            set { this.walls = value; }
        }

        public Post()
        {
            this.comments = new HashSet<Comment>();
            this.walls = new HashSet<Wall>();
        }
    }
}
