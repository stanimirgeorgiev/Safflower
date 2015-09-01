using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace FaceBook.Models
{
    public class Chat
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int ChatRoomId  { get; set; }
        public virtual ChatRoom ChatRoom { get; set; }

        public string ChatPost { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public byte IsGuest { get; set; }
//<<<<<<< HEAD
//=======
//        //?? Byte 
//>>>>>>> f383d719fc7197e666853612656f8a5154ee1bde

        public DateTime CreatedOn { get; set; }

    }
}