using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Core.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public string GetToken();
    }
}
