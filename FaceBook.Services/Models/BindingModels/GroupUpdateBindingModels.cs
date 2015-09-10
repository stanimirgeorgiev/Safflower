namespace FaceBook.Services.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GroupUpdateBindingModels
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string NewName { get; set; }
    }
}