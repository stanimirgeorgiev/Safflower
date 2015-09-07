namespace FaceBook.Services.Models.DataModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using FaceBook.Models;
    using System.Collections.Generic;

    public class UserWallDataModel
    {
        public string Id { get; set; }

        public UserDataModel Owner { get; set; }

        public IEnumerable<PostDataModel> Posts { get; set; }

        public static Expression<Func<WallUser, UserWallDataModel>> Create
        {
            get
            {
                return uw => new UserWallDataModel()
                {
                    Id = uw.Id,
                    Owner = new UserDataModel()
                    {
                        Username = uw.User.UserName
                    },
                    Posts = uw.Posts
                        .OrderByDescending(p => p.PostedOn)
                        .Select(p => new PostDataModel()
                        {
                            Id = p.Id,
                            Content = p.Content,
                            Author = new UserDataModel()
                            {
                                Username = p.User.UserName
                            },
                            PostedOn = p.PostedOn,
                            WallOwner = new UserDataModel()
                            {
                                Username = p.WallUser.User.UserName
                            },
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
                        })
                };
            }
        }
    }
}