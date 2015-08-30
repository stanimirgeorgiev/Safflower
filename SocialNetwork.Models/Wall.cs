using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public class Wall
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
