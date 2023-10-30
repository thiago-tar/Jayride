using Jayride.Domain.DependencyInjection;
using Jayride.Domain.Interfaces.Services;
using Jayride.Domain.ObjectValue;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayride.Infra.Services
{
    public class IpStackService : IIpStackService
    {
        public async Task<IpLocation> GetLocation(string ip)
        {
            string url = Dependencies.IpStackData.Url;
            string accessKey = Dependencies.IpStackData.AccessKey;

            var client = new RestClient(url);

            var request = new RestRequest(ip);
            request.AddQueryParameter("access_key", accessKey);

            return await client.GetAsync<IpLocation>(request);
            
        }
    }
}
