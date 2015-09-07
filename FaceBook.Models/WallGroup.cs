namespace FaceBook.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WallGroup:Wall
    {
        public WallGroup()
        {
            this.Id = Guid.NewGuid();
        }

        [Key, ForeignKey("Group")]
        public Guid Id { get; set; }

        public virtual Group Group { get; set; }
    }
}
