namespace FaceBook.Services.Models.DataModels
{
    using FaceBook.Models.Enumerations;
    using System;

    public class FullUserProfileDataModel
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string FamilyName { get; set; }

        public string PhoneNumber { get; set; }

        public string Town { get; set; }

        public string Country { get; set; }

        public RelationshipStatus RelationshipStatus { get; set; }

        public DateTime BornDate { get; set; }

        public Gender Gender { get; set; }

        public Gender InterestedIn { get; set; }

        public string DetailsAboutYou { get; set; }
    }
}