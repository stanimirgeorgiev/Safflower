using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FaceBook.Services.Models;
using FaceBook.Services.Models.BindingModels;
using FaceBook.Services.Models.DataModels;
using Microsoft.AspNet.Identity;

namespace FaceBook.Services.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        // api/


        [HttpGet]
        [Route("api/users/search")]
        public IHttpActionResult SearchUser(
            [FromUri]UserSearchBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var loggedUserName = this.User.Identity.GetUserName();
            var usersSearchResult = this.Data.Users.AsQueryable();
            usersSearchResult = usersSearchResult
                    .Where(u => (u.UserName.Contains(model.Name) &&
                        !u.UserName.Contains(loggedUserName)));

            var result = usersSearchResult
                .OrderBy(r => r.UserName)
                .Select(u => new UserDataModel
                {
                    Username = u.UserName

                });

            return this.Ok(result);
        }

        [HttpPut]
        [Route("api/users/addfriend/{userId}")]
        public IHttpActionResult AddFriend(string userId)
        {

            var friendToBeAdded = this.Data.Users
                .FirstOrDefault(u => u.Id == userId);

            if (friendToBeAdded == null)
            {
                return BadRequest("User is not found in the system");
            }

            var loggedUserId = this.User.Identity.GetUserId();
            var loggedUser = this.Data.Users.Find(loggedUserId);

            if (friendToBeAdded == loggedUser)
            {
                return BadRequest("You cannot add yourself as friend");
            }

            if (loggedUser.Friends.Contains(friendToBeAdded))
            {
                return BadRequest("You are already friends");
            }

            friendToBeAdded.Friends.Add(loggedUser);
            loggedUser.Friends.Add(friendToBeAdded);

            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        [Route("api/users/removefriend/{userId}")]
        public IHttpActionResult RemoveFriend(string userId)
        {

            var friendToBeRemoved = this.Data.Users
                .FirstOrDefault(u => u.Id == userId);

            if (friendToBeRemoved == null)
            {
                return BadRequest("User is not found in the system");
            }

            var loggedUserId = this.User.Identity.GetUserId();
            var loggedUser = this.Data.Users.Find(loggedUserId);
            if (!loggedUser.Friends.Contains(friendToBeRemoved))
            {
                return BadRequest("You are not friends");
            }


            friendToBeRemoved.Friends.Remove(loggedUser);
            loggedUser.Friends.Remove(friendToBeRemoved);

            this.Data.SaveChanges();

            return this.Ok();
        }


    }
}
