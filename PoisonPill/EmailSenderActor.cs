using System;
using Akka.Actor;

namespace PoisonPill
{
    public class EmailSenderActor:ReceiveActor
    {
        public EmailSenderActor()
        {
            Console.WriteLine("Constructor()-> EmailSender");
            Receive<EmailMessage>(message => EmailMessageHAndler(message));
        }

        private void EmailMessageHAndler(EmailMessage message)
        {
            if (string.IsNullOrEmpty(message.Content))
            {
                throw new ArgumentException("Cannot handle the empty content");
            }
            Console.WriteLine($"Email sent from {message.From} to{ message.To}");
        }
        protected override void PreStart()
        {
            Console.WriteLine("PreStart() -> EmailSenderActor");
        }
        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine("PreRestart() -> EmailSenderActor");
            /* base.PreRestart(reason, message); */
        }
        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine("PostRestart() -> EmailSenderActor");
            base.PostRestart(reason);
        }
        protected override void PostStop()
        {
            Console.WriteLine("PostStop() -> EmailSenderActor");
        }
    }
    
}