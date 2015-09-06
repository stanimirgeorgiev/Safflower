namespace FaceBook.Services.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using FaceBook.Models;

    public class PostDataModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public UserDataModel Author { get; set; }

        public UserDataModel WallOwner { get; set; }

        public DateTime PostedOn { get; set; }

        public int LikesCount { get; set; }

        public bool IsLikedByCurrentUser { get; set; }

        public IEnumerable<CommentDataModel> Comments { get; set; }

        public static Expression<Func<Post, PostDataModel>> Create
        {
            get
            {
                return p => new PostDataModel()
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
                    IsLikedByCurrentUser = p.IsLikedByCurrentUser,
                    Comments = p.Comments
                        .OrderBy(c => c.PostedOn)
                        .Select(c => new CommentDataModel()
                        {
                            Id = c.Id,
                            Content = c.Content,
                            Author = new UserDataModel()
                            {
                                Username = c.User.UserName
                            },
                            IsLikedByCurrentUser = c.IsLikedByCurrentUser,
                            PostedOn = c.PostedOn,
                            LikesCount = c.Likes.Count
                        })
                };
            }
        } 
    }
}