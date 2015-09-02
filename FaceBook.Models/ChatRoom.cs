using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FaceBook.Models
{
    public class ChatRoom
    {
        private ICollection<Chat> chats;

        public ChatRoom()
        {
            this.chats = new HashSet<Chat>();
        }
        [Key]
        [Required]
        public int Id { get; set;}

        [Required]
        public string Name { get; set;}

        public virtual ICollection<Chat> Chats
        {
            get { return this.chats; }
            set { this.chats = value; }
        }
        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public byte FriendsView
        {
            get;
            set;
        }

        public byte LoggedUsersView
        {
            get;
            set;
        }

        public byte GuestView
        {
            get;
            set;
        }
    }
}