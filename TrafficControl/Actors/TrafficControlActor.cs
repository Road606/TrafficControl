using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.Actors
{
    using Akka.Actor;
    using TrafficControl.Messages;

    class TrafficControlActor : ReceiveActor
    {
        public TrafficControlActor()
        {
            Receive<VehicleEntryRegistered>(message => Handle(message));
        }

        private void Handle(VehicleEntryRegistered message)
        {
            Console.WriteLine($"Zaregistrován vjezd vozu z poznávací značkou {message.Registration}. Čas {message.EntryTime}");
            var vehicleActor = Context.ActorOf(Props.Create<VehicleActor>(), $"vehicle-{message.Registration}");
            vehicleActor.Tell(message);
        }
    }
}
