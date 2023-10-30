using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayride.Domain.Config
{
    public class IpStackData
    {
        public static string IpStackDataSection = "IpStack";
        public string AccessKey { get; set; }

        public string Url { get; set; }
    }
}
