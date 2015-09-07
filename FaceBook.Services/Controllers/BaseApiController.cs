namespace FaceBook.Services.Controllers
{
    using System.Web.Http;
    using FaceBook.Data;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new FaceBookDb())
        {
        }

        public BaseApiController(FaceBookDb data)
        {
            this.Data = data;
        }

        protected FaceBookDb Data { get; set; }
    }
}
