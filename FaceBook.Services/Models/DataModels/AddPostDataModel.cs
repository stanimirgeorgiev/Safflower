using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FaceBook.Models;
using Microsoft.Ajax.Utilities;

namespace FaceBook.Services.Models.DataModels
{
    public class AddPostDataModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public UserDataModel Author { get; set; }

        public UserDataModel WallOwner { get; set; }

        public DateTime PostedOn { get; set; }

        public int LikesCount { get; set; }

        public IEnumerable<CommentDataModel> Comments { get; set; }

        public static Expression<Func<Post, AddPostDataModel>> Create
        {
            get
            {
                return p => new AddPostDataModel()
                {
                    Id = p.Id,
                    Content = p.Content,
                    Author = new UserDataModel()
                    {
                        Username = p.User.UserName
                    },
                    WallOwner = new UserDataModel()
                    {
                      Username = p.User.UserName
                    },
                    PostedOn = p.PostedOn,
                    LikesCount = p.Likes.Count,
                    Comments = p.Comments
                        .OrderBy(c => c.PostedOn)
                        .Select(c => new CommentDataModel()
                        {
                            Id = c.Id,
                            Content = c.Content,
                            Author = new UserDataModel()
                            {
                                Username = c.User.UserName
                            }
                        })
                };
            }
        } 
    }
}