namespace FaceBook.WebClient.Models
{
    using System;
    using System.Text.RegularExpressions;

    public class WallGroup : Wall
    {
        public WallGroup()
        {
            this.Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }

        public virtual Group Group { get; set; }
    }
}
