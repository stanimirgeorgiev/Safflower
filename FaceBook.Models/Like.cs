using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FaceBook.Models
{
    public class Like
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}
