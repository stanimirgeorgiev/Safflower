using System;
using System.Linq.Expressions;
using FaceBook.Models;
namespace FaceBook.Services.Models.DataModels
{
    public class ChatDataModel
    {
        public int Id { get; set; }
        public string ChatPost { get; set; }
        public UserDataModel Author { get; set; }
        public static Expression<Func<Chat, ChatDataModel>> ChatList
        {
            get
            {
                return c => new ChatDataModel
                {
                    Id = c.Id,
                    ChatPost = c.ChatPost,
                    Author = new UserDataModel
                    {
                        Username = c.User.UserName
                    }
                };
            }
        }
    }
}