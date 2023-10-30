using Jayride.Domain.DependencyInjection;
using Jayride.Domain.Interfaces.Services;
using Jayride.Domain.ObjectValue;
using RestSharp;

namespace Jayride.Infra.Services
{
    public class JayrideService : IJayrideService
    {
        public async Task<JayrideQuoteRequest> GetQuote()
        {
            string url = Dependencies.JayrideApiData.Url;
            var client = new RestClient(url);

            var request = new RestRequest("QuoteRequest");

            return await client.GetAsync<JayrideQuoteRequest>(request);
        }
    }
}
