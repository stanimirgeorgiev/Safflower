namespace FaceBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Group
    {
        private ICollection<User> users;

        public Group()
        {
            this.users = new HashSet<User>();
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual WallGroup WallGroup { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

    }
}
