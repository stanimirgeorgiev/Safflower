using System;
using System.Linq.Expressions;
using FaceBook.Models;

namespace FaceBook.Services.Models.DataModels
{
    public class CommentDataModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public UserDataModel Author { get; set; }

        public DateTime PostedOn { get; set; }

        public int LikesCount { get; set; }

        public static Expression<Func<Comment, CommentDataModel>> Create
        {
            get
            {
                return c => new CommentDataModel()
                {
                    Id = c.Id,
                    Content = c.Content,
                    Author = new UserDataModel()
                    {
                        Username = c.User.UserName
                    },
                    PostedOn = DateTime.Now,
                    LikesCount = c.Likes.Count
                };
            }
        } 
    }
}