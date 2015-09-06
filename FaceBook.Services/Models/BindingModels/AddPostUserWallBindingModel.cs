namespace FaceBook.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddPostUserWallBindingModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Content { get; set; }
    }
}