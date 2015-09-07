namespace FaceBook.WebClient.Models
{
    using System.Collections.Generic;

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
