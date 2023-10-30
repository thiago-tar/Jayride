using Jayride.Domain.Config;
using Jayride.Domain.Interfaces.Repositories;
using Jayride.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayride.Domain.DependencyInjection
{
    public class Dependencies
    {
        private static ISolver _solver;
        private static object _lock = new object();

        public static ISolver Solver
        {
            get
            {
                lock (_lock)
                {
                    if (_solver == null)
                        throw new SolveNotImplemented("Solver has not been Implemented");

                    return _solver;
                }
            }
            set
            {
                lock (_lock)
                {
                    _solver = value;
                }
            }
        }

        public static ICandidateRepository CandidateRepository {  get => Solver.Resolve<ICandidateRepository>(); }

        public static IIpStackService IpStackService { get => Solver.Resolve<IIpStackService>(); }

        public static IpStackData IpStackData { get => Solver.Resolve<IpStackData>(); }

        public static JayRideApiData JayrideApiData { get=> Solver.Resolve<JayRideApiData>(); }

        public static IJayrideService JayrideService { get => Solver.Resolve<IJayrideService>(); }

    }
}
