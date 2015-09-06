using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaceBook.Models
{
    public class WallUser:Wall
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }
    }
}
