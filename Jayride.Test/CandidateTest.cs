using Jayride.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Jayride.Test
{
    [TestClass]
    public class CandidateTest
    {
        [TestMethod]
        public async Task GetAllCandidate()
        {

            var count = 0;
            var appFactory = new WebApplicationFactory<Program>();

            var httpClient = appFactory.CreateDefaultClient();
            var response = await httpClient.GetFromJsonAsync<IEnumerable<Candidate>>(httpClient.BaseAddress + "api/candidate");

            Assert.IsTrue(response.Count() > count, $"The number of candidate was not greater than {count}");
        }
    }
}