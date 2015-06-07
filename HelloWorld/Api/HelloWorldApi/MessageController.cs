using System;
using System.Web.Http;

namespace HelloWorld
{
    public class MessageController : ApiController
    {
        public object Get()
        {
            return new { Message = "Hello World" };
        }
    }
}
