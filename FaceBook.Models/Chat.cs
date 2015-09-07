namespace FaceBook.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Chat
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ChatRoomId  { get; set; }
        public virtual ChatRoom ChatRoom { get; set; }

        public string ChatPost { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public byte IsGuest { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}