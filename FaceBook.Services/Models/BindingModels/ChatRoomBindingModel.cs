using System.ComponentModel.DataAnnotations;
using FaceBook.Models;
namespace FaceBook.Services.Models.BindingModels
{
    public class ChatRoomBindingModel
    {
        [Required]
        [MinLength(1)]
        public string ChatRoomName { get; set; }
        [Required]
        public ChatViewPrivileges Privileges { get; set; }
    }
}