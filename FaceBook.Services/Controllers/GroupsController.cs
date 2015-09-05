using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FaceBook.Models;
using FaceBook.Services.Models.BindingModels;
using FaceBook.Services.Models.DataModels;
using Microsoft.Ajax.Utilities;

namespace FaceBook.Services.Controllers
{
    [Authorize]
    public class GroupsController : BaseApiController
    {
        //GET api/groups
        [HttpGet]
        public IHttpActionResult Get()
        {
            var groups = this.Data.Groups.Select(GroupsGetViewModels.Create);
            return Ok(groups);
        }

        //POST api/groups/create
        [HttpPost]
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
                Group group = new Group();
                group.Name = model.Name;
                this.Data.Groups.Add(group);
                this.Data.SaveChanges();
                return Ok(new
                {
                    group.Name, 
                    group.Id
                });
            }
            
        }

        //POST api/groups/adduser
        [HttpPost]
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
                Group group = this.Data.Groups.Find(model.IdGroup);
                User user = this.Data.Users.Find(model.IdUser);
                group.Users.Add(user);
                this.Data.SaveChanges();
                string result = string.Format("User {0} successfully join group {1}!", user.UserName, group.Name);
                return Ok(result);
            }
        }
    }

}
