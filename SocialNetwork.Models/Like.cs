using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FaceBook.Models
{
    public class Like
    {
        public int Id { get; set; }

        public virtual int UserId { get; set; }


    }
}
