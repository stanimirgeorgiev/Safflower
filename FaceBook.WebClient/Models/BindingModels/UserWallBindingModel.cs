namespace FaceBook.WebClient.Models.BindingModels
{
    using System.Collections.Generic;

    public class UserWallBindingModel
    {
        public string Id { get; set; }

        public UserBindingModel Owner { get; set; }

        public IEnumerable<PostBindingModel> Posts { get; set; }
    }
}