using System.ComponentModel.DataAnnotations;

namespace FaceBook.Services.Models.BindingModels
{
    public class UserSearchBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}