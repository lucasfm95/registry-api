using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Domain.Response
{
    public class ErrorResponse
    {
        public HttpStatusCode? StatusCode { get; set; }
        public string? Description { get; set; }
        public List<string>? ErrorsMessages { get; set; }
    }
}
