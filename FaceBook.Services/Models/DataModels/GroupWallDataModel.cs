namespace FaceBook.Services.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using FaceBook.Models;
    using FaceBook.Services.Controllers;

    public class GroupWallDataModel : BaseApiController
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public UserDataModel Owner { get; set; }

        public IEnumerable<PostDataModel> Posts { get; set; }

        public static Expression<Func<WallGroup, GroupWallDataModel>> Create
        {
            get
            {
                return uw => new GroupWallDataModel()
                {
                    Id = uw.Id,
                    Name = uw.Group.Name,
                    Posts = uw.Posts
                        .OrderBy(p => p.PostedOn)
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
                                Username = p.User.UserName
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