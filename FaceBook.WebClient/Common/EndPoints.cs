namespace FaceBook.WebClient.Common
{
    public static class EndPoints
    {
        public const string Login =             "/Token";
        public const string Logout =            "/Logout";
        public const string Register =          "/api/account/register";
        public const string GetUserWall =       "/api/users/{0}/wall";
        public const string GetGroupWall =      "/api/groups/{0}/wall";
        public const string GetUserInfo =       "/api/users/info";
        public const string ChangeUserInfo =    "/api/users/change/UserInfo";
        public const string PostToUserWall =    "/api/user/posts";
        public const string PostComment =       "/api/posts/{0}/comments";
        public const string LikePost =          "/api/posts/{0}/likes";
        public const string LikeComment =       "/api/comments/{0}/likes";
        public const string SearchUser =        "/api/users/search?Name=";
        public const string AddFriend =         "/api/users/addfriend/{0}";
        public const string AreFriends =        "/api/users/{0}";
        public const string RemoveFriend =      "/api/users/removefriend/{0}";
        public const string GetUserFriends =    "/api/users/friends";
        public const string CreateGroup =       "/api/groups/create";
        public const string GetUserGroups =     "/api/groups/userGroups";
        public const string PostToGroupWall =   "/api/group/posts";
        public const string IsUserInGroup =     "/api/users/group/{0}";
        public const string JoinGroup =         "/api/groups/adduser";
        public const string LeaveGroup =        "/api/groups/removeuser";
        public const string GetNewsFeeds =      "/api/users/news/feed";


        //http://localhost:30446
    }
}