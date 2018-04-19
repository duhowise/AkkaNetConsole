using System;
using Akka.Actor;

namespace FirstAkkaApp
{
    public class MyTypedActor:ReceiveActor
    {
        public MyTypedActor()
        {
            base.Receive<GreetingMessage>(message => GreetingMessageHamdler(message));
        }

        private void GreetingMessageHamdler(GreetingMessage message)
        {
            Console.WriteLine($"Typed actor named: {Self.Path.Name}");
            Console.WriteLine($"Received a greeting: {message.Greeting}");
            Console.WriteLine($"Actors path: {Self.Path} ");
            Console.WriteLine($"Actor is part of the ActorSystem: {Context.System.Name} ");
        }
    }
}