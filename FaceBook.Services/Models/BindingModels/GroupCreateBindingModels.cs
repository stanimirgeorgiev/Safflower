﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaceBook.Services.Models.BindingModels
{
    public class GroupCreateBindingModels
    {
        [Required]
        public string Name { get; set; }
    }
}