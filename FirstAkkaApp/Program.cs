using System;
using Akka.Actor;

namespace FirstAkkaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");
            IActorRef untypedActor = system.ActorOf<MyUnTypedActor>("untyped-actorname");
            IActorRef typedActor = system.ActorOf<MyTypedActor>("typed-actorname");
            untypedActor.Tell(new GreetingMessage("Hello untyped actor!"));
            typedActor.Tell(new GreetingMessage("Hello typed actor!"));
            Console.Read();
        }
    }
}
