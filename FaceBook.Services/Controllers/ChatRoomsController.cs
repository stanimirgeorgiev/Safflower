using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using FaceBook.Models;
using FaceBook.Services.Models.BindingModels;
using FaceBook.Services.Models.DataModels;
using Microsoft.AspNet.Identity;
namespace FaceBook.Services.Controllers
{
    [Authorize]
    public class ChatRoomsController : BaseApiController
    {
        //GET api/chatrooms
        [HttpGet]
        [Route("api/chatrooms")]
        public IHttpActionResult GetChatRooms()
        {
            var loggedUserId = User.Identity.GetUserId();
            var loggedUser = Data.Users.Find(loggedUserId);
            var friends = loggedUser.Friends
                .Select(
                    u => new UserDataModel
                    {
                        UserId = u.Id
                    }).ToList();
            var friendsCollection = new HashSet<string>();
            foreach (var friend in friends)
            {
                friendsCollection.Add(friend.UserId);
            }
            var publicAndFriendsChatRooms = Data.ChatRooms
                .Where(
                    u => u.UserId == loggedUserId ||
                         u.Privileges == ChatViewPrivileges.PublicChatRoom ||
                         (u.Privileges == ChatViewPrivileges.FriendsChatRoom && friendsCollection.Contains(u.UserId)))
                .OrderBy(cr => cr.CreatedOn)
                .Select(ChatRoomDataModel.ListOfChatRooms);
            return Ok(publicAndFriendsChatRooms);
        }
        //GET api/chatrooms/{chatRoomId}
        [HttpGet]
        [Route("api/chatrooms/{chatRoomId}")]
        public IHttpActionResult GetChats(string chatRoomId)
        {
            var loggedUserId = User.Identity.GetUserId();
            int chatRoomIdFromString;
            try
            {
                chatRoomIdFromString = int.Parse(chatRoomId);
            }
            catch (Exception)
            {
                return BadRequest("Route paramenter must be a integer");
            }
            if (!Data.ChatRooms.Any(i => i.Id == chatRoomIdFromString))
            {
                return BadRequest("No such room.");
            }
            var loggedUser = Data.Users.Find(loggedUserId);
            var friends = loggedUser.Friends
                .Select(
                    u => new UserDataModel
                    {
                        UserId = u.Id
                    }).ToList();
            var friendsCollection = new HashSet<string>();
            foreach (var friend in friends)
            {
                friendsCollection.Add(friend.UserId);
            }
            var roomPrivileges =
                Data.ChatRooms.Where(i => i.Id == chatRoomIdFromString).Select(p => p.Privileges).ToList().First();
            var currentRoomOwner =
                Data.ChatRooms.Where(u => u.Id == chatRoomIdFromString).Select(i => i.UserId).ToList().First();
            if (!friendsCollection.Contains(loggedUserId)
                && currentRoomOwner != loggedUserId
                && roomPrivileges == ChatViewPrivileges.PrivateChatRoom)
            {
                return Content(HttpStatusCode.Unauthorized, "You are not authorized to access that room");
            }
            var chats = Data.ChatRooms
                .Where(c => c.Id == chatRoomIdFromString)
                .Select(ChatRoomDataModel.ListOfChatsInRoom);
            return Ok(chats);
        }
        //POST api/chatrooms
        [HttpPost]
        [Route("api/chatrooms")]
        public IHttpActionResult CreateChatRoomActionResult([FromBody] ChatRoomBindingModel model)
        {
            if (model.ChatRoomName == null ||
                (model.Privileges != ChatViewPrivileges.PrivateChatRoom
                && model.Privileges != ChatViewPrivileges.FriendsChatRoom
                && model.Privileges != ChatViewPrivileges.PublicChatRoom))
            {
                return BadRequest("ChatRoom name and privileges are mendatory.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.Identity.GetUserId();
            var chatRoom = new ChatRoom
            {
                Name = model.ChatRoomName,
                CreatedOn = DateTime.Now,
                UserId = userId,
                Privileges = model.Privileges
            };
            Data.ChatRooms.Add(chatRoom);
            Data.SaveChanges();
            var data = Data.ChatRooms
                .Where(c => c.Id == chatRoom.Id)
                .Select(ChatRoomDataModel.ListOfChatRooms);
            return Ok(data);
        }
        [HttpDelete]
        [Route("api/chatrooms/{chatRoomId}")]
        public IHttpActionResult DeleteChatRoom(string chatRoomId)
        {
            var loggedUserId = User.Identity.GetUserId();
            int chatRoomIdFromString;
            try
            {
                chatRoomIdFromString = int.Parse(chatRoomId);
            }
            catch (Exception)
            {
                return BadRequest("Route paramenter must be a integer");
            }
            if (!Data.ChatRooms.Any(i => i.Id == chatRoomIdFromString))
            {
                return BadRequest("No such room.");
            }
            var loggedUser = Data.Users.Find(loggedUserId);
            var friends = loggedUser.Friends
                .Select(
                    u => new UserDataModel
                    {
                        UserId = u.Id
                    }).ToList();
            var friendsCollection = new HashSet<string>();
            foreach (var friend in friends)
            {
                friendsCollection.Add(friend.UserId);
            }
            var roomPrivileges =
                Data.ChatRooms.Where(i => i.Id == chatRoomIdFromString).Select(p => p.Privileges).ToList().First();
            var currentRoomOwner =
                Data.ChatRooms.Where(u => u.Id == chatRoomIdFromString).Select(i => i.UserId).ToList().First();
            if (currentRoomOwner != loggedUserId)
            {
                return Content(HttpStatusCode.Unauthorized, "You are not authorized to delete that room");
            }
            var chatsInRoom =
                Data.ChatRooms.Where(i => i.Id == chatRoomIdFromString).Select(c => c.Chats).First().ToList();
            var chatRoom = Data.ChatRooms.First(i => i.Id == chatRoomIdFromString);
            Data.Chats.RemoveRange(chatsInRoom);
            Data.ChatRooms.Remove(chatRoom);
            Data.SaveChanges();
            return Ok();
        }
    }
}