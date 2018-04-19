using System;
using Akka.Actor;

namespace FirstAkkaApp
{
    public class MyUnTypedActor:UntypedActor
    {
        protected override void OnReceive(object message)
        {
            if (message is GreetingMessage greeting)
            {
                GreetingMessageHandler(greeting);
            }
        }

        private void GreetingMessageHandler(GreetingMessage greeting)
        {
            Console.WriteLine($"Typed actor named: {Self.Path.Name}");
            Console.WriteLine($"Received a greeting: {greeting.Greeting}");
            Console.WriteLine($"Actors path: {Self.Path} ");
            Console.WriteLine($"Actor is part of the ActorSystem: {Context.System.Name} ");
        }
    }
}