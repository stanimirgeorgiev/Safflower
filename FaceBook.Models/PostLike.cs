using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceBook.Models
{
    public class PostLike:Like
    {
        public virtual int PostId { get; set; }
    }
}
