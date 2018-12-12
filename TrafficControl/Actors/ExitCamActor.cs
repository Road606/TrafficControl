using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.Actors
{
    using Akka.Actor;
    using TrafficControl.Messages;

    class ExitCamActor : ReceiveActor
    {
        public ExitCamActor()
        {
            Receive<VehiclePassed>(message => Handle(message));
        }

        private void Handle(VehiclePassed message)
        {
            var vehicleActor = Context.ActorSelection($"/user/traffic-control/*/vehicle-{message.Registration}");
            vehicleActor.Tell(new VehicleExitRegistered(message.Registration, DateTime.Now.AddSeconds(440)));
        }
    }
}
