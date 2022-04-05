using RegistryApi.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpService _httpService;

        public AuthenticationService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public string GetToken()
        {
            throw new NotImplementedException();
        }
    }
}
