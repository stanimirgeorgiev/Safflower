namespace FaceBook.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddPostBindingModel
    {
        [Required]
        [MinLength(2)]
        public string Content { get; set; }

        [Required]
        public string WallId { get; set; }
    }
}