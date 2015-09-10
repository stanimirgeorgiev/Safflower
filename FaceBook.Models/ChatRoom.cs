using System;
namespace FaceBook.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ChatRoom
    {
        private ICollection<Chat> chats;

        public ChatRoom()
        {
            this.chats = new HashSet<Chat>();
        }
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Chat> Chats
        {
            get { return this.chats; }
            set { this.chats = value; }
        }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public ChatViewPriviliges Priviliges { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public enum ChatViewPriviliges
    {
        PrivateChatRoom,
        FriendsChatRoom,
        PublicChatRoom
    }
}