namespace SocialNetwork.Models
{
    public class CommentLike:Like
    {
        public virtual int CommentId { get; set; }
    }
}
