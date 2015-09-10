using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FaceBook.Models
{
    public class ChatRoom
    {
        private ICollection<Chat> chats;
        public ChatRoom()
        {
            chats = new HashSet<Chat>();
        }
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Chat> Chats
        {
            get { return chats; }
            set { chats = value; }
        }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public ChatViewPrivileges Privileges { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public enum ChatViewPrivileges
    {
        PrivateChatRoom,
        FriendsChatRoom,
        PublicChatRoom
    }
}