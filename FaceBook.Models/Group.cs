using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            this.Id = Guid.NewGuid();
        }
        //[Key]
        //[Required]
        //public string Id { get; set; }
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
        //public string  WallId { get; set; }
        //[ForeignKey("WallId")]
        public virtual WallGroup WallGroup { get; set; }

    }
}
