using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceBook.Services.Models.BindingModels
{
    public class GroupAddUserBindingModels
    {
        public Guid IdGroup { get; set; }
        public string IdUser { get; set; }
    }
}