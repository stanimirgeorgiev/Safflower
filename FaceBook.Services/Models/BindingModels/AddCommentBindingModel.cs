namespace FaceBook.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddCommentBindingModel
    {
        [Required]
        [MinLength(2)]
        public string Content { get; set; }
    }
}