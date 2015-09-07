namespace FaceBook.WebClient.Models
{
    public class WallUser : Wall
    {
        public string Id { get; set; }

        public virtual User User { get; set; }
    }
}
