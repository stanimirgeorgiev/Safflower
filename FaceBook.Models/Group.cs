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
            this.Wall = new Wall("Problemniq" + DateTime.Now.ToString());
        }
        //[Key]
        //[Required]
        //public string Id { get; set; }
        [Key]
        public string IdString { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
        //public string  WallId { get; set; }
        //[ForeignKey("WallId")]
        public virtual Wall Wall { get; set; }

    }
}
