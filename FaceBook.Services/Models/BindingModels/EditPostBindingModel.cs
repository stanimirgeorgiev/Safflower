namespace FaceBook.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditPostBindingModel
    {
        [Required]
        [MinLength(2)]
        public string Content { get; set; }
    }
}