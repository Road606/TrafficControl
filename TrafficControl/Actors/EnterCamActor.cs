using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.Actors
{
    using Akka.Actor;
    using TrafficControl.Messages;

    class EnterCamActor : ReceiveActor
    {
        public EnterCamActor()
        {
            Receive<VehiclePassed>(message => Handle(message));
        }

        private void Handle(VehiclePassed message)
        {
            var trafficControlActor = Context.ActorSelection("/user/traffic-control");
            trafficControlActor.Tell(new VehicleEntryRegistered(message.Registration, DateTime.Now));
        }


    }
}
