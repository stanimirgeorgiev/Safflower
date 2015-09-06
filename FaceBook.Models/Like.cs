﻿namespace FaceBook.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Like
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
