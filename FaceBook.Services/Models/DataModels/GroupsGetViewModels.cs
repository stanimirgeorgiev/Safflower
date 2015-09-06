using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using FaceBook.Models;

namespace FaceBook.Services.Models.DataModels
{
    public class GroupsGetViewModels
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public GroupsGetViewModels(Group group)
        {
            this.Name = group.Name;
            this.Id = group.Id;
        }
    }
}