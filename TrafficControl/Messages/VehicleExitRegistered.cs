using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.Messages
{
    class VehicleExitRegistered
    {
        public VehicleExitRegistered(string registration, DateTime exitTime)
        {
            Registration = registration;
            ExitTime = exitTime;
        }

        public string Registration { get; }
        public DateTime ExitTime { get; }
    }
}
