using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.Messages
{
    class VehicleEntryRegistered
    {
        public VehicleEntryRegistered(string registration, DateTime entryTime)
        {
            Registration = registration;
            EntryTime = entryTime;
        }

        public string Registration { get; }

        public DateTime EntryTime { get; }
    }
}
