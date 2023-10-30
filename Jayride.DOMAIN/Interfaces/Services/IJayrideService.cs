namespace Jayride.Domain.Interfaces.Services
{
    using ObjectValue;

    public interface IJayrideService
    {
        Task<JayrideQuoteRequest> GetQuote();
    }
}
