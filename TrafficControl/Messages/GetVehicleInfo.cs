using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.Messages
{
    class GetVehicleInfo
    {
        public GetVehicleInfo(string registartion)
        {
            Registration = registartion;
        }

        public string Registration { get; }
    }
}
