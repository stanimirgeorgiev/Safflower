using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FaceBook.Models
{
    public class Wall
    {
        private ICollection<Post> posts;

        public Wall()
        {
            this.posts = new HashSet<Post>();
        }

        public Wall(string problem)
        {
            this.Id = problem;
        }
        [Key]
       // [Required]
        public string Id { get; set; }

        //public string AspNetUserId { get; set; }
        //[ForeignKey("Id")]
        public virtual User User { get; set; }

        //[ForeignKey("IdString")]
        public virtual Group Group { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
