namespace FaceBook.Services.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddPostGroupWallBindingModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Content { get; set; }
    }
}