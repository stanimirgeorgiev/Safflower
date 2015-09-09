namespace FaceBook.WebClient.Models.BindingModels
{
    using System;
    using System.Collections.Generic;

    public class PostBindingModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public UserBindingModel Author { get; set; }

        public UserBindingModel WallOwner { get; set; }

        public DateTime PostedOn { get; set; }

        public int LikesCount { get; set; }

        public bool IsLikedByCurrentUser { get; set; }

        public IEnumerable<CommentBindingModel> Comments { get; set; }
    }
}