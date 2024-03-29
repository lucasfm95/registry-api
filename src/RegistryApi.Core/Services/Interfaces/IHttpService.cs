﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Core.Services.Interfaces
{
    public interface IHttpService
    {
        HttpResponseMessage PostSync(string path, string content, Dictionary<string, string>? headers = null);
    }
}
