using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.Messages
{
    class VehicleInfoAvailable
    {
        public VehicleInfoAvailable(string color, string brand)
        {
            Color = color;
            Brand = brand;
        }

        public string Color { get; }
        public string Brand { get; }

    }
}
