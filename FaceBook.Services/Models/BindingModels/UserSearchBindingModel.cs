namespace FaceBook.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserSearchBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}