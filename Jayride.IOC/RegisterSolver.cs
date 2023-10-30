using Jayride.Domain.Config;
using Jayride.Domain.Interfaces.Repositories;
using Jayride.Domain.Interfaces.Services;
using Jayride.Infra.Repositories;
using Jayride.Infra.Services;
using Microsoft.Extensions.Configuration;

namespace Jayride.IOC
{
    public partial class Solver
    {
        private void Register()
        {
            Repositories();
            Services();
            Config();
        }

        private void Repositories()
        {
            Singleton<ICandidateRepository, CandidateRepository>();
        }

        private void Services()
        {
            Scoped<IIpStackService, IpStackService>();
            Scoped<IJayrideService, JayrideService>();
        }

        private void Config()
        {
            Singleton(_config.GetSection(IpStackData.IpStackDataSection).Get<IpStackData>());
            Singleton(_config.GetSection(JayRideApiData.JayrideApiSection).Get<JayRideApiData>());
        }
    }
}
