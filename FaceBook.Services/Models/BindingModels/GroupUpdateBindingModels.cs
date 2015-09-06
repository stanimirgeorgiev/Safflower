using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaceBook.Services.Models.BindingModels
{
    public class GroupUpdateBindingModels
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string NewName { get; set; }
    }
}