using Jayride.Domain.ObjectValue;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Jayride.Test
{
    [TestClass]
    public class LocationTest
    {
        [TestMethod]
        public async Task GetlocationIP()
        {
            var appFactory = new WebApplicationFactory<Program>();
            string ip = await GetIp();
            var httpClient = appFactory.CreateDefaultClient();
            var response = await httpClient.GetFromJsonAsync<IpLocation>(httpClient.BaseAddress + $"api/location/{ip}");
            Assert.IsNotNull(response);
        }

        public  async Task<IPAddress?> GetExternalIpAddress()
        {
            var externalIpString = (await new HttpClient().GetStringAsync("http://icanhazip.com"))
                .Replace("\\r\\n", "").Replace("\\n", "").Trim();
            if (!IPAddress.TryParse(externalIpString, out var ipAddress)) return null;
            return ipAddress;
        }

        private async Task<string> GetIp()
        {
            var externalIpTask = await GetExternalIpAddress();
            var ip = externalIpTask ?? IPAddress.Loopback;
            return ip.ToString();
        } 
    }
}
