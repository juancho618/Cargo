using System.Collections.Generic;
using System.Net;

namespace Cargo.Domain.Helpers
{
    public class JsonResultBody
    {
        public JsonResultBody()
        {
            Status = HttpStatusCode.OK;
            Errors = new List<string>();
        }

        public JsonResultBody(HttpStatusCode status)
        {
            Status = status;
            Errors = new List<string>();
        }

        public ICollection<string> Errors { get; set; }

        public HttpStatusCode Status { get; set; }

        public object Data { get; set; }
    }
}
