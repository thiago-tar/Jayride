using Jayride.Api.DTOs;
using Jayride.Domain.DependencyInjection;
using Jayride.Domain.Entities;
using Jayride.IOC;

namespace Jayride.Api
{
    public static class AppExtension
    {
        public static void DependencyInjectionAutoFac(this WebApplication app)
        {
            Dependencies.Solver = new Solver(app.Configuration);
            PreCreationData();
        }

        private static void PreCreationData() {
            Dependencies.CandidateRepository.Add(new Domain.Entities.Candidate() { Name = "Teste", Phone = "Teste" });
        }

        public static void AutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(x =>
            {
                x.CreateMap<Candidate, CandidateDTO>();
                x.CreateMap<CandidateDTO, Candidate>();
            });
        }

    }
}
