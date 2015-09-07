namespace FaceBook.WebClient.Pages.WebContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using FaceBook.WebClient.Models;

    public partial class Home : System.Web.UI.Page
    {
        public IEnumerable<Post> Select()
        {
            return new List<Post>()
            {
                new Post()
                {
                    Content = "BLAAAAAAAABLAAAAAA",
                    User = new User()
                    {
                        Username = "Dani"
                    },
                    PostedOn = DateTime.Now
                }
            };
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}