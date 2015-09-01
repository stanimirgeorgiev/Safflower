using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FaceBook.Models
{
    public class Group
    {
        private ICollection<User> users;

        public Group()
        {
            this.users = new HashSet<User>();
        }
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
        [Required]
        public int  WallId { get; set; }
        public virtual Wall Wall { get; set; }

    }
}
