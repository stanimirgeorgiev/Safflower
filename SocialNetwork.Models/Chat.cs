using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Cache;
using System.Security.Claims;
using System.Threading.Tasks;


namespace SocialNetwork.Models
{
    public class Chat
    {
        [Key]
        [Required]
        public int Id
        {
            get;
            set;
        }

        public string ChatPost
        {
            get;
            set;
        }
        public DateTime CreatedOn
        {
            get;
            set;
        }
        public User User
        {
            get;
            set;
        }
    }
}
