using System.Collections.Generic;

namespace FaceBook.WebClient.Models.BindingModels
{
    public class GroupWallBindingModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Creator { get; set; }

        public UserBindingModel Owner { get; set; }

        public IEnumerable<PostBindingModel> Posts { get; set; }
    }
}