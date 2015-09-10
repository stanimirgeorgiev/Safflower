namespace FaceBook.WebClient.Models
{
    public class PostLike : Like
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
