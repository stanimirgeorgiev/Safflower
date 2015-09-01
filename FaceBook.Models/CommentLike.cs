using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FaceBook.Models
{
    public class CommentLike:Like
    {
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
