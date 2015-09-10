namespace FaceBook.Services.Models.DataModels
{
    using System;
    using FaceBook.Models;

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