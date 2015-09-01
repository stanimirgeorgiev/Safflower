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
        //Int is required, because is not nullable type
        public virtual int UserId { get; set; }
        public User User { get; set; }

        [DefaultValue(1)]
        public byte FriendsView
        {
            get;
            set;
        }

        [DefaultValue(0)]
        public byte LoggedUsersView
        {
            get;
            set;
        }

        [DefaultValue(0)]
        public byte GuestView
        {
            get;
            set;
        }
    }
}