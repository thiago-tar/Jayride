using Jayride.Domain.Entities;
using Jayride.Domain.ObjectValue;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Jayride.Test
{
    [TestClass]
    public class ListingsTest
    {

        [TestMethod]
        public async Task GetListing()
        {
            var appFactory = new WebApplicationFactory<Program>();
            int passengers = 1;
            var httpClient = appFactory.CreateDefaultClient();
            var response = await httpClient.GetFromJsonAsync<IEnumerable<Listing>>(httpClient.BaseAddress + $"api/listings/{passengers}");

            Assert.IsNotNull(response);
        }
    }
}
