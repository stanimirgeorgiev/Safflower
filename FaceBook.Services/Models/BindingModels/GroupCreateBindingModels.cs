namespace FaceBook.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class GroupCreateBindingModels
    {
        [Required]
        public string Name { get; set; }
    }
}