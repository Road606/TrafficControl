using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.Actors
{
    using Akka.Actor;
    using TrafficControl.Messages;
    class ProsecutorActor : ReceiveActor
    {
        public ProsecutorActor()
        {
            Receive<RegisterSpeedingViolation>(message => Handle(message));
        }

        private void Handle(RegisterSpeedingViolation message)
        {
            int fine;
            if(message.Speed <= 100)
            {
                fine = 2000;
            }
            else
            {
                fine = 5000;
            }
            Console.WriteLine($"Porušena povolená rychlost vozem {message.Brand} {message.Color} barvy s poznávací značkou {message.Registration}. Naměřena rychlost {message.Speed} km/h. Udělena pokuta {fine}Kč.");
        }
    }
}
