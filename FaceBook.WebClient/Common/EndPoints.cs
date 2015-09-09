namespace FaceBook.WebClient.Common
{
    public static class EndPoints
    {
        public const string Login =         "http://localhost:30446/Token";
        public const string Register =      "http://localhost:30446/api/account/register";
        public const string GetUserWall =   "http://localhost:30446/api/users/{0}/wall";
        public const string GetUserInfo =   "http://localhost:30446/api/users/info";
        public const string PostToUserWall ="http://localhost:30446/api/user/posts";
        public const string PostComment =   "http://localhost:30446/api/posts/{0}/comments";
        public const string LikePost =      "http://localhost:30446/api/posts/{0}/likes";
        public const string LikeComment =   "http://localhost:30446/api/comments/{0}/likes";
        public const string SearchUser =    "http://localhost:30446/api/users/search?Name=";
    }
}