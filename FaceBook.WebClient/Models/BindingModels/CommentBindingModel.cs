namespace FaceBook.WebClient.Models.BindingModels
{
    using System;

    public class CommentBindingModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public UserBindingModel Author { get; set; }

        public DateTime PostedOn { get; set; }

        public int LikesCount { get; set; }

        public bool IsLikedByCurrentUser { get; set; }
    }
}