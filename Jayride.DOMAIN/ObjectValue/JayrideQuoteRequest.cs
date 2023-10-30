using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jayride.Domain.ObjectValue
{
    public class JayrideQuoteRequest
    {
        public string from { get; set; }
        public string to { get; set; }
        public List<Listing> listings { get; set; }
    }

    public class VehicleType
    {
        public string name { get; set; }
        public int maxPassengers { get; set; }
    }

    public class Listing
    {
        public string name { get; set; }
        public double pricePerPassenger { get; set; }
        public VehicleType vehicleType { get; set; }

        public double TotalPrice { get; set; }

        public double GetTotalPrice(int numberPassengers) => TotalPrice = numberPassengers * pricePerPassenger;
    }
}
