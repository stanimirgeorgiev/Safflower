﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceBook.Services.Models.BindingModels
{
    public class GroupAddUserBindingModels
    {
        public Guid GroupId { get; set; }
        public string UserId { get; set; }
    }
}