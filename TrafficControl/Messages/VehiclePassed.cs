using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.Messages
{
    class VehiclePassed
    {
        public VehiclePassed(string registration)
        {
            Registration = registration;
        }

        public string Registration { get; }
    }
}
