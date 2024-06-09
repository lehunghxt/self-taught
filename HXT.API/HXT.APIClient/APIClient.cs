using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXT.APIClient
{
    public class APIClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public APIClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClientFactory.CreateClient("");
        }
    }
}
