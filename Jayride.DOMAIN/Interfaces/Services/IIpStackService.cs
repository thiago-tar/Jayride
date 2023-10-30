using Jayride.Domain.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayride.Domain.Interfaces.Services
{
    public interface IIpStackService
    {
        Task<IpLocation> GetLocation(string ip);
    }
}
