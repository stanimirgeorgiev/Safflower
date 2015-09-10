using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    public class ChatController : BaseApiController
    {
        [HttpPost]
        [Route("api/chatrooms/{chatRoomId}/chat")]
        public IHttpActionResult PostChat(string chatRoomId, [FromBody] ChatBindingModel model)
        {
            int chatRoomIdFromString;
            var loggedUserId = User.Identity.GetUserId();
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
                && (roomPrivileges == ChatViewPrivileges.PrivateChatRoom
                    || roomPrivileges == ChatViewPrivileges.FriendsChatRoom))
            {
                return Content(HttpStatusCode.Unauthorized, "You are not authorized to chat in that room");
            }
            if (model.ChatPost == null)
            {
                return BadRequest("Invalid chat is entered.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var chat = new Chat
            {
                ChatRoomId = chatRoomIdFromString,
                ChatPost = model.ChatPost,
                CreatedOn = DateTime.Now,
                UserId = User.Identity.GetUserId()
            };
            Data.Chats.Add(chat);
            Data.SaveChanges();
            var data = Data.Chats
                .Where(c => c.ChatRoomId == chatRoomIdFromString)
                .Select(ChatDataModel.ChatList)
                ;
            return Ok(data);
        }
        //PATCH api/{chatRoomId}/chat/{chatId}
        [HttpPatch]
        [Route("api/chatrooms/{chatRoomId}/chat/{chatId}")]
        public IHttpActionResult PatchChat(string chatRoomId, string chatId, [FromBody] ChatDataModel model)
        {
            int chatRoomIdFromString;
            int chatIdFromString;
            var loggedUserId = User.Identity.GetUserId();
            try
            {
                chatRoomIdFromString = int.Parse(chatRoomId);
                chatIdFromString = int.Parse(chatId);
            }
            catch (Exception)
            {
                return BadRequest("Route paramenters for roomId and chatId must be an integer");
            }
            if (!Data.ChatRooms.Any(i => i.Id == chatRoomIdFromString))
            {
                return BadRequest("No such room.");
            }
            var chatsForSpecificRoom = Data.Chats.Where(ri => ri.ChatRoomId == chatRoomIdFromString).Select(i => i.Id);
            if (!chatsForSpecificRoom.Contains(chatIdFromString))
            {
                return BadRequest("No such chat Id.");
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
                return Content(HttpStatusCode.Unauthorized, "You are not authorized to edit chats in that room");
            }
            if (model.ChatPost == null)
            {
                return BadRequest("Invalid chat is entered.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var chatToEdit = Data.Chats
                .Find(chatIdFromString);
            var newChat = new Chat
            {
                Id = chatIdFromString,
                ChatPost = model.ChatPost,
                ChatRoomId = chatRoomIdFromString,
                CreatedOn = DateTime.Now,
                UserId = User.Identity.GetUserId()
            };
            Data.Chats.AddOrUpdate(chatToEdit, newChat);
            Data.SaveChanges();
            var data = Data.ChatRooms
                .Where(c => c.Id == chatRoomIdFromString)
                .Select(ChatRoomDataModel.ListOfChatsInRoom);
            return Ok(data);
        }
        //DELETE api/{chatRoomId}/chat/{chatId}
        [HttpDelete]
        [Route("api/chatrooms/{chatRoomId}/chat/{chatId}")]
        public IHttpActionResult DeleteChat(string chatRoomId, string chatId)
        {
            int chatRoomIdFromString;
            int chatIdFromString;
            var loggedUserId = User.Identity.GetUserId();
            try
            {
                chatRoomIdFromString = int.Parse(chatRoomId);
                chatIdFromString = int.Parse(chatId);
            }
            catch (Exception)
            {
                return BadRequest("Route paramenters for roomId and chatId must be an integer");
            }
            if (!Data.ChatRooms.Any(i => i.Id == chatRoomIdFromString))
            {
                return BadRequest("No such room.");
            }
            var chatsForSpecificRoom = Data.Chats.Where(ri => ri.ChatRoomId == chatRoomIdFromString).Select(i => i.Id);
            if (!chatsForSpecificRoom.Contains(chatIdFromString))
            {
                return BadRequest("No such chat Id.");
            }
            var chatOwner = Data.Chats.Find(chatIdFromString);
            var currentRoomOwner =
                Data.ChatRooms.Where(u => u.Id == chatRoomIdFromString).Select(i => i.UserId).ToList().First();
            if (currentRoomOwner != loggedUserId
                && chatOwner.UserId != loggedUserId)
            {
                return Content(HttpStatusCode.Unauthorized, "You are not allowed to delete this chat.");
            }
            var chatToEdit = Data.Chats
                .Find(chatIdFromString);
            Data.Chats.Remove(chatToEdit);
            Data.SaveChanges();
            var data = Data.ChatRooms
                .Where(c => c.Id == chatRoomIdFromString)
                .Select(ChatRoomDataModel.ListOfChatsInRoom);
            return Ok(data);
        }
    }
}