using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayride.Api.DataAccess.Entities
{
    public class VehicleListing
    {
        public string from { get; set; }

        public string to { get; set; }

        public List<Listings> listings { get; set; }
    }

    public class Listings
    {
        public string name { get; set; }
        public double pricePerPassenger { get; set; }

        public VehicleType vehicleType { get; set; }
    }

    public class VehicleType
    {
        public string name { get; set; }

        public int maxPassengers { get; set; }
    }
}
