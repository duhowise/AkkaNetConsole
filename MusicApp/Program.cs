using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace MusicApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ActorSystem system = ActorSystem.Create("my-first-akka");
            IActorRef dispatcher =
                system.ActorOf<MusicPlayerCoordinatorActor>("playercoordinator");
            dispatcher.Tell(new PlaySongMessage("Smoke on the water", "John"));
            dispatcher.Tell(new PlaySongMessage("Another brick in the wall","Mike"));
            dispatcher.Tell(new StopPlayingMessage("John"));
            dispatcher.Tell(new StopPlayingMessage("Mike"));
            dispatcher.Tell(new StopPlayingMessage("Mike"));
            Console.Read();
            system.Terminate();
        }
    }
}
