using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FaceBook.Data;

namespace FaceBook.Services.Controllers
{
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
