using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TrafficControl
{
    using Akka.Actor;
    using Akka.Routing;
    using Actors;
    using Messages;
    class Program
    {
        static void Main(string[] args)
        {

            using (var system = ActorSystem.Create("traffic-control"))
            {
                var enterCamActor1 = system.ActorOf(Props.Create<EnterCamActor>(), "enter-cam-1");
                var enterCamActor2 = system.ActorOf(Props.Create<EnterCamActor>(), "enter-cam-2");
                var enterCamActor3 = system.ActorOf(Props.Create<EnterCamActor>(), "enter-cam-3");

                var exitCamActor1 = system.ActorOf(Props.Create<ExitCamActor>(), "exit-cam-1");
                var exitCamActor2 = system.ActorOf(Props.Create<ExitCamActor>(), "exit-cam-2");
                var exitCamActor3 = system.ActorOf(Props.Create<ExitCamActor>(), "exit-cam-3");

                var trafficControlProps = Props.Create<TrafficControlActor>().WithRouter(new SmallestMailboxPool(2));
                var trafficControlActor = system.ActorOf(trafficControlProps, "traffic-control");

                var prosecutorActor = system.ActorOf(Props.Create<ProsecutorActor>(), "prosecutor");

                Console.WriteLine("Stiskni enter pro začátek simulace.");
                Console.ReadLine();

                enterCamActor1.Tell(new VehiclePassed("1S32456"));
                Thread.Sleep(1000);
                enterCamActor2.Tell(new VehiclePassed("1S81519"));
                Thread.Sleep(1000);
                enterCamActor3.Tell(new VehiclePassed("2U65487"));
                exitCamActor1.Tell(new VehiclePassed("1S81519"));
                Thread.Sleep(2000);
                exitCamActor2.Tell(new VehiclePassed("2U65487"));
                Thread.Sleep(7000);
                exitCamActor3.Tell(new VehiclePassed("1S32456"));

                Thread.Sleep(5000);
                Console.WriteLine("Pro ukončení programu stiskni enter.");
                Console.ReadLine();
            }

        }
    }
}
