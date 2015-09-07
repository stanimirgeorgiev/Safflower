namespace FaceBook.WebClient.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Like
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
