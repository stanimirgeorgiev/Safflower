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
    }

}
