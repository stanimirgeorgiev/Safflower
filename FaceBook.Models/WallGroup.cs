using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaceBook.Models
{
    public class WallGroup:Wall
    {
        public WallGroup():base()
        {
            this.Id = Guid.NewGuid();
        }
        [Key, ForeignKey("Group")]
        public Guid Id { get; set; }

        public virtual Group Group { get; set; }


        

    }
}
