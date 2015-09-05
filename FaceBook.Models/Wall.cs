using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FaceBook.Models
{
    public abstract class Wall
    {
        private ICollection<Post> posts;

        protected Wall()
        {
            this.posts = new HashSet<Post>();
        }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
