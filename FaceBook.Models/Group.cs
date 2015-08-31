using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceBook.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }
        public virtual IEnumerable<User> Users { get; set; }

        public virtual int  WallId { get; set; }

    }
}
