using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.Actors
{
    using Akka.Actor;
    using TrafficControl.Messages;
    class VehicleActor : ReceiveActor
    {
        private const int TrackLegnth = 10;

        private string _registration;
        private string _color;
        private string _brand;

        private DateTime _entryTime;
        private DateTime _exitTime;

        public VehicleActor()
        {
            Receive<VehicleEntryRegistered>(message => Handle(message));
            Receive<VehicleInfoAvailable>(message => Handle(message));
            Receive<VehicleExitRegistered>(message => Handle(message));
            Receive<Shutdown>(message => Context.Stop(Self));
        }

        private void Handle(VehicleEntryRegistered message)
        {
            var dmvActor = Context.ActorOf(Props.Create<DMVActor>(), "dmv-actor");
            _registration = message.Registration;
            _entryTime = message.EntryTime;
            dmvActor.Tell(new GetVehicleInfo(_registration));
        }

        private void Handle(VehicleInfoAvailable message)
        {
            _color = message.Color;
            _brand = message.Brand;
        }

        private void Handle(VehicleExitRegistered message)
        {
            Console.WriteLine($"Zaregistrován výjezd vozu z poznávací značkou {message.Registration}. Čas {message.ExitTime}");
            _exitTime = message.ExitTime;
            int totalSpeed = CalculateSpeed();
            if(totalSpeed > 80)
            {
                var prosecutorActor = Context.ActorSelection("/user/prosecutor");
                prosecutorActor.Tell(new RegisterSpeedingViolation(_registration, _color, _brand, totalSpeed));
                Context.Self.Tell(new Shutdown());
            }

        }

        private int CalculateSpeed()
        {
            TimeSpan passedTime =_exitTime - _entryTime;
            double seconds = (int)Math.Round(passedTime.TotalSeconds);
            double hours = seconds / 3600;
            return (int)Math.Round((double)(TrackLegnth / hours));
        }

    }
}
