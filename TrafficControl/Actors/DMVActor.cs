using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.Actors
{
    using Akka.Actor;
    using TrafficControl.Messages;
    class DMVActor : ReceiveActor
    {
        public DMVActor()
        {
            Receive<GetVehicleInfo>(message => Handle(message));
        }

        private void Handle(GetVehicleInfo message)
        {

            switch (message.Registration)
            {
                case "1S32456":
                    Sender.Tell(new VehicleInfoAvailable("bílé", "Škoda Octavia"));
                    break;
                case "1S81519":
                    Sender.Tell(new VehicleInfoAvailable("červené", "BMW E3"));
                    break;
                case "2U65487":
                    Sender.Tell(new VehicleInfoAvailable("černé", "Audi A8"));
                    break;
            }
        }
    }
}
