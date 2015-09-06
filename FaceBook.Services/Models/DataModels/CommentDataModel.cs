namespace FaceBook.Services.Models.DataModels
{
    public class CommentDataModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public UserDataModel Author { get; set; }
    }
}