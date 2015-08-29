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
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
