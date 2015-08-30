namespace SocialNetwork.Models
{
    public class PostLike:Like
    {
        public virtual int PostId { get; set; }
    }
}
