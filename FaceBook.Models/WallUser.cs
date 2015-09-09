namespace FaceBook.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WallUser : Wall
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }
    }
}
