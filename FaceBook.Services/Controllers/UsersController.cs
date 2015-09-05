using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FaceBook.Services.Models;
using FaceBook.Services.Models.BindingModels;

namespace FaceBook.Services.Controllers
{
    public class UsersController : BaseApiController
    {
       //TODO
        [ActionName("search")]
        [HttpGet]
        public IHttpActionResult SearchUser(
            [FromUri]UserSearchBindingModel model)
        {
            //missing valid model
            var usersSearchResult = this.Data.Users
                    .Where(u => u.UserName.Contains(model.Name))
                    .Select(u=>new {u.UserName});


            return this.Ok(usersSearchResult);
        }
    }
}
