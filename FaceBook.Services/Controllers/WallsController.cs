using Microsoft.AspNet.Identity;

namespace FaceBook.Services.Controllers
{
    using System;
    using System.Linq;
    using FaceBook.Services.Models.DataModels;
    using System.Web.Http;

    [Authorize]
    public class WallsController : BaseApiController
    {
        [HttpGet]
        [Route("api/users/{userId}/wall")]
        public IHttpActionResult GetUserWall(string userId)
        {
            var user = this.Data.Users.Find(userId);
            if (user == null)
            {
                return this.NotFound();
            }

            var data = this.Data.WallsUsers
                .Where(uw => uw.Id == user.Id)
                .Select(UserWallDataModel.Create)
                .FirstOrDefault();

            return this.Ok(data);
        }

        [HttpGet]
        [Route("api/groups/{groupId}/wall")]
        public IHttpActionResult GetGroupWall(Guid groupId)
        {
            var group = this.Data.Groups.Find(groupId);
            if (group == null)
            {
                return this.NotFound();
            }

            var data = this.Data.WallsGroups
                .Where(uw => uw.Id == group.Id)
                .Select(GroupWallDataModel.Create)
                .FirstOrDefault();

            return this.Ok(data);
        }

        [HttpGet]
        [Route("api/users/GetNewsFeed")]
        public IHttpActionResult GetNewsFeed()
        {
            var loggedUserId = this.User.Identity.GetUserId();
            var loggedUser = this.Data.Users.Find(loggedUserId);

            var friends = loggedUser.Friends.AsQueryable();

            var result = friends
               .SelectMany(p => p.Posts)
               .OrderByDescending(p => p.PostedOn)
               .Select(PostDataModel.Create);


            return this.Ok(result);
        }
    }
}