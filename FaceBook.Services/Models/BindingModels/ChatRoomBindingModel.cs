using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FaceBook.Models;
namespace FaceBook.Services.Models.BindingModels
{
    public class ChatRoomBindingModel
    {
        [Required]
        [MinLength(1)]
        public string ChatRoomName { get; set; }
        [Required]
        public ChatViewPriviliges Privileges { get; set; }
    }
}