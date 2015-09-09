namespace FaceBook.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using FaceBook.Models;
    using FaceBook.Services.Models.BindingModels;
    using FaceBook.Services.Models.DataModels;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class GroupsController : BaseApiController
    {
        //GET api/groups
        [HttpGet]
        [Route("api/groups")]
        public IHttpActionResult Get()
        {
            var groups = this.Data.Groups.ToList();
            List<GroupsGetViewModels> result = new List<GroupsGetViewModels>();
            foreach (var group in groups)
            {
                result.Add(new GroupsGetViewModels(group));
            }
            return Ok(result);
        }

        //POST api/groups/create
        [HttpPost]
        [Route("api/groups/create")]
        public IHttpActionResult CreateGroup([FromBody] GroupCreateBindingModels model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null (no data in request)");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var currentUserId = this.User.Identity.GetUserId();
                var currentUser = this.Data.Users.Find(currentUserId);

                Group group = new Group();
                group.Name = model.Name;

                //this.Data.Groups.Add(group);
                currentUser.Groups.Add(group);
                this.Data.SaveChanges();

                return Ok(new GroupsGetViewModels(group));
            }
        }

        //POST api/groups/adduser
        [HttpPost]
        [Route("api/groups/adduser")]
        public IHttpActionResult AddUser([FromBody] GroupAddUserBindingModels model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null (no data in request)");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                Group group = this.Data.Groups.Find(model.GroupId);
                User user = this.Data.Users.Find(model.UserId);
                group.Users.Add(user);
                this.Data.SaveChanges();
                string result = string.Format("User {0} successfully join group {1}!", user.UserName, group.Name);
                return Ok(result);
            }
        }

        //PATCH api/groups/update
        [HttpPatch]
        [Route("api/groups/update")]
        public IHttpActionResult UpdateGroup([FromBody] GroupUpdateBindingModels model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null (no data in request)");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                Group group = this.Data.Groups.Find(model.Id);
                group.Name = model.NewName;
                this.Data.SaveChanges();
                return Ok(new GroupsGetViewModels(group));
            }
        }

        [HttpPost]
        [Route("api/groups/remove")]
        public IHttpActionResult Remove([FromBody] GroupRemoveBindingModels model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null (no data in request)");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                Group group = this.Data.Groups.Find(model.Id);
                this.Data.Groups.Remove(group);
                this.Data.SaveChanges();
                return Ok(new GroupsGetViewModels(group));
            }
        }

        //GET api/groups/search/{i}
        [HttpGet]
        [Route("api/groups/search")]
        public IHttpActionResult SearchGroupById(Guid id)
        {
            Group group = this.Data.Groups.Find(id);

            return Ok(new GroupsGetViewModels(group));
        }
    }

}
