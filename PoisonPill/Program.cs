﻿using System;
using System.Threading;
using Akka.Actor;

namespace PoisonPill
{
    class Program
    {
        static void Main(string[] args)
        {
            //UsePoisonPill();
            //UseKill();
            //ExitGracefully();

            ActorSystem system=ActorSystem.Create("my-first-Akka");
            var emailSender = system.ActorOf<EmailSenderActor>("EmailSender");
            //send Invalid Message(null content).
            EmailMessage invalidEmail=new EmailMessage("from@email.com","to@email.com",null);
            EmailMessage validEmail=new EmailMessage("from@email.com","to@email.com","Hi");

            emailSender.Tell(validEmail);
            emailSender.Tell(invalidEmail);
            emailSender.Tell(validEmail);
            Console.Read();
            system.Terminate();
        }

        private static void ExitGracefully()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");
            IActorRef emailSender =
                system.ActorOf<EmailSenderActor>("emailSender");
            EmailMessage emailMessage = new EmailMessage("from@mail.com",
                "to@mail.com", "Hi");
            emailSender.Tell(emailMessage);
            var result = emailSender.GracefulStop(TimeSpan.FromSeconds(10));
            Thread.Sleep(1000);
            system.Terminate();
        }

        private static void UseKill()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");
            IActorRef emailSender =
                system.ActorOf<EmailSenderActor>("emailSender");
            EmailMessage emailMessage = new EmailMessage("from@mail.com",
                "to@mail.com", "Hi");
            emailSender.Tell(emailMessage);
            emailSender.Tell(emailMessage);
            emailSender.Tell(Kill.Instance);
            emailSender.Tell(emailMessage);
            Thread.Sleep(1000);
            system.Terminate();
            Console.Read();
        }

        private static void UsePoisonPill()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");
            IActorRef emailSender =
                system.ActorOf<EmailSenderActor>("emailSender");
            EmailMessage emailMessage = new EmailMessage("from@mail.com",
                "to@mail.com", "Hi");
            emailSender.Tell(emailMessage);
            emailSender.Tell(emailMessage);
            emailSender.Tell(Akka.Actor.PoisonPill.Instance);
            emailSender.Tell(emailMessage);
            Thread.Sleep(1000);
            system.Terminate();
            Console.Read();
        }

        private static void EmailActorSystem()
        {
            var system = ActorSystem.Create("calc-system");
            var emailer = system.ActorOf<EmailSenderActor>("Emailer");
            emailer.Tell(new EmailMessage("duhowise@gmail.com", "someemail@gmail.com", "Nice talking to you!"));

            Thread.Sleep(1000);
            system.Terminate();
            Console.Read();
        }
    }
}
