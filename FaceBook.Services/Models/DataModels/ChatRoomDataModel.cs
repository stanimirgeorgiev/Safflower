using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FaceBook.Models;
namespace FaceBook.Services.Models.DataModels
{
    public class ChatRoomDataModel
    {
        public int Id { get; set; }
        public string ChatRoomName { get; set; }
        public DateTime CreatedOn { get; set; }
        public IEnumerable<ChatDataModel> Chats { get; set; }
        public UserDataModel Owner { get; set; }
        public static Expression<Func<ChatRoom, ChatRoomDataModel>> ListOfChatsInRoom
        {
            get
            {
                return c => new ChatRoomDataModel
                {
                    Id = c.Id,
                    ChatRoomName = c.Name,
                    CreatedOn = c.CreatedOn,
                    Chats = c.Chats
                        .Where(ci => ci.ChatRoomId == c.Id)
                        .Select(
                            cn => new ChatDataModel
                            {
                                Id = cn.Id,
                                ChatPost = cn.ChatPost,
                                Author = new UserDataModel
                                {
                                    Username = cn.User.UserName
                                }
                            }),
                    Owner = new UserDataModel
                    {
                        Username = c.User.UserName
                    }
                };
            }
        }
        public static Expression<Func<ChatRoom, ChatRoomDataModel>> ListOfChatRooms
        {
            get
            {
                return c => new ChatRoomDataModel
                {
                    Id = c.Id,
                    ChatRoomName = c.Name,
                    CreatedOn = c.CreatedOn,
                    Owner = new UserDataModel
                    {
                        Username = c.User.UserName
                    }
                };
            }
        }
    }
}